using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.BattleGround;
using CityCompanyCard_base.Card.Interface;
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
        public override bool PlayCard( IEventObject eventObject)
        {
            ICard res = eventObject.resCard!;
            //全局保存当前指令
            ((MainPlayer)eventObject.resPlayer!).ChooseCommand((ICommandCard)res);
             res.OnPlay(eventObject);
            return true;
        }

    }
}
