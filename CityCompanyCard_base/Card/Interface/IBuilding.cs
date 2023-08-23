using CityCompanyCard_API.Card;
using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.RenderObject;
using CityCompanyCard_base.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Card.Interface
{
    public class IBuilding : IInstanceCard
    {

        public IBuilding()
        {
            this.type = CardType.Building;
        }
        public void InitHealth(int value)
        {
            ((InstanceCardBO)originCardBO).maxHealth = value;
            ((InstanceCardBO)originCardBO).currentHealth = value;
            this.renderBuff();
        }
    }
}
