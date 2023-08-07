using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Card.Command;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.Card.Unit;
using CityCompanyCard_base.Dictionary;
using CityCompanyCard_base.EventObject;
using CityCompanyCard_base.Factory;
using CityCompanyCard_base.Fliter;
using CityCompanyCard_base.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_test.unitTest
{
    internal class testMoveCommand
    {
        public static void start()
        {
            //给主要玩家的指令卡堆添加5个基本指令
            MainPlayer player = (MainPlayer)ApplicationContext.Instance.GetMainPlayer();
         
            player.command.AddCommand(new CommandMove());
            //给玩家创建5张手牌
            for(int i = 0; i <= 5; i++)
            {
                IUnitCard test = new Unit_Demo();
                test.setZone(player.hand);
                test.controller = player;
                player.hand.cardList.Add(test);
            }

            Console.WriteLine($"玩家当前手牌数为5:${player.hand.cardList.Count}");

            //玩家打出一张牌到 1 2 3 4 5 格
            //构建EventObject;
            IUnitCard unitCard = (IUnitCard)player.hand.cardList[0];
            IZone[] hands = new IZone[] { player.hand };

            IEventObject eventObject = new IEventObject();
            eventObject.resCard = new ICard[] { unitCard };
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[1] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.cardManager.playCard(unitCard, eventObject);

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject.resCard = new ICard[] { unitCard };
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[2] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.cardManager.playCard(unitCard, eventObject);

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject.resCard = new ICard[] { unitCard };
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[3] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.cardManager.playCard(unitCard, eventObject);

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject.resCard = new ICard[] { unitCard };
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[4] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.cardManager.playCard(unitCard, eventObject);

            Console.WriteLine($"玩家当前手牌数为1:${player.hand.cardList.Count}");

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject.resCard = new ICard[] { unitCard };
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[5] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.cardManager.playCard(unitCard, eventObject);

            Console.WriteLine($"玩家当前手牌数为0:${player.hand.cardList.Count}");

            Fliter_HasPlayerUnitZone<IZone> fliter = new Fliter_HasPlayerUnitZone<IZone>();

            //构建command事件对象
            EventObject_PlayCommandCard commandEV = new EventObject_PlayCommandCard(player);
            commandEV.resPlayer = new IPlayer[] { player };
           List<IZone> sss = fliter.runFliter(commandEV);
        //测试

            //执行
            ApplicationContext.Instance.cardManager.playCard(player.command.cardList[0], commandEV);
        }
    }
}
