using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityCompanyCard_base.EventObject
{
    /// <summary>
    /// 处理一个指令的event对象
    /// </summary>
    public class EventObject_HandleCommandCard:IEventObject
    {
        public ICard resCard;
        public ICard targetCard;
        public IPlayer resPlayer;
        public IPlayer targetPlayer;
        public Object[] resObjects;
        public Object[] targetObjects;
        public EventObject_HandleCommandCard(ICommand command)
        {
            this.res = command;
            this.type = EventObjectConst.EventObjectType.HANDLE_COMMAND_CARD;
        }
    }
}
