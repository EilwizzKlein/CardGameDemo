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

        public void chooseCommand(ICommandCard card) {
            command.chooseCommand(card);
        }
        public MainPlayer() {
            this.hand = new HandZone();
            this.grave = new IZone();
            this.deck = new IZone();
            actionPoint=5;
        }
    }
}
