using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_mod.Card.UnitCard
{
    public class UnitCard_PoorFarmer:IUnitCard
    {
        public UnitCard_PoorFarmer()
        {
            this.originCardBO.name = "可怜的农夫";
            this.id = "test_demo"; //保证ID唯一 不和其他卡重复
            this.originCardBO.cost = 1; //费用
            this.InitAttack(0); //攻击力
            this.InitHealth(2); //血量
            this.originCardBO.subType.Add(CardConst.unitSubtype.HUMAN); //子类别,一般在Subtype中找
            //this.exCost.Add(CardConst.exCostType.FOOD, 1); //额外费用
            this.originCardBO.effect = "[收集:1]获取1点食物"; //效果文本
            this.AddPower("收集", new IPower("[收集:1]获取1点食物", 1, this.OnAbilityAction));
        }

        private void OnAbilityAction(IEventObject ev)
        {
            int baseValue = 1;
            baseValue += ev.modify;
            //获取修正值
            this.controller.GainExMana(CardConst.exCostType.FOOD, baseValue);
        }
    }
}
