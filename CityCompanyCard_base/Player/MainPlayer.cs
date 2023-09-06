using CityCompanyCard_API;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Manager;
using CityCompanyCard_API.RenderObject;
using CityCompanyCard_API.Zone;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Player
{
    public class MainPlayer:IPlayer
    {
        public IZone readyDeck = new IZone(); //预备卡组
        public CommandZone command = new CommandZone();
        public int actionPoint;
        public int maxActionPoint;

        public override void OnPlayCard(IEventObject ev)
        {
            hand.cardList.Remove(ev.resCard);
        }

        public void ChooseCommand(ICommandCard card) {
            command.ChooseCommand(card);
        }

        public virtual bool beforeChosen(IEventObject ev)
        {
            return true;
        }

        public override bool InitDeckByList(string[] list)
        {
            CardManager cardManager = ApplicationContext.Instance.cardManager;
            IZone temp = deck;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == "")
                {
                    temp = readyDeck;
                    continue;
                }
                if (cardManager.getCardByClass(list[i]) == null) { continue; }
                temp.cardList.Add(cardManager.getCardByClass(list[i])!);
            }
            return true;
        }
        public MainPlayer() {
            renderCard = new IPlayerCard();
            readyDeck = new IZone();
            hand = new HandZone();
            grave = new IZone();
            deck = new IZone();
            mana = 2;
            actionPoint=5;
            maxActionPoint= 5;

            string filePath = "D:\\VS\\WorkShop\\CardGameDemo\\CityCompanyCard_base\\Save\\deck.txt"; // 替换为实际的文件路径

            try
            {
                string[] lines = File.ReadLines(filePath).ToArray();

                Console.WriteLine("File Content as String Array:");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                InitDeckByList(lines);
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }
           
        }
    }
}
