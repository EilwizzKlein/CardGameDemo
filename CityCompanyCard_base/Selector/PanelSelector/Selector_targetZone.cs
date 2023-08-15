using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_API.Utils;
using CityCompanyCard_base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector.PanelSelector
{
    public class Selector_targetZone<T> : BasePanelSeletor<T> where T : BattleGroundTileZone
    {
        public override T[] onFliter(IEventObject ev)
        {
            if (ev.resCard is null) { 
                return new T[] { };
            }
            //获取当前卡牌
            BattleGroundTileZone battle = (BattleGroundTileZone)((IUnitCard)ev.resCard).GetZone();
            Console.WriteLine($"当前区域格({battle.getPositionX()},{battle.getPositionY()})");
            return (T[])BattleGroundUtils.GetBattleGroundTilesByDistance(battle.getResBattleGround(), battle, 1);
        }


        public override void rendFliter(T filterItem, int index)
        {
            Console.WriteLine($"{index}:目标区域格({filterItem.getPositionX()},{filterItem.getPositionY()})");
        }
    }
}
