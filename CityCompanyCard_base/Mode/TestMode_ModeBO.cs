using CityCompanyCard_API;
using CityCompanyCard_API.Dictionary;
using CityCompanyCard_API.Factory;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.BattleGround;
using CityCompanyCard_base.Dictionary;
using CityCompanyCard_base.Manager;
using CityCompanyCard_base.Manager.CardManager;
using CityCompanyCard_base.Player;
using CityCompanyCard_base.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Mode
{
    public class TestMode_ModeBO : IMode
    {
        //注入渲染器
       
        public override bool InitApp()
        {
            ApplicationContext app = ApplicationContext.Instance;
            Console.WriteLine("欢迎进入测试模式");
            //设置主要战场
            app.BattleZone.Add(BattlegroundConst.MAIN_BATTLE_GROUND, BattleGroundFactory.GetBattleGroundByType(BattlegroundConst.MAIN_BATTLE_GROUND));
            //注册卡牌管理器
            app.SetCurrentState(new State_TurnStart());
            app.cardManagerFactory = new CardManagerFactory();
            app.cardManagerFactory.registManagerList(CardType.Instance, new InstanceCardManager());
            app.cardManagerFactory.registManagerList(CardType.NotInstance, new NotInstanceCardManager());
            app.cardManagerFactory.registManagerList(CardType.Command, new CommandCardManager());
            app.eventHandlerManager = new BaseEventHanlderManager();
            return true;
        }
    }
}
