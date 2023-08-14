using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.EventObject;
using CityCompanyCard_base.Factory;
using CityCompanyCard_base.Player;
using CityCompanyCard_base.Selector;
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
            this.originCardBO.name = "移动";
            id = "command_move"; //保证ID唯一 不和其他卡重复
        }

        public override void OnPlay(IEventObject eventObject)
        {
            flag = true;
                // 子线程的逻辑，这里以计算值为例
            OnAsyncPlay(eventObject);
        }

        public bool OnAsyncPlay(IEventObject eventObject)
        {
            bool flag = false;
            //获取玩家的行动点
            EventObject_PlayCommandCard ev = (EventObject_PlayCommandCard)eventObject;
            MainPlayer player = (MainPlayer)ev.res;
            int actionPoint = player.actionPoint;
            //选择一个单位执行移动
            //开启一个选择进程
            if (actionPoint <= 0)
            {
                Console.WriteLine("玩家体力用完了");
                flag = true;
            }
            else
            {
                //选择该格子上的生物(如果有的话)
                //获取棋盘
                actionPoint--;

                //获取生物
                flag = new Selector_ResUnit<IUnitCard>().startISeletor(ev,out IUnitCard[] output);
                // TODO:获取该生物可以移动的格子



                //if (flag) {
                //    ZoneManager.moveCardsToZone(ev.resZone, ev.targetZone[0], ev.resCard);
                //}
            }
            if (flag)
            {
                Console.WriteLine("输入End结束");
                string command = Console.ReadLine();

                if (command.ToUpper() == "END")
                {
                    flag = false;
                }
                else
                {

                OnAsyncPlay(eventObject);
                }
            }
            return flag;

        }


        public override void OnAfterPlay(IEventObject eventObject)
        {
            base.OnAfterPlay(eventObject);
        }
    }
}
