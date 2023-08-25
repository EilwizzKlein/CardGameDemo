using CityCompanyCard_API;
using CityCompanyCard_API.Dictionary;
using CityCompanyCard_API.Factory;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.BattleGround;
using CityCompanyCard_base.Dictionary;
using CityCompanyCard_base.Manager;
using CityCompanyCard_base.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Mode
{
    public class NormalMode_ModeBO : IMode
    {
        public override bool InitApp()
        {
            ApplicationContext app = ApplicationContext.Instance;
            //添加玩家

            //设置主要战场
            app.BattleZone.Add(BattlegroundConst.MAIN_BATTLE_GROUND, BattleGroundFactory.GetBattleGroundByType(BattlegroundConst.MAIN_BATTLE_GROUND));
            //注册卡牌管理器
            app.cardManagerFactory = new CardManagerFactory();
            app.SetCurrentState(new State_TurnStart());
            app.cardManagerFactory.registManagerList(CardType.Unit, new UnitCardManager());
            app.cardManagerFactory.registManagerList(CardType.Command, new CommandCardManager());
            return true;
        }
    }
}
