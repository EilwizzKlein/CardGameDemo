using CityCompanyCard_API.BO;
using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Card
{
    [Serializable]
    public class IUnitCard : ICard
    {
        public renderModelBO attack = new renderModelBO();
        public renderModelBO health = new renderModelBO();
        public delegate int AttackDelegate(in int item);
        public IUnitCard()
        {
            this.type = CardType.Unit;
            this.hasInstance = true;
        }

        public override void OnPlay(IEventObject eventObject)
        {
            //打出卡牌
        }

        public override ICard Clone()
        {
            IUnitCard card = (IUnitCard)base.Clone();
            return card;
        }

        public void InitAttack(int value)
        {
            attack.init(value);
        }
        public void InitHealth(int value)
        {
            health.init(value);
        }

        public override void OnAfterPlay(IEventObject eventObject)
        {
            throw new NotImplementedException();
        }
    }
}
