using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.BO
{
    /// <summary>
    /// 渲染的布尔值,propose为目的,如果有目的,并且目的中的所有值都为正,返回和原有值相反的布尔值,否则返回原始值
    /// </summary>
    public class RenderBool
    {
        private Dictionary<string, int> _propose = new Dictionary<string, int>();

        private Boolean _originBool = false;

        private Boolean _renderBool = false;


        public void addPropose(string propose,int value)
        {
            if (_propose.ContainsKey(propose))
            {
                _propose[propose] += value;
            }
            else
            {
                _propose.Add(propose,value);
            }
        }

        public void removePropose(string propose,int value) {

            if (_propose.ContainsKey(propose))
            {
                if (_propose[propose] < 0)
                {
                    _propose[propose] -= value;
                    if (_propose[propose] >= 0)
                    {
                        _propose.Remove(propose);
                    }
                }
                else
                {
                    _propose[propose] -= value;
                    if (_propose[propose] <= 0)
                    {
                        _propose.Remove(propose);
                    }
                }
               
            }
        }

        public void clearPropose(string propose, int value)
        {

            _propose = new Dictionary<string, int>();
            _renderBool = _originBool;
        }

        public Boolean getRenderBool() {
            _renderBool = !_originBool;
            foreach (KeyValuePair<string, int> kvp in _propose)
            {
                if(kvp.Value < 0)
                {
                    _renderBool = _originBool;
                };
            }
            return _renderBool;
        }

        public void setOriginBool(Boolean value)
        {
               _originBool = value;
        }
    }
}
