using CityCompanyCard_API.Card;
using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector.PanelSelector
{
    public class Selector_ResUnitFactory
    {
        
        private Selector_ResUnit<IUnitCard> GetCanMoveUnitFilter = null;
        private Selector_ResUnit<IUnitCard> GetCanGatherUnitFilter = null;
        
        public Selector_ResUnitFactory() {
            GetCanMoveUnitFilter = new Selector_ResUnit<IUnitCard>(OnCanMoveUnitFilter);
            GetCanGatherUnitFilter = new Selector_ResUnit<IUnitCard>(OnCanGatherUnitFilter);
        }

        /// <summary>
        /// 获取过滤能移动的物体的弹窗
        /// </summary>
        public  Selector_ResUnit<IUnitCard> get_GetCanMoveUnitFilter () { return GetCanMoveUnitFilter; }
        public Selector_ResUnit<IUnitCard> get_GetCanGatherUnitFilter() { return GetCanGatherUnitFilter; }
        

        private List<IUnitCard> OnCanMoveUnitFilter(IEventObject ev)
        {
            List<IUnitCard> cards = AppUtils.getMainBattleGround().CardList.Where(card => card.controller == ev.resPlayer && card.type == CardType.Unit).OfType<IUnitCard>().ToList();
            return cards;
        }

        private List<IUnitCard> OnCanGatherUnitFilter(IEventObject ev)
        {
            List<IUnitCard> cards = AppUtils.getMainBattleGround().CardList.Where(card => card.HasPower("收集") > 0).OfType<IUnitCard>().ToList();
            return cards;
        }

    }
}
