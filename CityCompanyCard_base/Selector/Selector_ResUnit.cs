using CityCompanyCard_API.Card;
using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_base.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector
{
    public class Selector_ResUnit<T> : ISelector<T> where T : IUnitCard

    {
        public override void hideSelector()
        {
            Console.WriteLine("面板隐藏了,输入S隐藏");
        }

        public override T[] onFliter(IEventObject ev)
        {
            //搜索场上的目标玩家生物
            List<ICard> cards = AppUtils.getMainBattleGround().CardList.Where(card=> (card.controller == ev.resPlayer && card.type == CardType.Unit)).ToList();
            if(cards.Count > 0)
            {
                return cards.OfType<T>().ToArray();
            }
            else
            {
                return new T[] {};
            }
        }

        public override bool onSelector(IEventObject ev, T[] filter, out T[] output)
        {
            string command = Console.ReadLine().ToUpper();
            if(command == "H")
            {
                hideSelector();
                return onSelector(ev, filter, out output);
            }
            if(command == "S")
            {
                showSelector();
                return onSelector(ev, filter, out output);
            }
            if(command == "E") {
                Console.WriteLine("取消选择");
                output = new T[] { };
                return false;
            }
            if(command == "C")
            {
                bool flag  = Int32.TryParse(Console.ReadLine(),out int index);
                if(flag && index < filter.Length)
                {
                    output = new T[] { filter[index] };
                   return true;
                }
                else
                {
                    Console.WriteLine("请检查输入");
                    return onSelector(ev, filter, out output);
                }
            }
            else
            {
                output = new T[] { };
                return false;
            }
        }

        public override void renderSeletor(IEventObject ev, T[] filter)
        {
            if (filter == null || filter.Length == 0)
            {
                Console.WriteLine("没有目标,输入E键取消选择");
            }
            else
            {
                foreach (IUnitCard card in filter)
                {
                    Console.WriteLine($"{((BattleGroundTileZone)card.GetZone()).getIndex()}:{card.renderCardBO.name}");

                }
                Console.WriteLine("请输入C后选择");
            }
        }

        public override void showSelector()
        {
            Console.WriteLine("面板显示了,输入H隐藏");
        }
    }
}
