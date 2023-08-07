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

namespace CityCompanyCard_API.Card
{
    public abstract class ICard
    {
        public string name = "";
        public string id = "";
        private string UUID = Guid.NewGuid().ToString();
        public int cost;
        public Dictionary<string,int> exCost = new Dictionary<string,int>();
        public CardType type;
        public List<string> subType = new List<string>();
        public IPlayer owner; //拥有者
        public IPlayer controller; //操控者
        public string effect; //效果文字描述
        public Boolean hasInstance; //是否有实体
        private List<IBuff> buffs = new List<IBuff>();
        private IZone currentZone = null;
        private ICard? raw; //原始卡实体

        public string getUUID() { return UUID; }

        public abstract void OnPlay(IEventObject eventObject);
        public abstract void OnAfterPlay(IEventObject eventObject);
        
        public virtual ICard Clone()
        {
            // 使用二进制序列化和反序列化实现深拷贝
            ICard card = (ICard)this.MemberwiseClone();
            card.subType = new List<string>(subType);
            card.exCost = new Dictionary<string, int>(exCost);
            card.UUID = Guid.NewGuid().ToString();
            card.raw = this;
            return card;
        }

        public virtual void GainBuff(IBuff buff)
        {
            buff.OnGainBuff(this);
            buffs.Add(buff);
        }

        public virtual void RemoveBuff(IBuff buff)
        {
            if (buffs.Contains(buff))
            {
                buff.OnRemoveBuff(this);
                buffs.Remove(buff);
            }
        }

        public void setZone(IZone zone)
        {
            this.currentZone = zone;
        }

        public IZone GetZone() { return this.currentZone; }
    }
}
