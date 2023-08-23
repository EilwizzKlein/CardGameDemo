using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Manager
{
    public class BaseEventHanlderManager : EventHandlerManager
    {
        public override Boolean MoveCard(IEventObject eventObject)
        {
            return true;
        }

        public override Boolean DrawCard(IEventObject eventObject)
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
                for (int i = 0; i < drawNumber; i++)
                {
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

        public override Boolean PlayCard(IEventObject eventObject)
        {
            return true;
        }

        public override Boolean AttackEvent(IEventObject eventObject)
        {
            IInstanceCard res = eventObject.resCard! as IInstanceCard;
            //TODO!!!!!!!!!!!!!

            //4.攻击方预检定OnBeforePower()⇒如果返回是True则继续结算

            //5.攻击方结算攻击事件OnPower()⇒计算攻击伤害,修改event.value;

            //6.被攻击方预检定OnBeforeAttack()⇒如果返回是True则继续结算

            //7.被攻击方处理攻击事件OnAttack()⇒计算修正值

            //8.被攻击方预检定受到伤害事件OnBeforeDamage()⇒如果返回是True则继续结算

            //9.被攻击方处理受到伤害事件OnDamage()⇒伤害修正

            //10.被攻击方处理受到伤害后事件OnAfterDamage()

            //11.构建反击事件对象:event.resCard,event.targetCard

            //11.被攻击方预检定反击事件OnBeforeCounterattack()⇒如果返回是True则继续结算

            //12.被攻击方处理反击事件OnCounterattack() :修改ev.value

            //13.被反击方预检定受到伤害事件OnBeforeDamage()⇒如果返回是True则继续结算

            //14.被反击方处理受到伤害事件OnDamage()⇒伤害修正

            //15.被反击方处理受到伤害后事件OnAfterDamage()

            //16.被攻击方处理反击后事件OnAfterCounterattack();

            //17.被攻击方处理攻击后事件OnAfterAttack();

            //18.攻击方结算攻击后事件OnAfterPower();


            if (eventObject.targetCard == null || eventObject.targetCard.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < eventObject.targetCard.Length; i++)
            {
                if (eventObject.targetCard[i] == null || eventObject.targetCard[i] is not IInstanceCard)
                {
                    continue;
                }
                IInstanceCard card = (eventObject.targetCard[i]) as IInstanceCard;
                if (!card!.OnBeforeAttack(eventObject))
                {
                    continue;
                }
                card.OnAttack(eventObject);
                card.OnAfterAttack(eventObject);
            }
            return true;

        }

        public override Boolean PlayPower(IEventObject eventObject)
        {
            return true;
        }

        public override Boolean CreateCard(IEventObject eventObject)
        {
            return true;
        }

        public override Boolean GoToNextState(IEventObject eventObject)
        {
            return true;
        }
    }
}
