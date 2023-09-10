using CityCompanyCard_API.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public abstract class IEventHandler
    {
        public abstract bool MoveCard(IEventObject eventObject);
        public abstract bool Attack(IEventObject eventObject);
        public abstract bool PlayPower(IEventObject eventObject);

        public abstract bool CreateCard(IEventObject eventObject);
        public abstract bool GoToNextState(IEventObject eventObject);
    }
}
