using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationY : MonoBehaviour
{
    public void Update()
    {
        this.gameObject.transform.Rotate(0.0f, 0.5f, 0.0f);
    }
}
