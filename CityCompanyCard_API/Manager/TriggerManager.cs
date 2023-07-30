using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Manager
{
    internal class TriggerManager
    {
        private Dictionary<string, List<ITrigger>> triggers;
        public TriggerManager()
        {
            triggers = new Dictionary<string, List<ITrigger>>();
        }

        public void RegisterTrigger(ITrigger trigger, string tag)
        {
            if (!triggers.ContainsKey(tag))
            {
                triggers[tag] = new List<ITrigger>();
            }

            triggers[tag].Add(trigger);
        }

        public void UnregisterTrigger(string tag)
        {
            if (triggers.ContainsKey(tag))
            {
                triggers.Remove(tag);
            }
        }

        public void IteratorTrigger(IEventObject eventObject)
        {
            foreach (var kvp in triggers)
            {
                foreach (ITrigger trigger in kvp.Value)
                {
                    trigger.Run(eventObject);
                    if (trigger.deleteSelf)
                    {
                        kvp.Value.Remove(trigger);
                    }
                }
            }
        }
    }
}
