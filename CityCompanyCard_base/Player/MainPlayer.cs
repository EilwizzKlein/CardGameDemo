using CityCompanyCard_API.Interface;
using CityCompanyCard_API.RenderObject;
using CityCompanyCard_API.Zone;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Player
{
    public class MainPlayer:IPlayer
    {
        public CommandZone command = new CommandZone();
        public int actionPoint;

        public override void OnPlayCard(IEventObject ev)
        {
            hand.cardList.Remove(ev.resCard);
        }

        public void ChooseCommand(ICommandCard card) {
            command.ChooseCommand(card);
        }

        public virtual bool beforeChosen(IEventObject ev)
        {
            return true;
        }

        public MainPlayer() {
            hand = new HandZone();
            grave = new IZone();
            deck = new IZone();
            mana = 2;
            actionPoint=5;
        }
    }
}
