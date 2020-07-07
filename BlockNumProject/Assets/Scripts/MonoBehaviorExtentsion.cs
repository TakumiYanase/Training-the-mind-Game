//==============================================================================================
/// File Name	: MonoBehaviorExtentsion
/// Summary		: MonoBehaviorの拡張クラス
//==============================================================================================
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
//==============================================================================================

public static class MonoBehaviorExtentsion
{
    //------------------------------------------------------------------------------------------
    // DelayMethod
    //------------------------------------------------------------------------------------------
    public static IEnumerator DelayMethod<T1, T2>(this MonoBehaviour mono, float waitTime, Action<T1, T2> action, T1 t1, T2 t2)
    {
        yield return new WaitForSeconds(waitTime);
        action(t1, t2);
    }

    //------------------------------------------------------------------------------------------
    // DelayMethod
    //------------------------------------------------------------------------------------------
    public static IEnumerator DelayMethod<T>(this MonoBehaviour mono, float waitTime, Action<T> action, T t)
    {
        yield return new WaitForSeconds(waitTime);
        action(t);
    }

    //------------------------------------------------------------------------------------------
    // DelayMethod
    //------------------------------------------------------------------------------------------
    public static IEnumerator DelayMethod(this MonoBehaviour mono, float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}