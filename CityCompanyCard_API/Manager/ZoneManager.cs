using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Instance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Manager
{
    public class ZoneManager
    {
      

        public static Boolean moveCardToBattleGround(IBattleGround battleGround,ICard card, BattleGroundTileZone targetZone) {
            if (!battleGround.CardList.Contains(card))
            {
                battleGround.CardList.Add(card);
            }
            card.GetZone().cardList?.Remove(card);
            card.setZone(targetZone);
            targetZone?.cardList.Add(card);
            return true;
        }
        public static Boolean removeCardToBattleGround(IBattleGround battleGround, ICard card)
        {
            battleGround.CardList.Remove(card);
            return removeCardByCard(card.GetZone(), card);
        }
        public static Boolean removeCardByCard(IZone res,ICard card) {
            res.cardList.Remove(card);
            return true;

        }


    }
}
