﻿using CityCompanyCard_API.dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.RenderObject;
using CityCompanyCard_base.BO;
using CityCompanyCard_base.Power.BasePower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Card
{
    public class IUnitCard : ICard,ITarget
    {
        int actionPoint = 5;

        private RenderBool _canBeChosen = new RenderBool(false);
        public RenderBool canBeChosen { get => _canBeChosen; }
 
        public IUnitCard()
        {
            this.originCardBO = new UnitCardBO();
            this.renderCardBO = originCardBO.clone();
            this.type = CardType.Unit;
            InitDefaultPower();
        }

        public virtual void InitDefaultPower()
        {
            this.AddPower("防御", new BaseDefancePower("防御", 1));
            this.AddPower("攻击", new BaseAttackPower("攻击", 1));
            this.AddPower("移动", new BaseDefancePower("移动", 1));
        } 

        public void OnStartPower(IEventObject eventObject)
        {

        }

        public void AfterCommand(IEventObject eventObject) { 
        
        }
     

        public void InitAttack(int value)
        {
            ((UnitCardBO)originCardBO).maxAttack = value;
            ((UnitCardBO)originCardBO).currentAttack = value;
            this.renderBuff();
        }
        public void InitHealth(int value)
        {
            ((UnitCardBO)originCardBO).maxHealth = value;
            ((UnitCardBO)originCardBO).currentHealth = value;
            this.renderBuff();
        }

        public override void OnPlay(IEventObject eventObject)
        {
            //打出卡牌
        }

        public override  void OnAfterPlay(IEventObject eventObject)
        {
        }

        public override void OnBeforeDraw(IEventObject eventObject)
        {
           
        }

        public override void OnAfterDraw(IEventObject eventObject)
        {
        }

        public override void OnBeforePlay(IEventObject eventObject)
        {
        }

        public virtual bool beforeChosen(IEventObject ev)
        {
            return true;
        }
    }
}
