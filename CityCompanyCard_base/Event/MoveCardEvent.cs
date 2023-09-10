using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Event
{
    public class MoveCardEvent : IEvent
    {
        public MoveCardEvent(IEventObject eventObject) : base(eventObject)
        {
        }

        public override void OnRun(IEventObject ev, bool isRoot)
        {
            BattleGroundTileZone[] outbattleground = ev.targetBattleGroundTileZone;
            IInstanceCard card = ev.resCard as IInstanceCard;
            card.OnBeforeMove(ev);
            if (outbattleground.Length > 0)
            {
                ZoneManager.moveCardToBattleGround(ev.resBattleGround, card, ev.targetBattleGroundTileZone[0]);
            }
            card.OnAfterMove(ev);
        }
    }
}
