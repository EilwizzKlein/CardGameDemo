using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.BO
{
    public class UnitCardBO:CardBO
    {
        public int maxHealth;
        public int currentHealth;
        public int maxAttack;
        public int currentAttack;

        public override CardBO clone()
        {
            UnitCardBO bo = new UnitCardBO(); 
            bo.maxHealth = maxHealth;
            bo.currentHealth = currentHealth;
            bo.maxAttack= maxAttack;
            bo.currentAttack = currentAttack;
            return bo;
        }
    }
}
