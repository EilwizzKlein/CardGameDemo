using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Manager;
using CityCompanyCard_API;
using CityCompanyCard_base.Card.Command;
using CityCompanyCard_base.Dictionary;
using CityCompanyCard_base.Player;
using CityCompanyCard_mod.Card.UnitCard;

namespace CityCompanyCard_test.unitTest
{
    internal class testAttackCommand
    {
        public static void start()
        {
            //给主要玩家的指令卡堆添加5个基本指令
            MainPlayer player = new MainPlayer();
            MainPlayer player2 = new MainPlayer();

            player.command.AddCommand(new CommandAttack());
            player.command.AddCommand(new CommandAttack());
            player.command.AddCommand(new CommandAttack());
            //给玩家1创建5张手牌
            for (int i = 0; i < 5; i++)
            {
                IUnitCard test = new UnitCard_PoorFarmer();
                test.setZone(player.hand);
                test.controller = player;
                player.hand.cardList.Add(test);
            }
            //给玩家2创建5张手牌
            for (int i = 0; i < 5; i++)
            {
                IUnitCard test = new UnitCard_PoorFarmer();
                test.setZone(player2.hand);
                test.controller = player2;
                player2.hand.cardList.Add(test);
            }

            Console.WriteLine($"玩家当前手牌数为5:${player.hand.cardList.Count}");

            //玩家打出一张牌到 1 2 3 4 5 格
            //构建EventObject;
            IUnitCard unitCard = (IUnitCard)player.hand.cardList[0];
            IZone hands = player.hand;

            IEventObject eventObject = new IEventObject();
            eventObject.resPlayer = player;
            eventObject.resCard = unitCard;
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[1] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.eventHandlerManager.PlayCard(eventObject);

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject.resCard = unitCard;
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[2] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.eventHandlerManager.PlayCard(eventObject);

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject.resCard = unitCard;
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[3] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.eventHandlerManager.PlayCard(eventObject);

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject.resCard = unitCard;
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[4] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.eventHandlerManager.PlayCard(eventObject);

            Console.WriteLine($"玩家当前手牌数为1:${player.hand.cardList.Count}");

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject.resCard = unitCard;
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[5] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.eventHandlerManager.PlayCard(eventObject);

            Console.WriteLine($"玩家当前手牌数为0:${player.hand.cardList.Count}");

            unitCard = (IUnitCard)player2.hand.cardList[0];
            hands = player2.hand;
            eventObject.resPlayer = player2;
            eventObject.resCard = unitCard;
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[6] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.eventHandlerManager.PlayCard(eventObject);

            unitCard = (IUnitCard)player2.hand.cardList[0];
            eventObject.resCard = unitCard;
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[7] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.eventHandlerManager.PlayCard(eventObject);

            unitCard = (IUnitCard)player2.hand.cardList[0];
            eventObject.resCard = unitCard;
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[8] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.eventHandlerManager.PlayCard(eventObject);

            unitCard = (IUnitCard)player2.hand.cardList[0];
            eventObject.resCard = unitCard;
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[9] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.eventHandlerManager.PlayCard(eventObject);

            Console.WriteLine($"玩家当前手牌数为1:${player.hand.cardList.Count}");

            unitCard = (IUnitCard)player2.hand.cardList[0];
            eventObject.resCard = unitCard;
            eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[10] };
            eventObject.resZone = hands;
            eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };
            ApplicationContext.Instance.eventHandlerManager.PlayCard(eventObject);

            Console.WriteLine($"玩家当前手牌数为0:${player.hand.cardList.Count}");


            //构建command事件对象
            IEventObject commandEV = new IEventObject();
            commandEV.resCard = player.command.cardList[0];
            commandEV.resPlayer = player;
            //测试move指令

            ApplicationContext.Instance.eventHandlerManager.PlayCard(commandEV);

            Console.WriteLine($"玩家当前指令数:{player.command.unusedCommand.Count}");
        }
    }
}
