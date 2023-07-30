﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCompanyCard_API.BattleGround
{
    public class IBattleGround
    {
        public string name;
        public int width;
        public int height;
        public IBattleGroundTile[] battleGrounds;

        public void Init()
        {
            if (width > 0 && height > 0)
            {
                // 初始化一维数组
                battleGrounds = new IBattleGroundTile[width * height];

                // 批量赋值每个数组元素
                for (int i = 0; i < battleGrounds.Length; i++)
                {
                    battleGrounds[i] = new IBattleGroundTile();
                }
            }
            else
            {
                throw new Exception("区域宽或高小于0");
            }
        }
    }
}
