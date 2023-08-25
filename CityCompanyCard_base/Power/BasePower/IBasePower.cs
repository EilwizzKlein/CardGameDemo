using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Power.BasePower
{
    public class IBasePower : IPower
    {
        public string baseName = "";
        public IBasePower(string _description, int _maxUseTime) : base(_description, _maxUseTime)
        {
            onAbilityAction = AbilityAction;
        }

        public virtual void AbilityAction(IEventObject ev){
            //清理原有的ev
            if (ev.resKeyValus.ContainsKey(EventObjectExtractKey.POWER_NAME))
            {
                ev.resKeyValus[EventObjectExtractKey.POWER_NAME] = baseName;
            }
            else
            {
                ev.resKeyValus.Add(EventObjectExtractKey.POWER_NAME, baseName);
            }
        }
    }
}
