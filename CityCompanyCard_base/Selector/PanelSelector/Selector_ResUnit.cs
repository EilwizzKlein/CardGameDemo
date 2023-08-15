using CityCompanyCard_API.Card;
using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector.PanelSelector
{
    public class Selector_ResUnit<T> : BasePanelSeletor<T> where T : IUnitCard

    {
        public override T[] onFliter(IEventObject ev)
        {
            //搜索场上的目标玩家生物
            List<ICard> cards = AppUtils.getMainBattleGround().CardList.Where(card => card.controller == ev.resPlayer && card.type == CardType.Unit).ToList();
            if (cards.Count > 0)
            {
                return cards.OfType<T>().ToArray();
            }
            else
            {
                return new T[] { };
            }
        }

        public override void rendFliter(T fliterItem, int index)
        {
            Console.WriteLine($"{index}:{fliterItem.renderCardBO.name},所在区域格序号为{((BattleGroundTileZone)fliterItem.GetZone()).getIndex()}");
        }
    }
}
