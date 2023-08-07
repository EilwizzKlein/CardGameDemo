using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector
{
    public class Selector_targetZone : ISelector
    {
        int testTime = 0;
        public override bool handleSelector(in IEventObject ev)
        {
            Console.WriteLine("选择目标的格子");
            string title = Console.ReadLine();
            int index;
            if (Int32.TryParse(title, out index))
            {
                IZone tiles = AppUtils.getMainBattleGroundTiles(index);
                ev.targetZone = new IZone[] { tiles };
                return true;
            }
            else
            {
                testTime += 1;
                if (testTime >= 1)
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("index解析有误,请重新输入");
                    return handleSelector(ev);
                }
            }
        }
    }
}
