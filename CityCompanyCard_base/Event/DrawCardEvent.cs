﻿using CityCompanyCard_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Event
{
    public class DrawCardEvent : IEvent
    {
        public DrawCardEvent(IEventObject eventObject) : base(eventObject)
        {
        }

        public override void Run(IEventObject ev, bool isRoot)
        {
            throw new NotImplementedException();
        }
    }
}
