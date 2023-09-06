﻿using CityCompanyCard_API.Card;
using CityCompanyCard_API.Dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.Player;
using CityCompanyCard_base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector.PanelSelector.UnitSeletor
{
    public class Selector_GatherUnitFilter<T> : Selector_ResUnit<T> where T : IInstanceCard
    {
        public override List<T> filterRule(IEventObject ev)
        {
            List<T> cards = AppUtils.getMainBattleGround().CardList.Where(card => card.controller == ev.resPlayer && card.type == CardType.Unit).OfType<T>().ToList();
			cards = cards.Where(card =>  card.HasPower("收集") == 1).ToList();
            if (ev.resPlayer.renderCard.HasPower("收集") == 1 && ev.resPlayer.renderCard is T) {
                cards.Add((T)ev.resPlayer.renderCard);
            }
			return cards;
        }

    }
}
