using CityCompanyCard_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public class IPlayer
    {
        public IZone hand;
        public IZone deck;
        public IZone grave;
        private string UUID = Guid.NewGuid().ToString();
        public string ID;
        public string Name;

        public string getUUID() { return UUID; }

    }
}
