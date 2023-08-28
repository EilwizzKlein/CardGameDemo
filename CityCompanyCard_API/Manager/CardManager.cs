using CityCompanyCard_API.Card;
using CityCompanyCard_API.Dictionary;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CityCompanyCard_API.Manager
{
    public class CardManager
    {
        private Dictionary<string, Type> cardMap = new Dictionary<string, Type>();
        public void gainAttachment(ICard res, IEventObject eventObject) { }
        public ICard? getCardByClass(string className)
        {
            //根据cardMap获取type
           if(cardMap.TryGetValue(className, out Type card))
            {
                object instance = Activator.CreateInstance(card);

                if (instance is ICard myObject)
                {
                    return (ICard)myObject;
                }
            }
            return null;
        }
        
        public Boolean loadCardMap(Dictionary<string, Type> map) {
            foreach (string key in map.Keys)
            {
                if (!cardMap.ContainsKey(key))
                {
                    cardMap.Add(key, map[key]);
                }
            }
            return true; 
        }
    }
}
