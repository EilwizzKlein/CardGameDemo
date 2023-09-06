using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.BO;
using CityCompanyCard_base.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Buff
{

    public class DamageBuff : IBuff
    {
        public int damageValue;
        public DamageBuff getDamage(int damage)
        {
            DamageBuff db = new DamageBuff();
            db.damageValue = damageValue + damage;
            return db;
        }

        public override void UpdateBuff(IBuff newBuff, CardBO target)
        {
            base.UpdateBuff(newBuff, target);
            if (newBuff is DamageBuff)
            {
                int damage = ((DamageBuff)newBuff).damageValue - damageValue;
                ((InstanceCardBO)target).currentHealth -= damage;
            }
        }
        public override void renderBuff(CardBO target)
        {
            ((InstanceCardBO)target).currentHealth -= this.damageValue;
        }

        public override void OnUpdateBuff(CardBO target)
        {
            throw new NotImplementedException();
        }
    }
}
