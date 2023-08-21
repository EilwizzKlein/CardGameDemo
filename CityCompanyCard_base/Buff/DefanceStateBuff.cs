using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.BO;
using CityCompanyCard_base.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Buff
{
    /// <summary>
    /// 防御姿态buff
    /// </summary>
    public class DefanceStateBuff : IBuff
    {

        public DefanceStateBuff( int stay)
        {
            this.isEternal = true;
            this.isTemp = false;
            this.stayCount = -1;
        }
        public override void OnUpdateBuff(CardBO target)
        {
        }

        public override void renderBuff(CardBO target)
        {
            //给这张卡加上防御姿态buff
            if (!target.tag.Contains("防御姿态")) {
                target.tag.Add("防御姿态");
            }
        }
    }
}
