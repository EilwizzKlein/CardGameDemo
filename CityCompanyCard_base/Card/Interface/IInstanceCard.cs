using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Interface.Instance;
using CityCompanyCard_API.Manager;
using CityCompanyCard_API.RenderObject;
using CityCompanyCard_base.BO;
using CityCompanyCard_base.Power.BasePower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Card.Interface
{
    public abstract class IInstanceCard:ICard
    {
        private RenderBool _canBeChosen = new RenderBool(false);
        public RenderBool IsCanBeChosen { get => _canBeChosen; }
        public bool isDead = false;

        public IInstanceCard()
        {
            this.originCardBO = new InstanceCardBO();
            this.renderCardBO = originCardBO.clone();
        }


        public override void OnRerender()
        {
            base.OnRerender();
            if (((InstanceCardBO)renderCardBO).currentHealth <= 0) { isDead = true; }
            else { isDead = false; }
        }
        //能力相关
        //使用能力前
        public virtual Boolean OnBeforeUsePower(IEventObject eventObject) {
            Boolean flag = true;
            this.attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    flag = flag && ((IInstanceCard)card).OnBeforeUsePower(eventObject);
                }
            });
            return flag; 
        }
        //使用能力后
        public virtual void OnAfterUsePower(IEventObject eventObject) {
            attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                     ((IInstanceCard)card).OnAfterUsePower(eventObject);
                }
            });
        }
        //结算能力使用
        //目标相关
        //被选为目标前
        public virtual Boolean OnBeforeChoose(IEventObject eventObject) {
            Boolean flag = true;
            this.attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    flag = flag && ((IInstanceCard)card).OnBeforeChoose(eventObject);
                }
            });
            return flag; }
        //被选为目标后
        public virtual void OnAfterChoose(IEventObject eventObject) {
            attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    ((IInstanceCard)card).OnAfterChoose(eventObject);
                }
            });
        }
        //受到攻击前
        public virtual Boolean OnBeforeAttacked(IEventObject eventObject)
        {
            Boolean flag = true;
            this.attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    flag = flag && ((IInstanceCard)card).OnBeforeAttacked(eventObject);
                }
            });
            return flag;
        }
        //受到攻击后
        public virtual void OnAfterAttacked(IEventObject eventObject) {
            attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    ((IInstanceCard)card).OnAfterAttacked(eventObject);
                }
            });
        }
        //受到攻击前
        public virtual Boolean OnBeforeCounterattack(IEventObject eventObject)
        {
            Boolean flag = true;
            this.attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    flag = flag && ((IInstanceCard)card).OnBeforeCounterattack(eventObject);
                }
            });
            return flag;
        }
        //受到攻击后
        public virtual void OnAfterCounterattack(IEventObject eventObject) {
            attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    ((IInstanceCard)card).OnAfterCounterattack(eventObject);
                }
            });
        
        }
        //受到伤害前
        public virtual Boolean OnBeforeDamage(IEventObject eventObject)
        {
            Boolean flag = true;
            this.attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    flag = flag && ((IInstanceCard)card).OnBeforeDamage(eventObject);
                }
            });
            return flag;
        }
        //受到伤害时
        //受到伤害后
        public virtual void OnAfterDamage(IEventObject eventObject) {
            attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    ((IInstanceCard)card).OnAfterDamage(eventObject);
                }
            });
        }
        //受到回复前
        public virtual Boolean OnBeforeHeal(IEventObject eventObject)
        {
            Boolean flag = true;
            this.attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    flag = flag && ((IInstanceCard)card).OnBeforeHeal(eventObject);
                }
            });
            return flag;
        }
        //受到回复时
        //受到回复后
        public virtual void OnAfterHeal(IEventObject eventObject) {
            attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    ((IInstanceCard)card).OnAfterHeal(eventObject);
                }
            });
        }
        //被摧毁前
        public virtual Boolean OnBeforeDestroy(IEventObject eventObject)
        {
            Boolean flag = true;
            this.attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    flag = flag && ((IInstanceCard)card).OnBeforeDestroy(eventObject);
                }
            });
            return flag;
        }
        //被摧毁后
        public virtual void OnAfterDestroy(IEventObject eventObject) {
            attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    ((IInstanceCard)card).OnAfterDestroy(eventObject);
                }
            });
        }
        //被牺牲前
        public virtual Boolean OnBeforeSacrifice(IEventObject eventObject)
        {
            Boolean flag = true;
            this.attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    flag = flag && ((IInstanceCard)card).OnBeforeSacrifice(eventObject);
                }
            });
            return flag;
        }
        //被牺牲后
        public virtual void OnAfterSacrifice(IEventObject eventObject) {
            attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    ((IInstanceCard)card).OnAfterSacrifice(eventObject);
                }
            });
        }
        //死亡前
        public virtual Boolean OnBeforeDie(IEventObject eventObject)
        {
            Boolean flag = true;
            this.attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    flag = flag && ((IInstanceCard)card).OnBeforeDie(eventObject);
                }
            });
            return flag;
        }
        //死亡后
        public virtual void OnAfterDie(IEventObject eventObject)
        {
            attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    ((IInstanceCard)card).OnAfterDie(eventObject);
                }
            });

            Console.WriteLine("啊我死了");
        }

        public virtual Boolean OnBeforeMove(IEventObject eventObject)
        {
            Boolean flag = true;
            this.attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    flag = flag && ((IInstanceCard)card).OnBeforeMove(eventObject);
                }
            });
            return flag;
        }
        //离开战场后
        public virtual void OnAfterMove(IEventObject eventObject)
        {
            attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    ((IInstanceCard)card).OnAfterMove(eventObject);
                }
            });
        }

        //移动区域前
        public virtual Boolean OnBeforeMoveZone(IEventObject eventObject)
        {
            Boolean flag = true;
            this.attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    flag = flag && ((IInstanceCard)card).OnBeforeMoveZone(eventObject);
                }
            });
            return flag;
        }
        //移动区域后
        public virtual void OnAfterMoveZone(IEventObject eventObject)
        {
            attachmentZone.effectAttachment.ForEach(card =>
            {
                if (card is IInstanceCard)
                {
                    ((IInstanceCard)card).OnAfterMoveZone(eventObject);
                }
            });
        }
    }
}
