using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_API.Interface;
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
using CityCompanyCard_API.Interface.dictionary;

namespace CityCompanyCard_base.Card.Command
{
    public class CommandGather : ICommandCard
    {
        public CommandGather() {
            this.originCardBO.name = "收集";
            id = "command_gather"; //保证ID唯一 不和其他卡重复
        }

        public override bool OnAsyncPlay(IEventObject eventObject)
        {
            //获取玩家的行动点
            IEventObject ev = eventObject;
            MainPlayer player = (MainPlayer)ev.resPlayer!;
            ev.resKeyValus.TryAdd(EventObjectExtractKey.POWER_NAME, "收集");
            int actionPoint = player.actionPoint;
            //选择一个单位执行移动
            //开启一个选择进程
            if (actionPoint <= 0)
            {
                Console.WriteLine("玩家体力用完了");
            }
            else
            {
                //获取生物
                new Selector_ResUnitFactory().get_GetCanGatherUnitFilter().startISeletor(ev, out IUnitCard[] outputCard);
                if (outputCard.Length > 0)
                {
                    // TODO:获取该生物可以移动的格子
                    IUnitCard card = outputCard[0];
                    ev.resCard = card;
                    //选择该生物激活哪一个能力
                    new Selector_PowerSelector<IPower>().startISeletor(ev, out IPower[] power);
                    if (power.Length > 0) {
                        power[0].Activate(ev);
                    }
                }
                else
                {
                    //移动失败
                    Console.WriteLine("收集失败");
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

        }

    }
}
