using CityCompanyCard_API.BO;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.renderObject;
using CityCompanyCard_API.Zone;
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
        public renderInt actionPoint = new renderInt();
        public MainPlayer() {
            this.hand = new HandZone();
            this.grave = new IZone();
            this.deck = new IZone();
            actionPoint.init(5);
        }
    }
}
