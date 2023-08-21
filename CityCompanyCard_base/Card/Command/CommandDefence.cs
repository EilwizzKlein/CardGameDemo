using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.dictionary;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.Player;
using CityCompanyCard_base.Selector.PanelSelector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityCompanyCard_base.Card.Command
{
    public class CommandDefence : ICommandCard
    {
        public CommandDefence()
        {
            this.originCardBO.name = "防御";
            id = "command_defence"; //保证ID唯一 不和其他卡重复
        }

        public override bool OnAsyncPlay(IEventObject ev)
        {
            //获取玩家的行动点
            MainPlayer player = (MainPlayer)ev.resPlayer!;
            int actionPoint = player.actionPoint;

            if (actionPoint < 0)
            {
                Console.WriteLine("玩家体力用完了");
            }

            else
            {
                //获取生物
                new Selector_ResUnitFactory().getGetCanDefenceUnitFilter().startISeletor(ev, out IUnitCard[] outputCard);
                if (outputCard.Length > 0)
                {
                    IUnitCard card = outputCard[0];
                    // TODO:选择使用能力或者基本效果
                    //获取该卡的对应能力
                    ev.resCard = card;
                    ev.resKeyValus.TryAdd(EventObjectExtractKey.POWER_NAME, "防御");
                   Boolean flag = new Selector_PowerSelector<IPower>().startISeletor(ev, out IPower[] powers);
                    //
                    if (flag) {
                        if (powers != null && powers.Length > 0)
                        {
                            powers[0].Activate(ev);
                        }
                    }
                }
                else
                {
                    //移动失败
                    Console.WriteLine("移动失败");
                }

            }
            Console.WriteLine("输入End结束");
            string command = Console.ReadLine();
            if (command.ToUpper() == "END")
            {
                return false;
            }
            else
            {
                return true;
            }


            return true;
        }


        public override void OnAfterPlay(IEventObject eventObject)
        {
            base.OnAfterPlay(eventObject);
        }
    }
}
