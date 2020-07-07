//==============================================================================================
/// File Name	: GameInitial
/// Summary		: 実行時に処理する
/// 
/// Author      : Takumi Yanase (柳瀬 拓臣)
//==============================================================================================
using UnityEngine;
using Common;
//==============================================================================================

public class GameInitial
{
    //------------------------------------------------------------------------------------------
    // OnRuntimeMethodLoad
    //------------------------------------------------------------------------------------------
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(Define.SCREEN_WIDTH, Define.SCREEN_HEIGHT, Define.FULL_SCREEN);
    }
}
