using CityCompanyCard_API.Interface;
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

        public virtual void AbilityAction(IEventObject ev) { }
    }
}
