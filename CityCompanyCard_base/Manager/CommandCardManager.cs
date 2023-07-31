using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.BattleGround;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.EventObject;
using CityCompanyCard_base.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Manager
{
    public class CommandCardManager : ICardManager
    {
        public override bool PlayCard(ICard res, IEventObject eventObject)
        {
            EventObject_PlayCommandCard playCommandCard = (EventObject_PlayCommandCard)eventObject;
            ((MainPlayer)playCommandCard.res).command.chooseCommand((ICommandCard)res);
             res.OnPlay(eventObject);
            return true;
        }

    }
}
