using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
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

        public override void OnGainBuff(object target)
        {
            if (target is IUnitCard)
            {
                IUnitCard temp = (IUnitCard)target;
                temp.attack.addValue(attackValue);
            }
        }

        private int Handle(in int value)
        {
            Console.WriteLine("测试"+attackValue.ToString());
            return value + attackValue;

        }

        public override void OnRemoveBuff(object target)
        {
            if (target is IUnitCard)
            {
                IUnitCard temp = (IUnitCard)target;
                temp.attack.reduceValue(attackValue);
            }
        }
    }
}
