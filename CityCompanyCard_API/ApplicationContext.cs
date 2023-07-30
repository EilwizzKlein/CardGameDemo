﻿using CityCompanyCard_API.BattleGround;
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
        private static ApplicationContext _instance = new ApplicationContext();
        private static readonly object lockObject = new object();
        private  IPlayer? _mainPlayer;
        public List<IPlayer> Player = new List<IPlayer>();
        public Dictionary<string,IBattleGround> BattleZone = new Dictionary<string, IBattleGround>(); //战场元素
        public Boolean isInit = false; //是否完成初始化
        private  IMode? _mode = null; //模式对象
        public CardManager cardManager = null; 

        public  void  SetMode(IMode mode) {
            _mode = mode;
        }

        public  void SetMainPlayer(IPlayer mainPlayer) {
            _mainPlayer = mainPlayer;
         }

        public  IPlayer? GetMainPlayer() {
            return _mainPlayer;
        }

        public  Boolean Init()
        {
            bool flag = true;
            if (_mode == null) {
                throw new Exception("初始化未赋值模式");
            }
            flag = flag && _mode.InitApp();
            if (_mainPlayer == null) {
                throw new Exception("初始化未赋值主玩家");
            }
            if (cardManager == null) {
                throw new Exception("初始化未赋值卡牌管理器");
            }
            return flag;
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
