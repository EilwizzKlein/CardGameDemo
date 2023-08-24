using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.RenderObject;
using CityCompanyCard_base.BO;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.Power.BasePower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Card
{
    public class IUnitCard : IInstanceCard
    {

        public IUnitCard() { 
            InitDefaultPower();
        }

        public virtual void InitDefaultPower()
        {
            this.AddPower("防御", new BaseDefancePower("防御", 1));
            this.AddPower("攻击", new BaseAttackPower("攻击", 1));
            this.AddPower("移动", new BaseDefancePower("移动", 1));
        }

        //反击结算前
        public virtual Boolean OnBeforeCounterattack(IEventObject eventObject)        {            return true;        }
        //反击结算时
        public virtual void OnCounterattack(IEventObject eventObject) {  }
        //反击结算后
        public virtual void OnAfterCounterattack(IEventObject eventObject) {  }

        public void InitAttack(int value)
        {
            ((InstanceCardBO)originCardBO).maxAttack = value;
            ((InstanceCardBO)originCardBO).currentAttack = value;
            this.Render();
        }
        public void InitHealth(int value)
        {
            ((InstanceCardBO)originCardBO).maxHealth = value;
            ((InstanceCardBO)originCardBO).currentHealth = value;
            this.Render();
        }

        public override void OnAttack(IEventObject eventObject)
        {
           IEventObject ev = new IEventObject(eventObject);
            //获取到来源的攻击力
            int attack = ((InstanceCardBO)eventObject.resCard.renderCardBO).currentAttack;
            ev.value = attack;
            //结算伤害

        }
    }
}
