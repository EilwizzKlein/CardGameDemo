using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.BattleGround;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.Manager.CardManager;
using CityCompanyCard_base.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Manager
{
    public class CommandCardManager : NotInstanceCardManager
    {
        public override void PlayCard(ICard card, IEventObject eventObject)
        {
            ICommandCard res = (ICommandCard)card!;
            ((MainPlayer)eventObject.resPlayer!).ChooseCommand(res);
        }

    }
}
