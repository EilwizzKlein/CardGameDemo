using CityCompanyCard_API;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.State
{
    public class State_TurnEnd : IState
    {
        public override bool BeforeChangeState(out IState next)
        {
            next = this;
            return true;
        }

        public override void ChangeToState()
        {
            //结算回合结束事件
            //切换玩家
            ApplicationContext.Instance.changeNextPlayer();
            StateManager.ChangeState(this);
        }

        public override IState GotoNextState()
        {
            return new State_TurnStart();
        }
    }
}
