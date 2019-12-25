using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlockZ : MonoBehaviour
{
    private Vector3 m_pos;
    bool m_judge;

    public float minZ;
    public float maxZ;

    public void Awake()
    {
        m_pos = transform.localPosition;
        m_judge = true;
    }

    public void Update()
    {
        transform.localPosition = m_pos;
        if (m_judge)
        {
            m_pos.z += -0.05f;

            if (m_pos.z < maxZ)
            {
                m_judge = false;
            }
        }
        else
        {
            m_pos.z += 0.05f;

            if (m_pos.z > minZ)
            {
                m_judge = true;
            }
        }
    }
}
