using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CityCompanyCard_API.Interface
{
    public class IPower
    {
        public string description;
        private int maxUseTime;
        public int currentUseTime;
        public delegate void OnAbilityAction(IEventObject ev);
        public virtual OnAbilityAction onAbilityAction { get;  set; }

        public IPower(string _description, int _maxUseTime, OnAbilityAction _action)
        {
            description = _description;
            maxUseTime = _maxUseTime;
            currentUseTime = _maxUseTime;
            onAbilityAction = _action;
        }

        public IPower(string _description, int _maxUseTime)
        {
            description = _description;
            maxUseTime = _maxUseTime;
            currentUseTime = _maxUseTime;
        }

        public void Reset()
        {
            currentUseTime = maxUseTime;
        }
        public void Activate(IEventObject ev)
        {
            if (currentUseTime > 0)
            {
                onAbilityAction(ev);
                currentUseTime--;
            }
        }
    }

}
