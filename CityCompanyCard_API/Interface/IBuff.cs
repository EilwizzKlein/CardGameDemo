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
        /// <summary>
        /// 在转移区域时是否需要清空
        /// </summary>
        public Boolean isEternal;

        /// <summary>
        /// 是否为临时buff
        /// </summary>
        public Boolean isTemp;

        /// <summary>
        /// 持续计数
        /// </summary>
        public int stayCount;


        public abstract void renderBuff(CardBO target);


        public abstract void OnUpdateBuff(CardBO target);
     
    

        public virtual void UpdateBuff(IBuff newBuff,CardBO target)
        {
            OnUpdateBuff(target);
        }

    }
}
