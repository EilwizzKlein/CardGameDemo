using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityCompanyCard_base.Card.Command
{
    public class CommandAttack:ICommandCard
    {
        public CommandAttack() {
            this.originCardBO.name = "攻击";
            id = "command_attack"; //保证ID唯一 不和其他卡重复
        }

        public override bool OnAsyncPlay(IEventObject eventObject)
        {
            return true;
        }
    }
}
