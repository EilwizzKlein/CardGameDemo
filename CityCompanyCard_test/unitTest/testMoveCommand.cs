using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Card.Command;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.Card.Unit;
using CityCompanyCard_base.EventObject;
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
            player.hand.cardList.Add(new Unit_Demo());
            player.hand.cardList.Add(new Unit_Demo());
            player.hand.cardList.Add(new Unit_Demo());
            player.hand.cardList.Add(new Unit_Demo());
            player.hand.cardList.Add(new Unit_Demo());

            Console.WriteLine($"玩家当前手牌数为5:${player.hand.cardList.Count}");

            //玩家打出一张牌到 1 2 3 4 5 格
            //构建EventObject;
            IUnitCard unitCard = (IUnitCard)player.hand.cardList[0];
            EventObject_PlayUnitCard eventObject = new EventObject_PlayUnitCard(unitCard);
            eventObject.whereFrom = player.hand;
            eventObject.tile = 1;
            ApplicationContext.Instance.cardManager.playCard(unitCard, eventObject);

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject = new EventObject_PlayUnitCard(unitCard);
            eventObject.whereFrom = player.hand;
            eventObject.tile = 2;
            ApplicationContext.Instance.cardManager.playCard(unitCard, eventObject);

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject = new EventObject_PlayUnitCard(unitCard);
            eventObject.whereFrom = player.hand;
            eventObject.tile = 3;
            ApplicationContext.Instance.cardManager.playCard(unitCard, eventObject);

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject = new EventObject_PlayUnitCard(unitCard);
            eventObject.whereFrom = player.hand;
            eventObject.tile = 4;
            ApplicationContext.Instance.cardManager.playCard(unitCard, eventObject);

            Console.WriteLine($"玩家当前手牌数为1:${player.hand.cardList.Count}");

            unitCard = (IUnitCard)player.hand.cardList[0];
            eventObject = new EventObject_PlayUnitCard(unitCard);
            eventObject.whereFrom = player.hand;
            eventObject.tile = 5;
            ApplicationContext.Instance.cardManager.playCard(unitCard, eventObject);

            Console.WriteLine($"玩家当前手牌数为0:${player.hand.cardList.Count}");

            //构建command事件对象
            EventObject_PlayCommandCard commandEV = new EventObject_PlayCommandCard(player);

            //执行
            ApplicationContext.Instance.cardManager.playCard(player.command.cardList[0], commandEV);
        }
    }
}
