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
        public const string TEST_MODE = "test_mode";

        public static IMode GetModeByType(string mode)
        {
            if (mode == NORMAL_MODE)
            {
                return new NormalMode_ModeBO();
            }
            if (mode == TEST_MODE)
            {
                return new TestMode_ModeBO();
            }
            else
            {
                throw new Exception("未匹配到Mode对象");
            }
        }
    }
}
