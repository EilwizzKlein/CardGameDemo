using CityCompanyCard_API.Interface;
using CityCompanyCard_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityCompanyCard_API.Manager;
using CityCompanyCard_API.Card;
using CityCompanyCard_base.Buff;

namespace CityCompanyCard_test.unitTest
{
    internal class testBuff
    {
        public static void start() {
            //创建一张卡给主要玩家
            IPlayer player = ApplicationContext.Instance.GetMainPlayer()!;
            ZoneManager.drawCardsToZone(player.deck, player.hand, 1);
            IUnitCard unitCard = (IUnitCard)player.hand.cardList[0];
            //打印此卡的攻击力
            Console.WriteLine(unitCard.attack.getCurrent());
            Console.WriteLine(unitCard.attack.getOrigin());
            //给该卡上一个+3攻的buff
            Console.WriteLine("给该卡上一个+3攻的buff");
            GainAttackTempBuff gat = new GainAttackTempBuff(3, 1);
            unitCard.GainBuff(gat);
            //打印此卡buff后的属性
            Console.WriteLine(unitCard.attack.getCurrent());
            Console.WriteLine(unitCard.attack.getOrigin());
            //再叠加一次buff
            Console.WriteLine("给该卡上一个+7攻的buff");
            GainAttackTempBuff gat2 = new GainAttackTempBuff(7, 1);
            unitCard.GainBuff(gat2);
            //打印此卡buff后的属性
            Console.WriteLine(unitCard.attack.getCurrent());
            Console.WriteLine(unitCard.attack.getOrigin());
            Console.WriteLine("移除第一个buff");
            unitCard.RemoveBuff(gat);
            Console.WriteLine(unitCard.attack.getCurrent());
            Console.WriteLine(unitCard.attack.getOrigin());
        }
    }
}
