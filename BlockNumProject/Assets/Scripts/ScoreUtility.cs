﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreUtility
{
    public struct RankingData
    {
        // スコア
        public int first;
        public int second;
        public int third;
        public int newScore;

        // 年
        public int yearFirst;
        public int yearSecond;
        public int yearThird;

        // 月
        public int monthFirst;
        public int monthSecond;
        public int monthThird;

        // 日
        public int dayFirst;
        public int daySecond;
        public int dayThird;
    }
}
