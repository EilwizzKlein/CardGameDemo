using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface.Instance
{
    public class BattleGroundTileZone:IZone
    {
        private int _index;
        private IBattleGround? _resBattleGround;

        public BattleGroundTileZone(int index, IBattleGround? resBattleGround)
        {
            _index = index;
            _resBattleGround = resBattleGround;
        }

        public int getIndex (){
            return _index;
        }

        public IBattleGround getResBattleGround()
        {
            return _resBattleGround;
        }
    }
}
