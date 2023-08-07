using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public abstract class IFliter<T>
    {
        public abstract List<T> runFliter(IEventObject ev);
    }
}
