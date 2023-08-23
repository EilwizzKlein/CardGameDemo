using CityCompanyCard_API;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Dictionary;
using CityCompanyCard_base.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Utils
{
    public class AppUtils
    {
    private ManagerFactory managerFactory = new ManagerFactory();
        public static IZone getBattleGroundTiles(string key,int index)
        {
            IBattleGround battleGround;
            bool flag  = ApplicationContext.Instance.BattleZone.TryGetValue(key, out battleGround);
            if(flag)
            {
                return battleGround.battleGrounds[index];
            }
            else
            {
                throw new Exception($"未查找到该key对应的battleground,{key}");
            }
        }

        public static IZone getMainBattleGroundTiles(int index)
        {
            return getBattleGroundTiles(BattlegroundConst.MAIN_BATTLE_GROUND, index);
        }

        public static IBattleGround getMainBattleGround()
        {
            return getBattleGround(BattlegroundConst.MAIN_BATTLE_GROUND);
        }

        public static IBattleGround getBattleGround(string key)
        {
            IBattleGround battleGround;
            bool flag = ApplicationContext.Instance.BattleZone.TryGetValue(key, out battleGround);
            if (flag)
            {
                return battleGround!;
            }
            else
            {
                throw new Exception($"未查找到该key对应的battleground,{key}");
            }
        }

    }
}
