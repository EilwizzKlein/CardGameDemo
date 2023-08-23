using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.BO
{
    public class InstanceCardBO:CardBO
    {
        public int maxHealth;
        public int currentHealth;
        public int maxAttack;
        public int currentAttack;

        public override CardBO clone()
        {
            CardBO baseBo = new InstanceCardBO();
            baseBo = base.clone();
            if (baseBo is InstanceCardBO bo) // 检查是否能将 Animal 引用转换为 Dog 对象
            {
                bo.maxHealth = maxHealth;
                bo.currentHealth = currentHealth;
                bo.maxAttack = maxAttack;
                bo.currentAttack = currentAttack;
                return bo;
            }         
            return baseBo;
        }
    }
}
