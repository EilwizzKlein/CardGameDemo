using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityCompanyCard_base.Card.Command
{
    public class CommandSpecial : ICommandCard
    {
        public CommandSpecial() {
            name = "移动";
            id = "command_special"; //保证ID唯一 不和其他卡重复
        }
    }
}
