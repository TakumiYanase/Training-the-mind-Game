//==============================================================================================
/// File Name	: SingletonMonoBehaviour
/// Summary		: 継承したスクリプトをシングルトンにする
/// 
/// Author      : Takumi Yanase (柳瀬 拓臣)
//==============================================================================================
using UnityEngine;
using System;
//==============================================================================================

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    //------------------------------------------------------------------------------------------
    // member variable
    //------------------------------------------------------------------------------------------
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Type t = typeof(T);

                instance = (T)FindObjectOfType(t);
                if (instance == null)
                {
                    Debug.LogError(t + " をアタッチしているGameObjectはありません");
                }
            }

            return instance;
        }
    }

    //------------------------------------------------------------------------------------------
    // Awake
    //------------------------------------------------------------------------------------------
    virtual protected void Awake()
    {
        // 他のゲームオブジェクトにアタッチされているか調べる
        // アタッチされている場合は破棄する。
        CheckInstance();
    }

    //------------------------------------------------------------------------------------------
    // CheckInstance
    //------------------------------------------------------------------------------------------
    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = this as T;
            return true;
        }
        else if (Instance == this)
        {
            return true;
        }
        Destroy(this);
        return false;
    }
}