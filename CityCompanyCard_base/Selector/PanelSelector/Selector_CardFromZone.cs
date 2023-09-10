using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector.PanelSelector
{
    public class Selector_CardFromZone<T> : BasePanelSeletor<T> where T : ICard
    {
        public override T[] onFilter(IEventObject ev)
        {
            IZone zone = ev.resZone;
            if(zone == null)
            {
                return new T[] { };
            }
            return (T[])zone.cardList.ToArray();
        }

        public override void rendFilter(T fliterItem, int index)
        {
            Console.WriteLine($"{index}:{fliterItem.originCardBO.name}");
        }
    }
}
