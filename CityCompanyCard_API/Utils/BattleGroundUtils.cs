using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Instance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Utils
{
    public class BattleGroundUtils
    {
        /// <summary>
        /// 根据距离获取指定的格子(不包括自己)
        /// </summary>
        /// <param name="battleground">战场</param>
        /// <param name="index">格子的序号</param>
        /// <param name="distance">距离</param>
        /// <returns></returns>
        public static BattleGroundTileZone[] GetBattleGroundTilesByDistance(IBattleGround battleground, BattleGroundTileZone resTile, int distance) {
            if(battleground.battleGrounds is null)
            {
                return new BattleGroundTileZone[] { };
            }
            if (distance == 0) {
                return new BattleGroundTileZone[] { };
            }
            int x = resTile._poxition_x;
            int y = resTile._poxition_y;
            return battleground.battleGrounds.Where<BattleGroundTileZone>(item => (Math.Abs(item._poxition_x - x) + Math.Abs(item._poxition_y - y)) <= distance && item.getIndex() != resTile.getIndex()).ToArray();

     
        }
    }
}
