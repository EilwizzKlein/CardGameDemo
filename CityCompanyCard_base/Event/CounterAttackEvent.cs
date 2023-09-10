using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Event
{
    public class CounterAttackEvent : IEvent
    {
        public CounterAttackEvent(IEventObject eventObject) : base(eventObject)
        {
        }

        public override void OnRun(IEventObject ev, bool isRoot)
        {
        }
    }
}
