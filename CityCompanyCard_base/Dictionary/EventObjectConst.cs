﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_base.Dictionary
{
    public class EventObjectConst
    {
        public class EventObjectType
        {
            public const string PLAY_UNIT_CARD = "打出单位牌触发对象";
            public const string PLAY_COMMAND_CARD = "打出指令牌触发对象";
            public const string HANDLE_COMMAND_CARD = "结算指令牌触发对象";
        }
    }
}
