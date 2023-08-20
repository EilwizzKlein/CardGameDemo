using CityCompanyCard_API;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.State
{
    public class State_ActionState : IState
    {
        public override bool BeforeChangeState(out IState next)
        {
            next = this;
            return true;
        }

        public override void ChangeToState()
        {
         
        }

        public override IState GotoNextState()
        {
            return new State_TurnEnd();
        }
    }
}
