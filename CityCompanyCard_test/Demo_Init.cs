using CityCompanyCard_API;
using CityCompanyCard_base.Player;
using CityCompanyCard_base.BattleGround;
using CityCompanyCard_base.Card.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Mode;
using CityCompanyCard_API.Card;
using CityCompanyCard_test.unitTest;
using CityCompanyCard_mod.Card.UnitCard;

namespace CityCompanyCard_test
{
    internal class Demo_Init: ITest
    {
        public Boolean Init()
        {
            ApplicationContext app = ApplicationContext.Instance;
            IMode modeBO = ModeFactory.GetModeByType(ModeFactory.TEST_MODE);
            Type type = typeof(UnitCard_PoorFarmer);
            //测试加载逻辑
            Dictionary<string, Type> cardmap = new Dictionary<string, Type>
            {
                { "可怜的农夫", typeof(UnitCard_PoorFarmer) },
                { "可怜的工人", typeof(UnitCard_PoorWorker) }
            };
            app.cardManager.loadCardMap(cardmap);
            //添加玩家
            MainPlayer player = new MainPlayer();
            app.RegisterPlayer(player);
            //创建主要玩家
            MainPlayer mainplayer = new MainPlayer();
            mainplayer.name = "Test";
            mainplayer.deck.sufferZone();
            app.SetMode(modeBO);
            app.RegisterPlayer(mainplayer);
            return app.Init();
        }

        public override void runTest() {
            Console.WriteLine("开始初始化测试");
            Boolean flag = Init();
            if (flag)
            {
                ApplicationContext app = ApplicationContext.Instance;
                foreach (string key in app.BattleZone.Keys)
                {
                    Console.WriteLine(key);
                }

                foreach (ICard card in app.GetCurrentPlayer().hand.cardList)
                {
                    Console.WriteLine(card.renderCardBO.name);
                }
                TestHandle.flag = true;
            }
            //运行单元测试
            //testBuff.start();
            //testCommand.start();
            //testMoveCommand.start();
            testDraw.start();
            //testAttackCommand.start();

            while (TestHandle.flag)
            {
                string command = Console.ReadLine()!;
                TestHandle.Handle(command);
            }
            Console.ReadKey();
        }
    }
}
