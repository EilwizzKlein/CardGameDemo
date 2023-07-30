using CityCompanyCard_API.BattleGround;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.BattleGround
{
    public class BattleGroundFactory
    {
        public const string MAIN_BATTLE_GROUND = "mainBattleGround";

        public static IBattleGround GetBattleGroundByType(string mode) {
            return GetBattleGroundByType(mode, mode);
        }
        public static IBattleGround GetBattleGroundByType(string mode,string name)
        {
            IBattleGround battleGround = null;
            if (mode == BattleGroundFactory.MAIN_BATTLE_GROUND)
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
