﻿    using CityCompanyCard_API;
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

        public override void OnRun(IEventObject ev, bool isRoot)
        {
            IInstanceCard card = (IInstanceCard)ev.resCard;
            if (!card.OnBeforeDamage(ev)) { return; };
            ApplicationContext.Instance.cardManagerFactory.getCardManager(CityCompanyCard_API.Dictionary.CardType.Instance,out ICardManager cardManager);
            ((InstanceCardManager)cardManager).GetDamage(card, ev);
            card.OnAfterDamage(ev);
            card.Render();
            if(card.isDead)
            {
                IEventObject cardDieEventObject = new IEventObject();
                cardDieEventObject.resCard = card;
                cardDieEventObject.targetCard = ev.targetCard;
                cardDieEventObject.resZone = ev.resZone;
                //卡牌死亡事件
                CardDieEvent cardDie = new CardDieEvent(cardDieEventObject);
                ApplicationContext.Instance.eventQueue.Add(cardDie);
            }
        }
    }
}
