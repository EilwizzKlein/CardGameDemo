using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.BO;
using CityCompanyCard_base.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static CityCompanyCard_API.Card.IUnitCard;

namespace CityCompanyCard_base.Buff
{
    public class GainAttackTempBuff : IBuff
    {
        public int attackValue;

        public GainAttackTempBuff(int attackValue, int stay)
        {
            this.isEternal = false;
            this.isTemp = true;
            this.stayCount = stay;
            this.attackValue = attackValue;
        }

        public override void OnUpdateBuff(CardBO target)
        {
            
        }

        public override void renderBuff(CardBO target)
        {
            ((InstanceCardBO)target).maxAttack += this.attackValue;
            ((InstanceCardBO)target).currentAttack += this.attackValue;
        }

        public override void OnAddBuff(CardBO target)
        {
            ((InstanceCardBO)target).maxAttack += this.attackValue;
            ((InstanceCardBO)target).currentAttack += this.attackValue;
        }
    }
}
