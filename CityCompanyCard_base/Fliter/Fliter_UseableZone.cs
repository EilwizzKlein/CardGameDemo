using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Fliter
{
    /// <summary>
    /// 过滤有目标玩家的单位的格子
    /// </summary>
    /// <typeparam name="IZone"></typeparam>
    public class Fliter_HasPlayerUnitZone<T> : IFliter<T> where T : IZone
    {
        public override List<T> runFliter(IEventObject ev)
        {
            //获取玩家
            if(ev.resPlayer != null)
            {
                IPlayer player = ev.resPlayer;
                List<T> zones = new List<T>();
                //获取当前战场上所有格子
               List<ICard> battleground = AppUtils.getMainBattleGround().CardList;
                for (int i =0; i < battleground.Count; i++)
                {
                    if (battleground[i].renderCardBO.controller == player) {
                        if (!zones.Contains(battleground[i].GetZone()))
                        {
                            zones.Add((T)battleground[i].GetZone());
                        }
                        
                    }
                }

                    return zones;
            }
            else
            {
                return new List<T> { };
            }

        }
    }
}
