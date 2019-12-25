using UnityEngine;
using System.Collections;

namespace Common
{
    public static class Define
    {
        // スクリーン
        public const int SCREEN_WIDTH = (960);
        public const int SCREEN_HEIGHT = (540);
        public const bool FULL_SCREEN = false;

        // ファイルパス
        public const string SAVE_FILE_PATH = "/Ranking.txt";
        public const string PREFAB_PATH = "Prefabs/CountDown";

        // シーン
        public const int SCENE_TITLE = (0);
        public const int SCENE_READY = (1);
        public const int SCENE_RANKING = (2);
        public const int SCENE_STAGESELECT = (3);
        public const int SCENE_RESULT = (4);

        // ステージ
        public const int STAGE_BEGIN = (5);
        public const int STAGE_END = (29);
        // Rand関数用
        public const int STAGE_END_RAND_ONLY = (30);

        // ランキングリスト
        public const int RANKING_LIST_END = (3);

        // オブジェクト
        public const string COUNT_DOWN_PREFAB = "CountDown(Clone)";

        // カウントダウン
        public const float COUNT_TIME_INIT = (300.0f);
        public const float COUNT_LIMITED_TIME_MIN = (5.0f);
        public const float COUNT_LIMITED_TIME_MAX = (999.0f);
        public const int COUNT_TIME_MAX = (999);
    }
}