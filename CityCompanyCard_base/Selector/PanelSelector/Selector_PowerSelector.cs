using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.dictionary;
using CityCompanyCard_API.Interface.Instance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector.PanelSelector
{
    public class Selector_PowerSelector<T> : BasePanelSeletor<T> where T : IPower
    {
        public override T[] onFilter(IEventObject ev)
        {
            if (ev.resKeyValus.ContainsKey(EventObjectExtractKey.POWER_NAME))
            {
                List<IPower> powers = ev.resCard.getPower(ev.resKeyValus[EventObjectExtractKey.POWER_NAME]);
                return (T[])powers.ToArray();
            }
            else
            {
                throw new Exception("能力选择窗口未传入能力字段");
            }

        }

        public override void rendFilter(T fliterItem, int index)
        {
            Console.WriteLine($"{index}:{fliterItem.description}");
        }
    }
}
