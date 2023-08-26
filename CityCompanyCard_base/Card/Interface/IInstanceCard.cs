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

        public override void OnPlay(IEventObject eventObject)
        {
          
        }

        public override void OnRerender()
        {
            base.OnRerender();
            if (((InstanceCardBO)renderCardBO).currentHealth <= 0) { isDead = true; }
            else { isDead = false; }
        }
        //能力相关
        //使用能力前
        public virtual Boolean OnBeforeUsePower(IEventObject eventObject) { return true; }
        //使用能力后
        public virtual void OnAfterUsePower(IEventObject eventObject) {  }
        //结算能力使用
        public virtual void OnUsePower(IEventObject eventObject) { }
        //目标相关
        //被选为目标前
        public virtual Boolean OnBeforeChoose(IEventObject eventObject) { return true; }
        //被选为目标时
        public virtual void OnChoose(IEventObject eventObject) {}
        //被选为目标后
        public virtual void OnAfterChoose(IEventObject eventObject) { }
        //受到攻击前
        public virtual Boolean OnBeforeAttack(IEventObject eventObject) { return true; }
        //受到攻击时
        public virtual void OnAttack(IEventObject eventObject) { }
        //受到攻击后
        public virtual void OnAfterAttack(IEventObject eventObject) { }
        //受到攻击前
        public virtual Boolean OnBeforeCounterattack(IEventObject eventObject) { return true; }
        //受到攻击时
        public virtual void OnCounterattack(IEventObject eventObject) {
            this.Render();
            eventObject.value = ((InstanceCardBO)renderCardBO).currentAttack;
        }
        //受到攻击后
        public virtual void OnAfterCounterattack(IEventObject eventObject) { }
        //受到伤害前
        public virtual Boolean OnBeforeDamage(IEventObject eventObject) { return true; }
        //受到伤害时
        public virtual void OnDamage(IEventObject eventObject) {
            int value = eventObject.value;
            ((InstanceCardBO)originCardBO).currentHealth -= value;
            this.Render();
        }
        //受到伤害后
        public virtual void OnAfterDamage(IEventObject eventObject) { }
        //受到回复前
        public virtual Boolean OnBeforeHeal(IEventObject eventObject) { return true; }
        //受到回复时
        public virtual void OnHeal(IEventObject eventObject) { }
        //受到回复后
        public virtual void OnAfterHeal(IEventObject eventObject) { }
        //被摧毁前
        public virtual Boolean OnBeforeDestroy(IEventObject eventObject) { return true; }
        //被摧毁时
        public virtual void OnDestroy(IEventObject eventObject) {
            Console.WriteLine("啊我死了");
        }
        //被摧毁后
        public virtual void OnAfterDestroy(IEventObject eventObject) { }
        //被牺牲前
        public virtual Boolean OnBeforeSacrifice(IEventObject eventObject) { return true; }
        //被牺牲时
        public virtual void OnSacrifice(IEventObject eventObject) { }
        //被牺牲后
        public virtual void OnAfterSacrifice(IEventObject eventObject) { }

    }
}
