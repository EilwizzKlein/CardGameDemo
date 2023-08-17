using CityCompanyCard_API.Card;
using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Card.Interface
{
    public class ICommandCard:ICard
    {

        public ICommandCard()
        {
            this.type = CardType.Command;
        }

        public override void OnPlay(IEventObject eventObject)
        {
        }


        public override void OnAfterPlay(IEventObject eventObject)
        {
        }

        public override void OnBeforeDraw(IEventObject eventObject)
        {
        }

        public override void OnAfterDraw(IEventObject eventObject)
        {
        }
    }
}
