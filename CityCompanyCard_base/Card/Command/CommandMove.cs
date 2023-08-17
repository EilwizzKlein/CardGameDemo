using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.Factory;
using CityCompanyCard_base.Player;
using CityCompanyCard_base.Selector.PanelSelector;
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
        public CommandMove()
        {
            this.originCardBO.name = "移动";
            id = "command_move"; //保证ID唯一 不和其他卡重复
        }

        public override void OnPlay(IEventObject eventObject)
        {
            // 子线程的逻辑，这里以计算值为例
            while (OnAsyncPlay(eventObject)) { };
        }

        public bool OnAsyncPlay(IEventObject eventObject)
        {
            //获取玩家的行动点
            IEventObject ev =eventObject;
            MainPlayer player = (MainPlayer)ev.resPlayer!;
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
                new Selector_ResUnit<IUnitCard>().startISeletor(ev,out IUnitCard[] outputCard);
                if (outputCard.Length > 0)
                {
                    // TODO:获取该生物可以移动的格子
                    IUnitCard card = outputCard[0];
                    ev.resCard = card;
                    if (card.GetZone() is BattleGroundTileZone) { 
                        ev.resBattleGroundTileZone = (BattleGroundTileZone)card.GetZone();
                        ev.resBattleGround = ev.resBattleGroundTileZone.getResBattleGround();
                    }
                    new Selector_targetZone<BattleGroundTileZone>().startISeletor(ev, out BattleGroundTileZone[] outbattleground);
                    ev.targetBattleGroundTileZone = outbattleground;
                    if (outbattleground.Length > 0) {
                        ZoneManager.moveCardToBattleGround(ev.resBattleGround,card, ev.targetBattleGroundTileZone[0]);
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

        }


        public override void OnAfterPlay(IEventObject eventObject)
        {
            base.OnAfterPlay(eventObject);
        }
    }
}
