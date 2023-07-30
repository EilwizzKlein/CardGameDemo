using CityCompanyCard_API;
using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Mode
{
    public class ModeFactory
    {
        public const string NORMAL_MODE = "normal_mode";


        public static IMode GetModeByType(string mode)
        {
            if (mode == ModeFactory.NORMAL_MODE)
            {
                return new NormalMode_ModeBO();
            }
            else {
                throw new Exception("未匹配到Mode对象");
            }
        }
    }
}
