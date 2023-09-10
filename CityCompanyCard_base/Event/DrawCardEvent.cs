using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Zone;
using CityCompanyCard_base.Player;
using CityCompanyCard_base.Selector.PanelSelector;
using CityCompanyCard_base.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Event
{
    public class DrawCardEvent : IEvent
    {
        public DrawCardEvent(IEventObject eventObject) : base(eventObject)
        {
        }

        public override void OnRun(IEventObject ev, bool isRoot)
        {
            //执行玩家的抽牌前行动
            IEventObject eventObject = new IEventObject(ev);
            MainPlayer player = eventObject.resPlayer as MainPlayer;
            if (!player.OnBeforeDraw(eventObject))
            {
                return;
            }
            //
            int mainDeck = 0;
            int readyDeck = 0;
            for(int i= 0;i< ev.targetZone.Length;i++)
            {
                if(ev.targetZone[i] is MainDeckZone) { mainDeck++; }
                else if (ev.targetZone[i] is ReadyDeckZone) { readyDeck++; }
            }
            //玩家抽取等同于readyDeck数量的卡
            //开启选择器
            IEventObject selectCardEv = new IEventObject(ev);
            selectCardEv.resZone = player.readyDeck;
            selectCardEv.value = readyDeck;
            new Selector_CardFromZone<ICard>().startISeletor(selectCardEv, out ICard[] cards);
            for(int i = 0;i< cards.Length; i++)
            {
                if (player.hand.max < 0 || player.hand.cardList.Count < player.hand.max)
                {
                    IEventObject drawCardEv = new IEventObject(eventObject);
                    ICard card = cards[0];
                    drawCardEv.resCard =  card ;
                    card.OnBeforeDraw(drawCardEv);
                    player.readyDeck.cardList.Remove(card);
                    player.hand.cardList.Add(card);
                    card.setZone(player.hand);
                    card.OnAfterDraw(drawCardEv);
                }
            }
            //玩家抽取等同于mainDeck数量的卡
            //执行onBeforeDrawTrigger
            for (int i = 0; i < mainDeck; i++)
            {
                if (player.deck.cardList.Count > 0 && (player.hand.max < 0 || player.hand.cardList.Count < player.hand.max))
                {
                    IEventObject drawCardEv = new IEventObject(eventObject);
                    ICard card = player.deck.cardList[0];
                    drawCardEv.resCard = card;
                    card.OnBeforeDraw(drawCardEv);
                    player.deck.cardList.Remove(card);
                    player.hand.cardList.Add(card);
                    card.setZone(player.hand);
                    card.OnAfterDraw(drawCardEv);
                }
            }
            ApplicationContext.Instance.RunEventQueue(isRoot);
        }
    }
}
