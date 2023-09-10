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

        public override void OnRun(IEventObject ev, bool isRoot)
        {
            IInstanceCard card = ev.resCard as IInstanceCard;
            ev.targetZone = new IZone[] { card.owner.grave };
            IZone zone = ev.resZone!;
            if (!card.OnBeforeDie(ev)) { return; }
            if(zone is BattleGroundTileZone)
            {
                IEventObject leaveBattleEvent = new IEventObject();
                leaveBattleEvent.resCard= card;
                leaveBattleEvent.resZone = ev.resZone;
                new CardMoveZoneEvent(leaveBattleEvent).Run(leaveBattleEvent, false);
            }
            card.OnAfterDie(ev);


        }
    }
}
