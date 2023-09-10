using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.BO;
using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Event
{
    public class AttackEvent : IEvent
    {
        public AttackEvent(IEventObject eventObject) : base(eventObject)
        {
        }

        public override void Run(IEventObject ev, bool isRoot)
        {
            //
            if (ev.resCard == null || ev.targetCard == null || ev.targetCard.Length <= 0) { return ; }
            IInstanceCard? res = ev.resCard as IInstanceCard;
            ICard[] targets = ev.targetCard!;
            bool flag = false;
            for (int i = 0; i < targets.Length; i++)
            {
                IInstanceCard target = (IInstanceCard)targets[i];
                //6.被攻击方预检定OnBeforeAttack()⇒如果返回是True则继续结算
                if (!target.OnBeforeAttacked(ev)) { continue; }
            }
            ApplicationContext.Instance.RunEventQueue(isRoot);
            for (int i = 0; i < targets.Length; i++)
            {
                IInstanceCard target = (IInstanceCard)targets[i];
                IEventObject damegeEvent = new IEventObject();
                damegeEvent.resZone = target.GetZone();
                damegeEvent.resCard = target;
                damegeEvent.targetCard =new ICard[] { res };
                damegeEvent.value = ((InstanceCardBO)res.renderCardBO).currentAttack;
                new CardOnDamageEvent(damegeEvent).Run(damegeEvent,false);
                target.OnAfterAttacked(ev);
            }
            ApplicationContext.Instance.RunEventQueue(isRoot);
            for (int i = 0; i < targets.Length; i++)    
            {
                IInstanceCard target = (IInstanceCard)targets[i];
                if (target is IUnitCard)
                {
                    IEventObject counterAttack = new IEventObject();
                    //11.构建反击事件对象:event.resCard,event.targetCard
                    counterAttack.resCard = target;
                    counterAttack.targetCard = new ICard[] { res! };
                    new CounterAttackEvent(counterAttack).Run(counterAttack, false);
                }
            }
            ApplicationContext.Instance.RunEventQueue(isRoot);
        } 
    }
}
