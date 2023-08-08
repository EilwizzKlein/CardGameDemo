using CityCompanyCard_API.Interface.BO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    /// <summary>
    /// 单个BUFF或者DEBUFF对象
    /// </summary>
    public abstract class IBuff
    {
        public Boolean isEternal; //在转移区域时是否需要清空
        public Boolean isTemp; //是否为临时buff
        public int stayCount; //持续计数


        public abstract void renderBuff(CardBO target);


        public abstract void OnUpdateBuff(CardBO target);
     
    

        public void UpdateBuff(CardBO target)
        {
            OnUpdateBuff(target);
        }

    }
}
