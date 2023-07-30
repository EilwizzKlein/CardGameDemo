﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public abstract class ITrigger
    {
        public bool deleteSelf { get; protected set; }

        public ITrigger()
        {
            deleteSelf = false; // 设置初始值为 false
        }
        public abstract void Run(IEventObject eventObject);


    }
}
