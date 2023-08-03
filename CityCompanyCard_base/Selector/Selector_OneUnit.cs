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
    public class Selector_OneUnit : ISelector
    {
        int testTime = 0;
        public override bool handleSelector(in IEventObject ev)
        {
            //选择一个战场上的生物
            Console.WriteLine("选择一个有生物的格子");
            string title = Console.ReadLine();
            int index;
            if(Int32.TryParse(title,out index))
            {
                IZone tile = AppUtils.getMainBattleGroundTiles(index);
                IUnitCard unitCard = (IUnitCard)tile.cardList[0];
                ev.resZone = new IZone[] { tile };
                ev.resCard = new ICard[] { unitCard };
                return true;
            }
            else
            {
                testTime += 1;
                if (testTime >= 1) {
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
