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
    public abstract class IEvent
    {
        private IEventObject eventObject;
        public abstract void Run(IEventObject ev, Boolean isRoot);

        public void Run(IEventObject ev) {
            Run(ev, true);
        }

        public void Run()
        {
            Run(eventObject, false);
        }

        public IEvent(IEventObject eventObject)
        {
            this.eventObject = new IEventObject(eventObject);
        }   
    }
}
