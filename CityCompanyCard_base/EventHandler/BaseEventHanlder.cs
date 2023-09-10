using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Dictionary;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.BO;
using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.EventHandler
{
    public class BaseEventHanlder : IEventHandler
    {
        public override bool MoveCard(IEventObject eventObject)
        {
            return true;
        }


        public override bool Attack(IEventObject eventObject)
        {
            //
            if (eventObject.resCard == null || eventObject.targetCard == null || eventObject.targetCard.Length <= 0) { return false; }
            IInstanceCard? res = eventObject.resCard as IInstanceCard;
            ICard[] targets = eventObject.targetCard!;
            bool flag = false;
            for (int i = 0; i < targets.Length; i++)
            {
                //为了避免参数干扰 单独拷贝事件对象
                IEventObject ev = new IEventObject(eventObject);
                IInstanceCard target = (IInstanceCard)targets[i];
                //6.被攻击方预检定OnBeforeAttack()⇒如果返回是True则继续结算
                if (!target.OnBeforeAttacked(ev)) { continue; }
                //8.被攻击方预检定受到伤害事件OnBeforeDamage()⇒如果返回是True则继续结算
                if (!target.OnBeforeDamage(ev)) { continue; }
                //10.被攻击方处理受到伤害后事件OnAfterDamage()
                target.OnAfterDamage(ev);
                if (target is IUnitCard)
                {
                    IEventObject counterAttack = new IEventObject();
                    //11.构建反击事件对象:event.resCard,event.targetCard
                    counterAttack.resCard = target;
                    counterAttack.targetCard = new ICard[] { res! };
                    if (!flag) { flag = true; }
                    //12.被攻击方预检定反击事件OnBeforeCounterattack()⇒如果返回是True则继续结算
                    if (!target.OnBeforeCounterattack(counterAttack)) { continue; }
                    //13.被反击方预检定受到伤害事件OnBeforeDamage()⇒如果返回是True则继续结算
                    if (!res.OnBeforeDamage(counterAttack)) { continue; }
                    //15.被反击方处理受到伤害后事件OnAfterDamage()
                    res.OnAfterDamage(counterAttack);
                    //16.被攻击方处理反击后事件OnAfterCounterattack();
                    target.OnAfterCounterattack(counterAttack);
                    //17.被攻击方处理攻击后事件OnAfterAttack();
                    target.OnAfterAttacked(ev);
                }
            }

            //死亡结算
            if (res.isDead)
            {
                if (res.OnBeforeDestroy(eventObject))
                {
                    res.OnAfterDestroy(eventObject);
                }
            }
            for (int i = 0; i < targets.Length; i++)
            {
                //为了避免参数干扰 单独拷贝事件对象
                IEventObject ev = new IEventObject(eventObject);
                IInstanceCard target = (IInstanceCard)targets[i];

                if (target.isDead)
                {
                    IEventObject counterAttack = new IEventObject();
                    //11.构建反击事件对象:event.resCard,event.targetCard
                    counterAttack.resCard = target;
                    counterAttack.targetCard = new ICard[] { res! };
                    if (target.OnBeforeDestroy(counterAttack))
                    {
                        target.OnAfterDestroy(counterAttack);
                    }
                }
            }
            return flag;
        }

        public override bool PlayPower(IEventObject eventObject)
        {
            return true;
        }

        public override bool CreateCard(IEventObject eventObject)
        {
            return true;
        }

        public override bool GoToNextState(IEventObject eventObject)
        {
            return true;
        }
    }
}
