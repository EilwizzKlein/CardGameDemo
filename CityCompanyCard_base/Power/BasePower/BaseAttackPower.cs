using CityCompanyCard_API;
using CityCompanyCard_API.Card;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.BO;
using CityCompanyCard_base.Event;
using CityCompanyCard_base.Selector.PanelSelector.UnitSeletor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Power.BasePower
{
    public class BaseAttackPower : IBasePower
    {
        public BaseAttackPower(string _description, int _maxUseTime) : base(_description, _maxUseTime)
        {
            this.baseName = "攻击";
        }
        public override void AbilityAction(IEventObject ev) {
            //1.构建攻击事件对象(空event)
            //2.构建攻击方:event.resCard
            IUnitCard res = ev.resCard as IUnitCard;
            //选择进攻目标
            new Selector_UnitFilterByDistance<IUnitCard>().startISeletor(ev, out IUnitCard[] cards);
            if(cards != null && cards.Length>0) {

                //3.通过目标选择器构建被攻击目标:event.targetCard
                ev.targetCard = cards;
                ev.value = ((InstanceCardBO)res.renderCardBO).currentAttack;
                //4.攻击方预检定OnBeforePower()⇒如果返回是True则继续结算
                if (!res.OnBeforeUsePower(ev)) { return; }
                //调用处理器
                new AttackEvent(ev).Run();
                res.OnAfterUsePower(ev);
            }
            //结束进攻效果
        }
    }
}
