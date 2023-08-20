using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.State
{
    public class State_TurnStart : IState
    {
        public override bool BeforeChangeState(out IState next)
        {
            //结算回合开始事件
            next = this;
            return true;
        }

        public override void ChangeToState()
        {
            //当前回合玩家重置           
            StateManager.ChangeState(this);
        }

        public override IState GotoNextState()
        {
            return new State_DrawState();
        }
    }
}
