using CityCompanyCard_API.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Card.Interface
{
    public class ISpell:INotInstanceCard
    {
        public ISpell()
        {
            this.type = CardType.Spell;
        }
    }
}
