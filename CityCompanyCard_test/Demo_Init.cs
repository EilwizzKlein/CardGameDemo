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

namespace CityCompanyCard_test
{
    internal class Demo_Init
    {
        public Boolean Init()
        {
            ApplicationContext app = ApplicationContext.Instance;
            IMode modeBO = ModeFactory.GetModeByType(ModeFactory.TEST_MODE);
            //创建主要玩家
            MainPlayer mainplayer = new MainPlayer();
            mainplayer.name = "Test";
            for (int i = 0; i < 20; i++)
            {
                mainplayer.deck.cardList.Add(new Unit_Demo());
            }
            for (int i = 0; i < 20; i++)
            {
                mainplayer.deck.cardList.Add(new Unit_Farmer());
            }
            mainplayer.deck.sufferZone();
            app.SetMode(modeBO);
            app.RegisterPlayer(mainplayer);
            return app.Init();
        }
    }
}
