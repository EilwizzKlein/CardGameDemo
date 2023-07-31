using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.BattleGround;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.EventObject;
using CityCompanyCard_base.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityCompanyCard_base.Card.Command
{
    public class CommandMove : ICommandCard
    {
        bool flag = false;
        public CommandMove()
        {
            name = "移动";
            id = "command_move"; //保证ID唯一 不和其他卡重复
        }

        public override void OnPlay(IEventObject eventObject)
        {
            flag = true;
            Thread thread = new Thread(async () =>
            {
                // 子线程的逻辑，这里以计算值为例
                OnAsyncPlay(eventObject);
            });
            thread.Start();
            thread.Join();
        }

        public bool OnAsyncPlay(IEventObject eventObject)
        {
            bool flag = false;
            //获取玩家的行动点
            EventObject_PlayCommandCard ev = (EventObject_PlayCommandCard)eventObject;
            MainPlayer player = (MainPlayer)ev.res;
            int actionPoint = player.actionPoint.getCurrent();
            //选择一个单位执行移动
            //开启一个选择进程
            Console.WriteLine("请输入要选择的对象,输入End结束");
            string command = Console.ReadLine();

            if (command.ToUpper() == "END")
            {
                flag = false;
            }
            else
            {
                if (actionPoint <= 0)
                {
                    flag = true;
                }
                //选择该格子上的生物(如果有的话)
                //获取棋盘
                player.actionPoint.reduceValue(1);
                int place = 0;
                int.TryParse(command, out place);
                if (ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattleGroundFactory.MAIN_BATTLE_GROUND).battleGrounds[place].cardList.Count > 0)
                {
                    IUnitCard unit = (IUnitCard)ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattleGroundFactory.MAIN_BATTLE_GROUND).battleGrounds[place].cardList[0];
                    ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattleGroundFactory.MAIN_BATTLE_GROUND).battleGrounds[place].cardList.Remove(unit);
                    Console.WriteLine("请输入要选择的格子");
                    command = Console.ReadLine();
                    int.TryParse(command, out place);
                    ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattleGroundFactory.MAIN_BATTLE_GROUND).battleGrounds[place].cardList.Add(unit);
                }
                flag = true;
            }
            if (flag)
            {
                OnAsyncPlay(eventObject);
            }
            return flag;

        }


        public override void OnAfterPlay(IEventObject eventObject)
        {
            base.OnAfterPlay(eventObject);
        }
    }
}
