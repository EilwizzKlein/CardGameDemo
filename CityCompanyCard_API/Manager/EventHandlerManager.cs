using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Manager
{
    public abstract class EventHandlerManager
    {
        public abstract Boolean MoveCard(IEventObject eventObject);

        public abstract Boolean DrawCard(IEventObject eventObject);

        public abstract Boolean PlayCard(IEventObject eventObject);

        public abstract Boolean AttackEvent(IEventObject eventObject);

        public abstract Boolean PlayPower(IEventObject eventObject);

        public abstract Boolean CreateCard(IEventObject eventObject);

        public abstract Boolean GoToNextState(IEventObject eventObject);
    }
}
