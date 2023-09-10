    using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CityCompanyCard_base.Dictionary;
using CityCompanyCard_base.Event;

namespace CityCompanyCard_test
{
    public class TestHandle
    {
        public static Boolean flag = false;

        public static void Handle(string command)
        {
            string commandHead = command.Split('-')[0].ToUpper();
            string commandBody = null;
            if (command.Split("-").Length > 1)
            {
                commandBody = command.Split("-")[1].ToUpper();
            }
            IPlayer player = ApplicationContext.Instance.GetCurrentPlayer()!;
            switch (commandHead)
            {
                case "Q":
                    flag = false;
                    break;
                case "DRAW":
                    //构造eventObject
                    //构建EventObject;
                    IEventObject eventObject = new IEventObject();
                    eventObject.resPlayer = player;
                    eventObject.targetZone = new IZone[] { player.hand };
                    new DrawCardEvent(eventObject);
                    break;
                case "SHOW":
                    showCardListOnlyName(player.hand.cardList);
                    break;
                case "BATTLE":
                    showBattle(commandBody);
                    break;
                //case "COPY":
                //    IRenderUnitCard c = (IRenderUnitCard)CardManager.generateRenderCard(player.hand.cardList[0], typeof(IRenderUnitCard));
                //    c.raw = (IUnitCard)player.hand.cardList[0];
                //    c.attack = 10;
                //    c.raw.attack = 5;
                //    player.hand.cardList[0].cost = 100;
                //    Console.WriteLine($"raw:attack{c.raw.attack}|cost:{c.raw.cost}|guid:{c.raw.getUUID()}");
                //    Console.WriteLine($"c:attack{c.attack}|cost:{c.cost}|guid:{c.getUUID()}");
                //    Console.WriteLine($"cardList:cost:{player.hand.cardList[0].cost}|guid:{player.hand.cardList[0].getUUID()}");
                //    break;
                case "PLAY":
                    if (commandBody != null)
                    {
                        PlayHandle(commandBody);
                    }
                    break;
                default:
                    Console.WriteLine("请重新输入指令");
                    break;
            }

        }

        public static void showCardListOnlyName(List<ICard> cardlist)
        {
            foreach (ICard card in cardlist)
            {
                Console.WriteLine(card.renderCardBO.name);
            }
        }

        public static void PlayHandle(string body)
        {
            IPlayer player = ApplicationContext.Instance.GetCurrentPlayer()!;
            string[] command = body.Split('|');
            ICard card = player.hand.cardList[Int16.Parse(command[0])];
            if (card is IUnitCard && command.Length >= 2)
            {
                //构建EventObject;
                IEventObject eventObject = new IEventObject();
                eventObject.resCard =  card;
                eventObject.resPlayer = player;
                int index = int.Parse(command[1]);
                eventObject.targetZone = new IZone[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[index] };
                eventObject.targetBattleGround = new IBattleGround[] { ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND) };

                eventObject.resZone = player.hand ;
                new PlayCardEvent(eventObject).Run();
            }
        }

        public static void showBattle(string body)
        {
            //获取区域
            string[] command = body.Split('|');
            Console.WriteLine(ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattlegroundConst.MAIN_BATTLE_GROUND).battleGrounds[Int16.Parse(command[0])].cardList.Count);


        }
        
    }
}
