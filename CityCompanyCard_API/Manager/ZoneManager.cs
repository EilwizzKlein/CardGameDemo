using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Manager
{
    public class ZoneManager
    {
        public static Boolean moveCardsToZone(IZone res, IZone target, int number)
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
            target.cardList.AddRange(elementsToMove);
            res.cardList.RemoveRange(0, number);
            return true;

        }

        public static Boolean removeCardByCard(IZone res,ICard card) {
            return res.cardList.Remove(card);
        }

        public static Boolean moveCardsToZone(IZone res, IZone target)
        {
            return moveCardsToZone(res, target, 1);
        }
    }
}
