using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.RenderObject;
using CityCompanyCard_base.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Card
{
    public class IUnitCard : ICard
    {
        public IUnitCard()
        {
            this.originCardBO = new UnitCardBO();
            this.renderCardBO = originCardBO.clone();
            this.type = CardType.Unit;
        }

        public override void OnPlay(IEventObject eventObject)
        {
            //打出卡牌
        }

        public void InitAttack(int value)
        {
            ((UnitCardBO)originCardBO).maxAttack = value;
            ((UnitCardBO)originCardBO).currentAttack = value;
            this.renderBuff();
        }
        public void InitHealth(int value)
        {
            ((UnitCardBO)originCardBO).maxHealth = value;
            ((UnitCardBO)originCardBO).currentHealth = value;
            this.renderBuff();
        }

        public override void OnAfterPlay(IEventObject eventObject)
        {
            throw new NotImplementedException();
        }
    }
}
