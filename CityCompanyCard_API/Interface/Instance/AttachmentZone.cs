using CityCompanyCard_API.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface.Instance
{
    public class AttachmentZone
    {
        public IZone attactmentZone = new IZone();
        public List<ICard> effectAttachment = new List<ICard>();
        public Dictionary<String, List<ICard>> uneffectAttachment = new Dictionary<String, List<ICard>>();
    }
}
