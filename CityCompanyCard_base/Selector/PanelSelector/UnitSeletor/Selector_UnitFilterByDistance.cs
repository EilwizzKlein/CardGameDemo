using CityCompanyCard_API.Card;
using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_API.Utils;
using CityCompanyCard_base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector.PanelSelector.UnitSeletor
{
    public class Selector_UnitFilterByDistance<T> : Selector_ResUnit<T> where T : IUnitCard
    {
        private int _distance = 1   ;
        public void setDistance(int distance) {
            _distance = distance;
        }
        public override List<T> filterRule(IEventObject ev)
        {
            //获取所有格子
            IZone zone = ((IUnitCard)ev.resCard).GetZone();
            List<T> cards = new List<T>();
            if (zone is BattleGroundTileZone)
            {
                IBattleGround battleGround = ((BattleGroundTileZone)zone).getResBattleGround();
                BattleGroundTileZone[] zones = BattleGroundUtils.GetBattleGroundTilesByDistance(battleGround, (BattleGroundTileZone)zone, _distance);
                foreach (BattleGroundTileZone item in zones)
                {
                    item.cardList.ForEach(card =>
                    {
                        if (card is T && card.controller != ev.resCard.controller)
                        {
                            cards.Add((T)card);
                        }
                    });
                }
            }

            //获取可以攻击的生物
            return cards;
        }

    }
}
