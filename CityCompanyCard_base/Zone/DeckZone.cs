﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityCompanyCard_API.Interface;

namespace CityCompanyCard_API.Zone
{
    public class DeckZone : IZone
    {
        public DeckZone() {
            this.max = 60;
        }

    }
}
