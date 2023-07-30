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
    public class EventObject_PlayUnitCard : IEventObject
    {
        public int tile; //到哪个战场块
        public IZone whereFrom; //从哪个区域打出来的
        public EventObject_PlayUnitCard(ICard card)
        {
            this.res = card;
            this.type = EventObjectConst.EventObjectType.PLAY_UNIT_CARD;
        }
    }
}
