﻿using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Card.Unit
{
    [Serializable]
    public class Unit_Farmer:IUnitCard
    {
        public Unit_Farmer()
        {
            this.originCardBO.name = "农民";
            this.id = "test_farmer"; //保证ID唯一 不和其他卡重复
            this.originCardBO.cost = 1; //费用
            this.InitAttack(1); //攻击力
            this.InitHealth(2); //血量
            this.originCardBO.subType.Add(CardConst.unitSubtype.HUMAN); //子类别,一般在Subtype中找
            //this.exCost.Add(CardConst.exCostType.FOOD, 1); //额外费用
            this.originCardBO.effect = "测试"; //效果文本
            this.AddPower("收集", new IPower("[收集:1]获取1点食物", 1, this.OnAbilityAction));
        }

        private void OnAbilityAction(IEventObject ev) { 
        
        }

        public override void OnAfterDraw(IEventObject eventObject)
        {
            base.OnAfterDraw(eventObject);
            Console.WriteLine("你抽到了我,现在我要鲨了你");
        }
    }
}
