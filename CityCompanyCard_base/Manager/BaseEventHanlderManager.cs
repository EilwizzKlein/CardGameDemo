using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Dictionary;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_API.Manager;
using CityCompanyCard_base.BO;
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
            ICard card = eventObject.resCard!;
            if (!card.OnBeforePlay(eventObject)) { return false; }

            //是否为免费释放
            if (!eventObject.resKeyValus.ContainsKey(EventObjectExtractKey.FREE_TO_USE) || eventObject.resKeyValus[EventObjectExtractKey.FREE_TO_USE] != null)
            {
                //费用检查,消耗费用
                if (eventObject.resPlayer!.mana < card.renderCardBO.cost)
                {
                    return false;
                }
                eventObject.resPlayer.mana -= card.renderCardBO.cost;
            }
            //区域转移
            if(card is IInstanceCard)
            {
                ZoneManager.moveCardToBattleGround(eventObject.targetBattleGround[0], card, (BattleGroundTileZone)eventObject.targetZone[0]);
            }
            card.OnPlay(eventObject);
            card.OnAfterPlay(eventObject);
            return true;
        }

        public override Boolean AttackEvent(IEventObject eventObject)
        {
            //
            if (eventObject.resCard == null || eventObject.targetCard == null || eventObject.targetCard.Length <= 0) { return false; }
            IInstanceCard? res = eventObject.resCard as IInstanceCard;
            ICard[] targets = eventObject.targetCard!;
            bool flag = false;
            for (int i = 0; i < targets.Length; i++)
            {
                //为了避免参数干扰 单独拷贝事件对象
                IEventObject ev = new IEventObject(eventObject);
                IInstanceCard target = (IInstanceCard)targets[i];
                //6.被攻击方预检定OnBeforeAttack()⇒如果返回是True则继续结算
                if (!target.OnBeforeAttack(ev)) { continue; }
                //7.被攻击方处理攻击事件OnAttack()⇒计算修正值
                target.OnAttack(ev);
                //8.被攻击方预检定受到伤害事件OnBeforeDamage()⇒如果返回是True则继续结算
                if (!target.OnBeforeDamage(ev)) { continue; }
                //9.被攻击方处理受到伤害事件OnDamage()⇒伤害修正
                target.OnDamage(ev);
                //10.被攻击方处理受到伤害后事件OnAfterDamage()
                target.OnAfterDamage(ev);
                if (target is IUnitCard)
                {
                    IEventObject counterAttack = new IEventObject();
                    //11.构建反击事件对象:event.resCard,event.targetCard
                    counterAttack.resCard = target;
                    counterAttack.targetCard = new ICard[] { res! };
                    if (!flag) { flag = true; }
                    //12.被攻击方预检定反击事件OnBeforeCounterattack()⇒如果返回是True则继续结算
                    if (!target.OnBeforeCounterattack(counterAttack)) { continue; }
                    //12.被攻击方处理反击事件OnCounterattack() :修改ev.value
                    target.OnCounterattack(counterAttack);
                    //13.被反击方预检定受到伤害事件OnBeforeDamage()⇒如果返回是True则继续结算
                    if (!res.OnBeforeDamage(counterAttack)) { continue; }
                    //14.被反击方处理受到伤害事件OnDamage()⇒伤害修正
                    res.OnDamage(counterAttack);
                    //15.被反击方处理受到伤害后事件OnAfterDamage()
                    res.OnAfterDamage(counterAttack);
                    //16.被攻击方处理反击后事件OnAfterCounterattack();
                    target.OnAfterCounterattack(counterAttack);
                    //17.被攻击方处理攻击后事件OnAfterAttack();
                    target.OnAfterAttack(ev);
                }
            }

            //死亡结算
            if (res.isDead)
            {
                if (res.OnBeforeDestroy(eventObject)) { 
                    res.OnDestroy(eventObject);
                    res.OnAfterDestroy(eventObject);
                }
            }
            for (int i = 0; i < targets.Length; i++)
            {
                //为了避免参数干扰 单独拷贝事件对象
                IEventObject ev = new IEventObject(eventObject);
                IInstanceCard target = (IInstanceCard)targets[i];
               
                if (target.isDead)
                {
                    IEventObject counterAttack = new IEventObject();
                    //11.构建反击事件对象:event.resCard,event.targetCard
                    counterAttack.resCard = target;
                    counterAttack.targetCard = new ICard[] { res! };
                    if (target.OnBeforeDestroy(counterAttack))
                    {
                        target.OnDestroy(counterAttack);
                        target.OnAfterDestroy(counterAttack);
                    }
                }
            }
            return flag;
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
