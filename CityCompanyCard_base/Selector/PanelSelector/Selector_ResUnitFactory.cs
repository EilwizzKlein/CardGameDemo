using CityCompanyCard_API.Card;
using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Selector.PanelSelector.UnitSeletor;
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
        
        private Selector_ResUnit<IUnitCard> GetCanMoveUnitFilter = new Selector_MoveUnitFilter<IUnitCard>();
        private Selector_ResUnit<IUnitCard> GetCanGatherUnitFilter = new Selector_GatherUnitFilter<IUnitCard>();
        private Selector_ResUnit<IUnitCard> GetCanDefenceUnitFilter = new Selector_DefenceUnitFilter<IUnitCard>();
        private Selector_ResUnit<IUnitCard> GetCanAttackUnitFilter = new Selector_AttackUnitFilter<IUnitCard>();
        private Selector_ResUnit<IUnitCard> GetCanSpecailUnitFilter = new Selector_SpecialUnitFilter<IUnitCard>();

        public Selector_ResUnit<IUnitCard> getGetCanMoveUnitFilter()
        {
            return GetCanMoveUnitFilter;
        }

        public Selector_ResUnit<IUnitCard> getGetCanGatherUnitFilter()
        {
            return GetCanGatherUnitFilter;
        }

        public Selector_ResUnit<IUnitCard> getGetCanDefenceUnitFilter()
        {
            return GetCanDefenceUnitFilter;
        }

        public Selector_ResUnit<IUnitCard> getGetCanAttackUnitFilter()
        {
            return GetCanAttackUnitFilter;
        }

        public Selector_ResUnit<IUnitCard> getGetCanSpecailUnitFilter()
        {
            return GetCanSpecailUnitFilter;
        }

    }
}
