using CityCompanyCard_API.Card;
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
    public class CardMoveZoneEvent:IEvent
    {

        public CardMoveZoneEvent(IEventObject eventObject) : base(eventObject)
        {
        }

        public override void OnRun(IEventObject ev, bool isRoot)
        {
            ICard card = ev.resCard;
            IZone zone = ev.resZone;
            if (!card.OnBeforeMoveZone(ev)) { return; }

            if(!(zone is IBattleGround) && !(zone is BattleGroundTileZone))
            {
            card.RemoveAllBuff();
            }
            if (zone is BattleGroundTileZone)
            {
                ((BattleGroundTileZone)zone).getResBattleGround().CardList.Remove(card);
            }
            zone.cardList.Remove(card);
            ev.targetZone[0].cardList.Add(card);
            card.setZone(ev.targetZone[0]);
            card.OnAfterMoveZone(ev);
        }
    }
}
