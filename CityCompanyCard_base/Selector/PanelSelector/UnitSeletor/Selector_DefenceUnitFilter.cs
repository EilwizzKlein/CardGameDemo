﻿using CityCompanyCard_API.Card;
using CityCompanyCard_API.Dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector.PanelSelector.UnitSeletor
{
    public class Selector_DefenceUnitFilter<T> : Selector_ResUnit<T> where T : IUnitCard
    {
        public override List<T> filterRule(IEventObject ev)
        {
            //获取可以防御的生物
            List<T> cards = AppUtils.getMainBattleGround().CardList.Where(card => card.controller == ev.resPlayer && card.type == CardType.Unit).OfType<T>().ToList();
            //获取未激活 或者 有防御能力未使用的
            cards = cards.Where(card => card.HasPower("防御") == 1).ToList();
            return cards;
        }

    }
}
