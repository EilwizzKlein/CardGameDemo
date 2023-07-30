using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.Manager;
using CityCompanyCard_base.EventObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

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
            IPlayer player = ApplicationContext.Instance.GetMainPlayer()!;
            switch (commandHead)
            {
                case "Q":
                    flag = false;
                    break;
                case "DRAW":
                    ZoneManager.moveCardsToZone(player.deck, player.hand, 1);
                    break;
                case "SHOW":
                    showCardListOnlyName(player.hand.cardList);
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
                Console.WriteLine(card.name);
            }
        }

        public static void PlayHandle(string body)
        {
            IPlayer player = ApplicationContext.Instance.GetMainPlayer()!;
            string[] command = body.Split('|');
            ICard card = player.hand.cardList[Int16.Parse(command[0])];
            if (card is IUnitCard && command.Length >= 2)
            {
                //构建EventObject;
                EventObject_PlayUnitCard eventObject = new EventObject_PlayUnitCard(card);
                eventObject.tile = int.Parse(command[1]);
                eventObject.whereFrom = player.hand;
                ApplicationContext.Instance.cardManager.playCard(card, eventObject);
            }
        }
    }
}
