using CityCompanyCard_API.Card;
using CityCompanyCard_API.Dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Dictionary;
using CityCompanyCard_base.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Card.Interface
{
    public abstract class ICommandCard:INotInstanceCard
    {

        public ICommandCard()
        {
            this.type = CardType.Command;
        }

        public abstract bool PlayCommand(IEventObject eventObject);

        //public override void OnPlay(IEventObject eventObject)
        //{
        //    while (PlayCommand(eventObject)) { };
        //}

        public override Boolean OnBeforePlay(IEventObject eventObject)
        {
            eventObject.resCard = this;
            //设置玩家行动力(AP)
            eventObject.resKeyValus.TryAdd(EventObjectExtractKey.POWER_NAME, this.originCardBO.name);
            //处理事件


            ((MainPlayer)eventObject.resPlayer).actionPoint += eventObject.modify;
            return true;
        }

        public override void OnAfterPlay(IEventObject eventObject)
        {
            //重置玩家的AP
            eventObject.resKeyValus.TryAdd(EventObjectExtractKey.POWER_NAME, this.originCardBO.name);
        }

    }
}
