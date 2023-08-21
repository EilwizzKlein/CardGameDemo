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
    public abstract class ISelector<T>
    {

        public abstract T[] onFilter(IEventObject ev);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ev"></param>
        /// <param name="output"></param>
        /// <returns>true-选中了 false-取消了</returns>
        public abstract void renderSeletor(IEventObject ev, T[] filter);

        public abstract void hideSelector();
        public abstract void showSelector();

        public abstract Boolean onSelector(IEventObject ev, T[] filter,out T[] output);


        /// <summary>
        /// 进行选择
        /// </summary>
        /// <param name="ev"></param>
        /// <returns>ture 完成筛选 false 失败</returns>
        public Boolean startISeletor(IEventObject ev, out T[] output)
        {
 
            Boolean isSucess = false;
            T[] selectOutput = null;
            ApplicationContext.Instance.SelectorThread = new Thread(() =>
            {
                T[] filter = onFilter(ev);
                // 子线程的逻辑，这里以计算值为例
                renderSeletor(ev, filter);
                while (!onSelector(ev, filter, out selectOutput)) { }
            });
            ApplicationContext.Instance.SelectorThread.Start();
            ApplicationContext.Instance.SelectorThread.Join();
            output = selectOutput;
            return output != null;
        }
    }
}
