using UnityEngine;

public class GameInitial
{
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Screen.SetResolution(1920, 1080, false, 60);
    }
}
