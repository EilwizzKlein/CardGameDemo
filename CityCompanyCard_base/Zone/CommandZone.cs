using CityCompanyCard_API.Interface;
using CityCompanyCard_base.Card.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Zone
{
    public class CommandZone : IZone
    {
        public List<ICommandCard> usedCommand = new List<ICommandCard>();
        public List<ICommandCard> unusedCommand = new List<ICommandCard>();
        public List<ICommandCard> usingCommand = new List<ICommandCard>();
        public void AddCommand(ICommandCard command)
        {
            cardList.Add(command);
            unusedCommand.Add(command);
        }

        public void resetCommand()
        {
            unusedCommand.AddRange(usedCommand);
            usedCommand.Clear();
            usedCommand.AddRange(usingCommand);
            usingCommand.Clear();
        }

        public void ChooseCommand(ICommandCard command)
        {
            if(unusedCommand.Contains(command))
            {
                unusedCommand.Remove(command);
                usingCommand.Add(command);
            }
        }
        public void RemoveCommand(ICommandCard command)
        {
            if (usedCommand.Contains(command))
            {
                usedCommand.Remove(command);
            }
            if (unusedCommand.Contains(command))
            {
                unusedCommand.Remove(command);
            }
            if (usingCommand.Contains(command))
            {
                usingCommand.Remove(command);
            }
            cardList.Remove(command);
        }
    }
}
