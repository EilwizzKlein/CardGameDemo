using CityCompanyCard_API.Card;
using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Manager
{
    public class CardManager
    {
       private Dictionary<CardType,ICardManager> managerList = new Dictionary<CardType, ICardManager>();
        public  Boolean playCard(ICard res, IEventObject eventObject) {
            //beforePlay
            if (managerList.TryGetValue(res.type, out ICardManager cardManager)) {
                cardManager.PlayCard(res, eventObject);
            }
            return true;
        }

        public Boolean registManagerList(CardType cardType, ICardManager cardManager) {
            if (this.managerList.ContainsKey(cardType)) {
                return true;
            }
            this.managerList.Add(cardType, cardManager);
            return true;
        }
    }
}
