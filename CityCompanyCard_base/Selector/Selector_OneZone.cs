using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector
{
    public class Selector_OneZone : ISelector
    {
        public override bool handleSelector(IEventObject ev)
        {
            return true;
        }
    }
}
