using UnityEngine;

using Common;

public class GameInitial
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(Define.SCREEN_WIDTH, Define.SCREEN_HEIGHT, Define.FULL_SCREEN);
    }
}
