using CityCompanyCard_API.RenderObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.Interface
{
    public interface ITarget
    {
        public RenderBool canBeChosen { get; }
        public abstract Boolean beforeChosen(IEventObject ev) ;
    }
}
