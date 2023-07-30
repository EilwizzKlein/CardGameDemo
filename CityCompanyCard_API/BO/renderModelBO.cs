using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.BO
{
    public class renderModelBO
    {
        private int _origin;
        private int _max;
        private int _current;

        public void init(int value)
        {
            _origin = value;
            _max = value;
            _current = value;
        }

        public void setMax(int value)
        {
            _max = value;
            if (_current > _max)
            {
                _current = _max;
            }
        }
        public void setCurrent(int value)
        {
            _origin = value;
            _max = value;
            _current = value;
        }
        public int getCurrent()
        {
            return _current;
        }

        public int getOrigin()
        {
            return _origin;
        }

        public int getMax()
        {
            return _max;
        }

        public void addValue(int value)
        {
            this._current += value;
            this._max += value;
            if (this._current > this._max)
            {
                this._current = this._max;
            }
        }

        public void addCurrentValue(int value)
        {
            this._current += value;
            if (this._current > this._max)
            {
                this._current = this._max;
            }
        }

        public void reduceValue(int value)
        {
            this._current -= value;
            this._max -= value;
            if (this._current > this._max)
            {
                this._current = this._max;
            }
        }

        public void reduceCurrentValue(int value)
        {
            this._current -= value;
            if (this._current > this._max)
            {
                this._current = this._max;
            }
        }
    }
}
