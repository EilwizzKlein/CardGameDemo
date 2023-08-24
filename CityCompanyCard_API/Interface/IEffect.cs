using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public class IEffect
    {
        public delegate void OnEffect(IEventObject ev);

        public OnEffect onEffect = (IEventObject ev) => { };
        public IEventObject? ev;
        public void run()
        {
            if(ev == null) { return; }
            onEffect(ev);
        }
    }
}
