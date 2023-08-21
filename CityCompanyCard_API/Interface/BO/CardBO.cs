using CityCompanyCard_API.dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface.BO
{
    public class CardBO:IBO<CardBO>
    {
        public string name = "";
        public int cost;
        public CardType type;
        public List<string> subType = new List<string>();
        public List<string> tag = new List<string>();
        public Dictionary<string, int> exCost = new Dictionary<string, int>();
        public string effect = ""; //效果文字描述
        public virtual CardBO clone()
        {
            CardBO bo= new CardBO();
            bo.name = name;
            bo.cost = cost;
            bo.type = type;
            bo.subType = new List<string>(subType);
            bo.tag = new List<string>(subType);
            bo.exCost = new Dictionary<string, int>(exCost);
            bo.effect = new String(effect);
            return bo;
        }
    }
}
