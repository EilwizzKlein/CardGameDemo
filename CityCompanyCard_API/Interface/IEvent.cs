using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    /// <summary>
    /// 配合触发器类使用,事件类
    /// </summary>
    public class IEvent
    {
        private List<ITrigger> TriggerList = new List<ITrigger>();

        public void registerTrigger(ITrigger trigger) {
            TriggerList.Add(trigger);
        }

        public void unregisterrTrigger(ITrigger trigger) { 
            TriggerList.Remove(trigger);
        }

        public void runEvent(IEventObject ev)
        {
            TriggerList.ForEach(t =>
            {
                t.Run(ev);
            });
        }
    }
}
