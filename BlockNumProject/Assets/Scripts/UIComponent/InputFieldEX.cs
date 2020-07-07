//==============================================================================================
/// File Name	: InputFieldEX
/// Summary		: InputFieldを拡張
/// 
/// Author      : Takumi Yanase (柳瀬 拓臣)
//==============================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//==============================================================================================

public class InputFieldEX : InputField
{
    //------------------------------------------------------------------------------------------
    // member variable
    //------------------------------------------------------------------------------------------
    System.Action m_onSubmit;
    public event System.Action onSubmit { add { m_onSubmit += value; } remove { m_onSubmit -= value; } }

    //------------------------------------------------------------------------------------------
    // OnSubmit
    //------------------------------------------------------------------------------------------
    public override void OnSubmit(BaseEventData eventData)
    {
        m_onSubmit?.Invoke();
        base.OnSubmit(eventData);
    }
}
