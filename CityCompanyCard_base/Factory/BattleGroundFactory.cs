using CityCompanyCard_API.Interface;
using CityCompanyCard_base.BattleGround;
using CityCompanyCard_base.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Factory
{
    public class BattleGroundFactory
    {


        public static IBattleGround GetBattleGroundByType(string mode)
        {
            return GetBattleGroundByType(mode, mode);
        }
        public static IBattleGround GetBattleGroundByType(string mode, string name)
        {
            IBattleGround battleGround = null;
            if (mode == BattlegroundConst.MAIN_BATTLE_GROUND)
            {
                battleGround = new MainBattleGround();
            }
            else
            {
                throw new Exception("未匹配到Mode对象");
            }
            battleGround.name = name;
            battleGround.Init();
            return battleGround;
        }
    }
}
