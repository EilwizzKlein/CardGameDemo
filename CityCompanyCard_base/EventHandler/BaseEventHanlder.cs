using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Dictionary;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.BO;
using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.EventHandler
{
    public class BaseEventHanlder : IEventHandler
    {
        public override bool MoveCard(IEventObject eventObject)
        {
            return true;
        }



        public override bool PlayPower(IEventObject eventObject)
        {
            return true;
        }

        public override bool CreateCard(IEventObject eventObject)
        {
            return true;
        }

        public override bool GoToNextState(IEventObject eventObject)
        {
            return true;
        }
    }
}
