using CityCompanyCard_API.Factory;
using CityCompanyCard_API.Interface;
using CityCompanyCard_API.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API
{
    public class ApplicationContext
    {
        private int _playerIndex = 0;
        private static ApplicationContext _instance = new ApplicationContext();
        private static readonly object lockObject = new object();
        private  IPlayer? _currentPlayer;
        public List<IPlayer> Player = new List<IPlayer>();
        public Dictionary<string,IBattleGround> BattleZone = new Dictionary<string, IBattleGround>(); //战场元素
        public Dictionary<string, ITrigger> Trigger = new Dictionary<string, ITrigger>(); //触发器组
        public Boolean isInit = false; //是否完成初始化
        private  IMode? _mode = null; //模式对象
        public Thread SelectorThread = null;
        public CardManagerFactory? cardManagerFactory; //卡牌管理器工厂 为空避免写加载的时候忘了配置cmf
        private IState? _currentState;

        public IPlayer changeNextPlayer()
        {
            _playerIndex = (_playerIndex+ 1) % Player.Count;
            _currentPlayer = Player[_playerIndex];
            return _currentPlayer;
        }

        public  void  SetMode(IMode mode) {
            _mode = mode;
        }

        public  void SetCurrentPlayer(IPlayer currentPlayer) {
            _currentPlayer = currentPlayer;
         }

        public  IPlayer GetCurrentPlayer() {
            return _currentPlayer!;
        }

        public void SetCurrentState(IState currentState)
        {
            _currentState = currentState;
        }

        public IState GetCurrentState()
        {
            return _currentState!;
        }
        public  Boolean Init()
        {
            bool flag = true;
            if (_mode == null) {
                throw new Exception("初始化未赋值模式");
            }
            flag = flag && _mode.InitApp();
            if (cardManagerFactory == null) {
                throw new Exception("初始化未赋值卡牌管理器");
            }
            if (_currentState == null) {
                throw new Exception("未设置初始状态");
            }
            return flag;
        }

        public void RegisterPlayer(IPlayer player)
        {
           Player.Add(player);
            if(_currentPlayer is null)
            {
                _currentPlayer = player;
            }
        }

        // 私有构造函数，防止外部实例化对象
        private ApplicationContext() { }

        /// <summary>
        /// 获取application实例
        /// </summary>
        public static ApplicationContext Instance
        {
            get
            {
                // 使用双重检查锁定确保线程安全
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new ApplicationContext();
                        }
                    }
                }

                return _instance;
            }
        }
        /// <summary>
        /// 获取一个新的实例,用于彻底初始化
        /// </summary>
        internal static ApplicationContext getNewInstance
        {
            get
            {
                lock (lockObject)
                {
                    _instance = new ApplicationContext();
                }

                return _instance;
            }
        }
    }
}
