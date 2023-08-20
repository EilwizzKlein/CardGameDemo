using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface.dictionary;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_API.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public class IPlayer
    {
        public IZone hand = new IZone();
        public IZone deck = new IZone();
        public IZone grave = new IZone();
        private string UUID = Guid.NewGuid().ToString();
        public string ID = "";
        public string name = "";
        public int mana;
        public int maxMana = 0;
        public Dictionary<string, int> exMana = new Dictionary<string, int>();
        private List<IBuff> buffs = new List<IBuff>();
        private AttachmentZone attachmentZone = new AttachmentZone();
        public string getUUID() { return UUID; }

        public virtual void DrawCard(int cardNumber) {
            IEventObject eventObject = new IEventObject();
            eventObject.resPlayer = this;
            eventObject.resKeyValus.Add(EventObjectExtractKey.DRAW_CARD_NUMBER, cardNumber.ToString());
            EventHandlerManager.DrawCard(eventObject);
        }

    }
}
