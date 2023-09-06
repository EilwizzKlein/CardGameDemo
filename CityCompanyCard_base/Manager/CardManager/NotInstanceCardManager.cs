using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Manager.CardManager
{
    public class NotInstanceCardManager : ICardManager
    {

        public override void PlayCard(ICard card,IEventObject eventObject)
        {
           if(card is ICommandCard)
            {
                if(ApplicationContext.Instance.cardManagerFactory.getCardManager(CityCompanyCard_API.Dictionary.CardType.Command,out ICardManager cm))
                {
                    cm.PlayCard(card, eventObject);
                }
            }
        }
    }
}
