using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    /// <summary>
    /// 目标选择器抽象类
    /// </summary>
    public abstract class ISelector
    {
        public abstract Boolean handleSelector(in IEventObject ev);

        /// <summary>
        /// 进行选择
        /// </summary>
        /// <param name="ev"></param>
        /// <returns>ture 完成筛选 false 失败</returns>
        public Boolean startISeletor(IEventObject ev)
        {
            Boolean isSucess = false;
            ApplicationContext.Instance.SelectorThread = new Thread(() =>
            {
                // 子线程的逻辑，这里以计算值为例
                isSucess = handleSelector(in ev);
            });
            ApplicationContext.Instance.SelectorThread.Start();
            ApplicationContext.Instance.SelectorThread.Join();
            return isSucess;
        }
    }
}
