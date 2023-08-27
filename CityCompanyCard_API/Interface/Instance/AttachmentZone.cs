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
        //不生效附属(比如因为某些效果而加在一张卡上面的卡牌)
        public Dictionary<String, List<ICard>> uneffectAttachment = new Dictionary<String, List<ICard>>();
    }
}
