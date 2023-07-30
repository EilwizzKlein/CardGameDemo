using System;
using System.Collections.Generic;
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

     
        public abstract void OnGainBuff(Object target);

        public abstract void OnRemoveBuff(Object target);

        public virtual void OnTurnEnd(Object target) {
            if (isTemp)
            {
                if (stayCount-- == 0) {
                    OnRemoveBuff(target);
                }
            }
        }
    }
}
