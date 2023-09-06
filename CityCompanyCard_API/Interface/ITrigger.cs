using CityCompanyCard_API.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    /// <summary>
    /// 触发器自定义类
    /// </summary>
    public  class ITrigger
    {
        private List<IAction> TriggerList = new List<IAction>();

        public void registerTrigger(IAction trigger)
        {
            TriggerList.Add(trigger);
        }

        public void unregisterrTrigger(IAction trigger)
        {
            TriggerList.Remove(trigger);
        }

        public List<IAction> GetActionByCard(ICard card)
        {
            return TriggerList.Where<IAction>(item=>item.resCard==card).ToList();
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
