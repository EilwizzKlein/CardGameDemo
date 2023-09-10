    using CityCompanyCard_API;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.BO;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.Manager.CardManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Event
{
    public class CardOnDamageEvent : IEvent
    {
        public CardOnDamageEvent(IEventObject eventObject) : base(eventObject)
        {
        }

        public override void Run(IEventObject ev, bool isRoot)
        {
            IEventObject eventObject = new IEventObject(ev);
            IInstanceCard card = (IInstanceCard)eventObject.resCard;
            if (!card.OnBeforeDamage(eventObject)) { return; };
            ApplicationContext.Instance.cardManagerFactory.getCardManager(CityCompanyCard_API.Dictionary.CardType.Instance,out ICardManager cardManager);
            ((InstanceCardManager)cardManager).GetDamage(card, eventObject);
            card.OnAfterDamage(eventObject);
            card.Render();
            if(card.isDead)
            {
                IEventObject cardDieEventObject = new IEventObject();
                cardDieEventObject.resCard = card;
                cardDieEventObject.targetCard = eventObject.targetCard;
                cardDieEventObject.resZone = eventObject.resZone;
                //卡牌死亡事件
                CardDieEvent cardDie = new CardDieEvent(cardDieEventObject);
                ApplicationContext.Instance.eventQueue.Add(cardDie);
            }
            ApplicationContext.Instance.RunEventQueue(isRoot);
        }
    }
}
