using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityCompanyCard_base.Card.Command
{
    public class CommandMove:ICommandCard
    {
        public CommandMove() {
            name = "移动";
            id = "command_move"; //保证ID唯一 不和其他卡重复
        }
    }
}
