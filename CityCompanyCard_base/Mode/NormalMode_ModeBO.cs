using CityCompanyCard_API;
using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Dictionary;
using CityCompanyCard_base.Factory;
using CityCompanyCard_base.Manager;
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
            app.cardManager = new CityCompanyCard_API.Manager.CardManager();
            app.cardManager.registManagerList(CardType.Unit, new UnitCardManager());
            app.cardManager.registManagerList(CardType.Command, new CommandCardManager());
            return true;
        }
    }
}
