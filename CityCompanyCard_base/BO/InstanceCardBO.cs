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

            baseBo.name = name;
            baseBo.cost = cost;
            baseBo.type = type;
            baseBo.subType = new List<string>(subType);
            baseBo.tag = new List<string>(subType);
            baseBo.exCost = new Dictionary<string, int>(exCost);
            baseBo.effect = new String(effect);

            ((InstanceCardBO)baseBo).maxHealth = maxHealth;
            ((InstanceCardBO)baseBo).currentHealth = currentHealth;
            ((InstanceCardBO)baseBo).maxAttack = maxAttack;
            ((InstanceCardBO)baseBo).currentAttack = currentAttack;

            return baseBo;
        }
    }
}
