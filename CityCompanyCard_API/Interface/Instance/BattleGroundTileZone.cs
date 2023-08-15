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
        internal int _poxition_x;
        internal int _poxition_y;
        private IBattleGround? _resBattleGround;

        public BattleGroundTileZone(int index, IBattleGround? resBattleGround)
        {
            _index = index;
            _resBattleGround = resBattleGround;
        }

        internal void setPosition(int x, int y) { 
            this._poxition_x = x;
            this._poxition_y = y;
        }

        public int getIndex()
        {
            return _index;
        }

        public int getPositionX()
        {
            return _poxition_x;
        }

        public int getPositionY(){
            return _poxition_y;
        }

        public IBattleGround getResBattleGround()
        {
            return _resBattleGround;
        }
    }
}
