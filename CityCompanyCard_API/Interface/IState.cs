using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    /// <summary>
    /// 状态机抽象类
    /// 状态机生命周期
    /// BeforeChangeState =>进入该状态前=>返回一个State
    /// ChangeToState =>进入该状态前
    /// </summary>
    public abstract class IState
    {
        public string name = "";
        public abstract IState GotoNextState();
        public abstract void ChangeToState();
        public abstract Boolean BeforeChangeState(out IState next);
            
    }
}
