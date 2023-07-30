using CityCompanyCard_API.Card;
using CityCompanyCard_base.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Card.Unit
{
    [Serializable]
    public class Unit_Demo : IUnitCard
    {
        public Unit_Demo()
        {
            this.name = "测试";
            this.id = "test_demo"; //保证ID唯一 不和其他卡重复
            this.cost = 1; //费用
            this.InitAttack(1); //攻击力
            this.InitHealth(2); //血量
            this.subType.Add(CardConst.unitSubtype.HUMAN); //子类别,一般在Subtype中找
            //this.exCost.Add(CardConst.exCostType.FOOD, 1); //额外费用
            this.effect = "测试"; //效果文本
        }
    }
}
