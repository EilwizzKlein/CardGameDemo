using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.BattleGround;
using CityCompanyCard_base.EventObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Manager
{
    public class UnitCardManager:ICardManager
    {
        public override bool PlayCard(ICard res, IEventObject eventObject)

        {
            //beforePlay
            EventObject_PlayUnitCard unitEventObject = (EventObject_PlayUnitCard)eventObject;
            unitEventObject.whereFrom.cardList.Remove(res);
            ApplicationContext.Instance.BattleZone.GetValueOrDefault(BattleGroundFactory.MAIN_BATTLE_GROUND).battleGrounds[unitEventObject.tile].cardList.Add(res);
            res.OnPlay(eventObject);
            return true;
        }

    }
}
