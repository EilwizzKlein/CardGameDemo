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
    public abstract class ICommandCard:ICard
    {

        public ICommandCard()
        {
            this.type = CardType.Command;
        }

        public abstract bool OnAsyncPlay(IEventObject eventObject);

        public override void OnPlay(IEventObject eventObject)
        {
            while (OnAsyncPlay(eventObject)) { };
        }

        public override void OnBeforePlay(IEventObject eventObject)
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
