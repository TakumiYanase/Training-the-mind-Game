﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlockX : MonoBehaviour
{
    private Vector3 m_pos;
    bool m_judge;

    public float minX;
    public float maxX;

    // Use this for initialization
    void Start()
    {
        m_pos = transform.localPosition;
        m_judge = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = m_pos;
        if (m_judge)
        {
            m_pos.x += 0.05f;

            if (m_pos.x > maxX)
            {
                m_judge = false;
            }
        }
        else
        {
            m_pos.x += -0.05f;

            if (m_pos.x < minX)
            {
                m_judge = true;
            }
        }
    }
}
