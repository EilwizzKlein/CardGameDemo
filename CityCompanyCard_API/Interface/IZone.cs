using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityCompanyCard_API.Card;

namespace CityCompanyCard_API.Interface
{
    public class IZone
    {
        public List<ICard> cardList = new List<ICard>();
        public int max;

        public void sufferZone()
        {
            //检查自身的cardList是不是空
            if (cardList != null && cardList.Count > 0)
            {
                Random random = new Random();
                int n = cardList.Count;
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    ICard value = cardList[k];
                    cardList[k] = cardList[n];
                    cardList[n] = value;
                }
            }
        }
    }
}
