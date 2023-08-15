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
        public static Boolean drawCardsToZone(IZone res, IZone target, int number)
        {

            if (res is null || target is null)
            {
                throw new Exception("来源zone或目标zone为null");
            }
            if (res.cardList.Count < number)
            {
                return false;
            }

            if (target.cardList.Count + number > target.max || target.max == -1)
            {
                return false;
            }

            List<ICard> elementsToMove = res.cardList.GetRange(0, number);
            foreach (var item in elementsToMove)
            {
                item.setZone(target);
                target.cardList.Add(item);

            }
            res.cardList.RemoveRange(0, number);
            return true;

        }

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

        public static Boolean moveCardsToZone(IZone res, IZone target,ICard card)
        {
            res.cardList.Remove(card);
            target.cardList.Add(card);
            card.setZone(res);
            return true;
        }

        public static Boolean moveCardsToZone(IZone res, IZone target)
        {
            return drawCardsToZone(res, target, 1);
        }
    }
}
