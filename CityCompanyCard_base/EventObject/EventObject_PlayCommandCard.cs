using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.EventObject
{
    public class EventObject_PlayCommandCard : IEventObject
    {
        public EventObject_PlayCommandCard(IPlayer player)
        {
            this.res = player;
            this.type = EventObjectConst.EventObjectType.PLAY_COMMAND_CARD;
        }
    }
}
