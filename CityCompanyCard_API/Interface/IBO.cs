using CityCompanyCard_API.Interface.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public interface IBO<T>
    {
        public abstract T clone();
    }
}
