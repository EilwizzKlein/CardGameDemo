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
        public OnAbilityAction AbilityAction { get; private set; }

        public IPower(string _description, int _maxUseTime, OnAbilityAction _action)
        {
            description = _description;
            maxUseTime = _maxUseTime;
            currentUseTime = _maxUseTime;
            AbilityAction = _action;
        }

        public void Reset()
        {
            currentUseTime = maxUseTime;
        }
        public void Activate(IEventObject ev)
        {
            if (currentUseTime > 0)
            {
                AbilityAction(ev);
                currentUseTime--;
            }
        }
    }

}
