using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface.Instance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public class IEventObject
    {
        public ICard? resCard; //来源卡
        public ICard[]? targetCard; //目标卡
        public IBattleGround? resBattleGround; //来源战场
        public IBattleGround[]? targetBattleGround; //目标战场
        public BattleGroundTileZone? resBattleGroundTileZone; //来源战场格
        public BattleGroundTileZone[]? targetBattleGroundTileZone; //来源战场格
        public IZone? resZone; //来源区域
        public IZone[]? targetZone; //目标区域
        public IPlayer? resPlayer; //来源玩家
        public IPlayer[]? targetPlayer; //目标玩家
        public Dictionary<string,string> resKeyValus = new Dictionary<string, string>(); //来源额外键值对
        public Dictionary<string, string> targetKeyValus = new Dictionary<string, string>(); //目标额外键值对
        public int modify =0; //修正值
    }
}
