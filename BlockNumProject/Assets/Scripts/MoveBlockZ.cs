using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlockZ : MonoBehaviour
{
    private Vector3 m_pos;
    bool m_judge;

    public float minZ;
    public float maxZ;

    // Use this for initialization
    void Start()
    {
        m_pos = transform.localPosition;
        m_judge = true;
        //minZ = 0.0f;
        //maxZ = 1.0f;
    }

    // Update is called once per frame
    void Update()
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
