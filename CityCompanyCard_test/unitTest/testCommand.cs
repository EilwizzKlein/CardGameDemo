using CityCompanyCard_API;
using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Card.Command;
using CityCompanyCard_base.Card.Interface;
using CityCompanyCard_base.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_test.unitTest
{
    internal class testCommand
    {
        public static void start()
        {
            //给主要玩家的指令卡堆添加5个基本指令
            MainPlayer player = (MainPlayer)ApplicationContext.Instance.GetCurrentPlayer();
            player.command.AddCommand(new CommandDefence());
            player.command.AddCommand(new CommandMove());
            player.command.AddCommand(new CommandAttack());
            player.command.AddCommand(new CommandGather());
            player.command.AddCommand(new CommandSpecial());
            Console.WriteLine("看看玩家的指令卡的数量(未使用,使用,已使用)");
            Console.WriteLine(player.command.unusedCommand.Count);
            Console.WriteLine(player.command.usingCommand.Count);
            Console.WriteLine(player.command.usedCommand.Count);
            Console.WriteLine("玩家使用指令1,2(未使用,使用,已使用)");
            ICommandCard command1 = player.command.unusedCommand[0];
            ICommandCard command2 = player.command.unusedCommand[1];
            player.command.ChooseCommand(command1);
            player.command.ChooseCommand(command2);
            Console.WriteLine(player.command.unusedCommand.Count);
            Console.WriteLine(player.command.usingCommand.Count);
            Console.WriteLine(player.command.usedCommand.Count);
            Console.WriteLine("回合结束(未使用,使用,已使用)");
            player.command.resetCommand();
            Console.WriteLine(player.command.unusedCommand.Count);
            Console.WriteLine(player.command.usingCommand.Count);
            Console.WriteLine(player.command.usedCommand.Count);
            Console.WriteLine("玩家使用指令1(未使用,使用,已使用)");
            command1 = player.command.unusedCommand[0];
            player.command.ChooseCommand(command1);
            Console.WriteLine(player.command.unusedCommand.Count);
            Console.WriteLine(player.command.usingCommand.Count);
            Console.WriteLine(player.command.usedCommand.Count);
            Console.WriteLine("回合结束(未使用,使用,已使用)");
            player.command.resetCommand();
            Console.WriteLine(player.command.unusedCommand.Count);
            Console.WriteLine(player.command.usingCommand.Count);
            Console.WriteLine(player.command.usedCommand.Count);
        }
    }
}
