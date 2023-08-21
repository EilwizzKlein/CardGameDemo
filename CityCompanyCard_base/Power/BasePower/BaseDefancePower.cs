using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Power.BasePower
{
    public class BaseDefancePower : IBasePower
    {
        public BaseDefancePower(string _description, int _maxUseTime) : base(_description, _maxUseTime)
        {
            this.baseName = "防御";
        }
        public override void AbilityAction(IEventObject ev) {
            Console.WriteLine($"{ev.resCard.renderCardBO.name}:该生物进入防御状态");
            //选择进攻目标

            //结束进攻效果
        }
    }
}
