using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Manager
{
    public class StateManager
    {
        public static void ChangeState(IState state)
        {
            IState preNext = state.GotoNextState();
            while (!preNext.BeforeChangeState(out preNext)) ;
            preNext.ChangeToState();
            ApplicationContext.Instance.SetCurrentState(preNext);
        }
    }
}
