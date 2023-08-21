using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.dictionary;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using CityCompanyCard_API.Utils;
using CityCompanyCard_API.Interface.BO;
using CityCompanyCard_API.Interface.Instance;
using System.Xml.Linq;
using static CityCompanyCard_API.Interface.IPower;

namespace CityCompanyCard_API.Card
{
    public abstract class ICard
    {
        private Dictionary<string, List<IPower>> powers = new Dictionary<string, List<IPower>>();
        public CardBO originCardBO = new CardBO();
        public CardBO renderCardBO = new CardBO();
        public string id = "";
        private string UUID = Guid.NewGuid().ToString();
        public CardType type;
        public IPlayer owner; //拥有者
        public IPlayer controller; //操控者
        private List<IBuff> buffs = new List<IBuff>();
        private IZone currentZone = null;
        private AttachmentZone attachmentZone = new AttachmentZone();
        public string getUUID() { return UUID; }

        
        public abstract void OnBeforePlay(IEventObject eventObject);
        public abstract void OnPlay(IEventObject eventObject);
        public abstract void OnAfterPlay(IEventObject eventObject);
        public abstract void OnBeforeDraw(IEventObject eventObject);
        public abstract void OnAfterDraw(IEventObject eventObject);


        public ICard() {
            renderCardBO = originCardBO.clone();
        }
        public void Clone()
        {
            // 使用二进制序列化和反序列化实现深拷贝
            renderCardBO = originCardBO.clone();
        }

        public virtual void GainBuff(IBuff buff)
        {
            buffs.Add(buff);
            renderBuff();
        }

        public virtual void RemoveBuff(IBuff buff)
        {
            if (buffs.Contains(buff))
            {
                buffs.Remove(buff);
                renderBuff();
            }
        }

        public void renderBuff()
        {
            renderCardBO = originCardBO.clone();
            buffs.ForEach(buff =>
            {
                buff.renderBuff(renderCardBO);
            });
        }

        public void setZone(IZone zone)
        {
            this.currentZone = zone;
        }

        public void AddPower(string name, int uses, OnAbilityAction action)
        {
            if (!powers.ContainsKey(name))
            {
                powers[name] = new List<IPower>();
            }

            powers[name].Add(new IPower(name, uses, action));
        }

        public void AddPower(string name, IPower power)
        {
            if (!powers.ContainsKey(name))
            {
                powers[name] = new List<IPower>();
            }

            powers[name].Add(power);
        }

        public List<IPower> getPower(string powerKey)
        {
            if (powers.ContainsKey(powerKey))
            {
                return powers[powerKey];
             
            }
            return null;

        }

        public int HasPower(string powerKey) {
            if (powers.ContainsKey(powerKey)) {
                List<IPower> powerList = powers[powerKey];
                for(int i = 0; i < powerList.Count;i++)
                {
                    if (powerList[i].currentUseTime > 0 || powerList[i].currentUseTime == -1) {
                        return 1;
                    }
                }
                return 0;

            }
            return -1;

        }
        public IZone GetZone() { return this.currentZone; }
    }
}
