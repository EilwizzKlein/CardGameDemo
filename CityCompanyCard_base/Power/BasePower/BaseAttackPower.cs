using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Power.BasePower
{
    public class BaseAttackPower : IBasePower
    {
        public BaseAttackPower(string _description, int _maxUseTime) : base(_description, _maxUseTime)
        {
            this.baseName = "攻击";
        }
        public override void AbilityAction(IEventObject ev) {
            //选择进攻目标

            //结束进攻效果
        }
    }
}
