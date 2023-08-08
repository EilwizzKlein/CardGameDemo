using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityCompanyCard_base.Card.Command
{
    public class CommandDefence:ICommandCard
    {
        public CommandDefence() {
            this.originCardBO.name = "防御";
            id = "command_defence"; //保证ID唯一 不和其他卡重复
        }
    }
}
