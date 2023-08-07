using CityCompanyCard_API.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public class IEventObject
    {
        public string type = "";
        public object? res; //来源

        public ICard[]? resCard; //来源卡
        public ICard[]? targetCard; //目标卡
        public IBattleGround[]? resBattleGround; //来源战场
        public IBattleGround[]? targetBattleGround; //来源战场
        public IZone[]? resZone; //来源区域
        public IZone[]? targetZone; //目标区域
        public IPlayer[]? resPlayer; //来源玩家
        public IPlayer[]? targetPlayer; //目标玩家
        public Object[]? resObjects; //来源额外对象
        public Object[]? targetObjects; //目标对象
    }
}
