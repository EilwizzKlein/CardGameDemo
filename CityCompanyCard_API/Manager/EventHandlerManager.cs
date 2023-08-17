using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Manager
{
    public class EventHandlerManager
    {
        public static Boolean MoveCard(IEventObject eventObject) {
            return true;
        }

        public static Boolean DrawCard(IEventObject eventObject)
        {
            //从玩家的卡组中抽取一张卡牌
            IPlayer? player = eventObject.resPlayer;
            if (player != null)
            {
                int drawNumber = 1;
                if (eventObject.resKeyValus.ContainsKey(EventObjectExtractKey.DRAW_CARD_NUMBER))
                {
                    Boolean flag = Int32.TryParse(eventObject.resKeyValus[EventObjectExtractKey.DRAW_CARD_NUMBER], out drawNumber);
                    drawNumber = (flag && drawNumber > 0) ? drawNumber : 1;
                }
                if (ApplicationContext.Instance.Trigger.TryGetValue(TriggerKey.ON_BEFORE_DRAW, out ITrigger trigger))
                {
                    trigger.Run(eventObject);
                }

                //执行onBeforeDrawTrigger
                for(int i = 0; i<drawNumber; i++) {
                    if (player.deck.cardList.Count > 0 && (player.hand.max < 0 || player.hand.cardList.Count < player.hand.max))
                    {
                        ICard card = player.deck.cardList[0];
                        card.OnBeforeDraw(eventObject);
                        player.deck.cardList.Remove(card);
                        player.hand.cardList.Add(card);
                        card.OnAfterDraw(eventObject);
                    }
                }

                if (ApplicationContext.Instance.Trigger.TryGetValue(TriggerKey.ON_After_DRAW, out trigger))
                {
                    trigger.Run(eventObject);
                }
                //执行onAfterDrawTrigger
                return true;

            }
            return false;
        }

        public static Boolean PlayCard(IEventObject eventObject)
        {
            return true;
        }

        public static Boolean PlayPower(IEventObject eventObject)
        {
            return true;
        }

        public static Boolean CreateCard(IEventObject eventObject)
        {
            return true;
        }

        public static Boolean GoToNextState(IEventObject eventObject)
        {
            return true;
        }
    }
}
