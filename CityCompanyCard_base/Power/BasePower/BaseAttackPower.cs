﻿using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Selector.PanelSelector.UnitSeletor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Power.BasePower
{
    public class BaseAttackPower : IBasePower
    {
        public BaseAttackPower(string _description, int _maxUseTime) : base(_description, _maxUseTime)
        {
            this.baseName = "攻击";
        }
        public override void AbilityAction(IEventObject ev) {
            IUnitCard res = ev.resCard as IUnitCard;
            //选择进攻目标
            new Selector_UnitFilterByDistance<IUnitCard>().startISeletor(ev, out IUnitCard[] cards);
            if(cards != null && cards.Length>0) {
                //结算进攻
                ev.targetCard = cards;
                Console.WriteLine($"{ev.resCard.controller.name}的{ev.resCard.renderCardBO.name} 对 {ev.targetCard[0].controller.name}的{ev.targetCard[0].renderCardBO.name}造成了1点伤害");
            }
            //结束进攻效果
        }
    }
}
