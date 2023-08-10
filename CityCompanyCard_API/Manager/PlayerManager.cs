using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Manager
{
    public class PlayerManager
    {
        public static Boolean playCard(IEventObject eventObject)
        {
            //beforePlay
            ICard? res = eventObject.resCard;
            if (res!= null && ApplicationContext.Instance.cardManagerFactory!.getCardManager(res.type, out ICardManager cardManager))
            {
                cardManager.PlayCard(eventObject);
            }
            return true;
        }

    }
}
