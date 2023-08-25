using CityCompanyCard_API.Dictionary;
using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Factory
{
    public class CardManagerFactory
    {
        private Dictionary<CardType, ICardManager> _managerList = new Dictionary<CardType, ICardManager>();

        public Boolean getCardManager(CardType type,out ICardManager cardManager)
        {
            if (_managerList.ContainsKey(type))
            {
                cardManager = _managerList[type];
                return true;
            }
            else
            {
                cardManager = null;
                return false;
            }
        }

        public Boolean registManagerList(CardType cardType, ICardManager cardManager)
        {
            if (this._managerList.ContainsKey(cardType))
            {
                return true;
            }
            this._managerList.Add(cardType, cardManager);
            return true;
        }
    }
}
