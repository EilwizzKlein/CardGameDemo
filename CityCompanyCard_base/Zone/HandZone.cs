using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityCompanyCard_API.Interface;

namespace CityCompanyCard_API.Zone
{
    public class HandZone:IZone
    {
        public HandZone()
        {
            this.max = 5;
        }
    }
}
