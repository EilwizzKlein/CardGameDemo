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

namespace CityCompanyCard_base.Manager.CardManager
{
    public class InstanceCardManager : ICardManager
    {
        public override void GetDamage(ICard card, IEventObject eventObject)
        {
            throw new NotImplementedException();
        }

        public override void PlayCard(ICard card, IEventObject eventObject)
        {
            //区域转移
            if (card is IInstanceCard)
            {
                ZoneManager.moveCardToBattleGround(eventObject.targetBattleGround[0], card, (BattleGroundTileZone)eventObject.targetZone[0]);
            }
        }
    }
}
