using CityCompanyCard_API.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public abstract class ICardManager
    {
        public abstract Boolean playCard(ICard res, IEventObject eventObject);
    }
}
