using CityCompanyCard_API.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public abstract class IAction
    {
        internal ICard? resCard;
        public bool deleteSelf { get; protected set; }
        public IAction()
        {
            deleteSelf = false; // 设置初始值为 false
        }

        public IAction(ICard card)
        {
            resCard = card;
            deleteSelf = false; // 设置初始值为 false
        }
        public abstract void Run(IEventObject eventObject);
    }
}
