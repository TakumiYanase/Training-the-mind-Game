using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldEX : InputField
{
    System.Action m_onSubmit;
    public event System.Action onSubmit { add { m_onSubmit += value; } remove { m_onSubmit -= value; } }

    public override void OnSubmit(BaseEventData eventData)
    {
        m_onSubmit?.Invoke();
        base.OnSubmit(eventData);
    }
}
