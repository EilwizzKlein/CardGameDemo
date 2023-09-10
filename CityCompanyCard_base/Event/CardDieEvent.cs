using CityCompanyCard_API;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Event
{
    public class CardDieEvent : IEvent
    {
        public CardDieEvent(IEventObject eventObject) : base(eventObject)
        {
        }

        public override void Run(IEventObject ev, bool isRoot)
        {
            IEventObject eventObject =new IEventObject(ev);
            IInstanceCard card = eventObject.resCard as IInstanceCard;
            eventObject.targetZone = new IZone[] { card.owner.grave };
            IZone zone = eventObject.resZone as IZone;
            if (!card.OnBeforeDie(eventObject)) { return; }
            //移除所有非永久buff
            card.RemoveAllBuff();
            zone.cardList.Remove(card);
            if(zone is BattleGroundTileZone)
            {
                ((BattleGroundTileZone)zone).getResBattleGround().CardList.Remove(card);
            }
            eventObject.targetZone[0].cardList.Add(card);
            card.OnAfterDie(eventObject);
            ApplicationContext.Instance.RunEventQueue(isRoot);


        }
    }
}
