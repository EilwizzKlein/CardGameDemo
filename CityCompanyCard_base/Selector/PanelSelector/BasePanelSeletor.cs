﻿using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Instance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Selector.PanelSelector
{
    public abstract class BasePanelSeletor<T>:ISelector<T>
    {
        public abstract void rendFliter(T filter, int index);
        public override void showSelector()
        {
            Console.WriteLine("面板显示了,输入H隐藏");
        }

        public override void hideSelector()
        {
            Console.WriteLine("面板隐藏了,输入S隐藏");
        }


        public override bool onSelector(IEventObject ev, T[] filter, out T[] output)
        {
            string command = Console.ReadLine().ToUpper();
            if (command == "H")
            {
                hideSelector();
                return onSelector(ev, filter, out output);
            }
            if (command == "S")
            {
                showSelector();
                return onSelector(ev, filter, out output);
            }
            if (command == "E")
            {
                Console.WriteLine("取消选择");
                output = new T[] { };
                return false;
            }
            if (command == "C")
            {
                bool flag = int.TryParse(Console.ReadLine(), out int index);
                if (flag && index < filter.Length)
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
             for(int i = 0; i < filter.Length;i++)
                {
                    rendFliter(filter[i], i);
                }
                Console.WriteLine("请输入C后选择");
            }
        }
       
    }
}
