using CityCompanyCard_API.Card;
using CityCompanyCard_API.Dictionary;
using CityCompanyCard_API;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Dictionary;
using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Event
{
    public class PlayCardEvent : IEvent
    {
        public PlayCardEvent(IEventObject eventObject) : base(eventObject)
        {
            //需要检查的条件
        }

        public override void Run(IEventObject ev, bool isRoot)
        {
            Boolean flag = true;
            ICard card = ev.resCard!;
            flag = card.OnBeforePlay(ev);
            ApplicationContext.Instance.RunEventQueue(isRoot);
            if (!flag) { return; }
            //结算事件
           
            //是否为免费释放
            if (!ev.resKeyValus.ContainsKey(EventObjectExtractKey.FREE_TO_USE) || ev.resKeyValus[EventObjectExtractKey.FREE_TO_USE] != null)
            {
                //费用检查,消耗费用
                if (ev.resPlayer!.mana < card.renderCardBO.cost)
                {
                    return;
                }
                ev.resPlayer.mana -= card.renderCardBO.cost;
            }
            ICardManager cm = null;
            if (card is IInstanceCard)
            {
                ApplicationContext.Instance.cardManagerFactory.getCardManager(CardType.Instance, out cm);
            }
            else if (card is INotInstanceCard)
            {
                ApplicationContext.Instance.cardManagerFactory.getCardManager(CardType.NotInstance, out cm);
            }
            if (cm == null)
            {
                return;
            }
            cm.PlayCard(card, ev);
            card.OnAfterPlay(ev);
            ApplicationContext.Instance.RunEventQueue(isRoot);
        }
    }
}
