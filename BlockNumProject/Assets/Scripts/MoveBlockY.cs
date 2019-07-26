using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlockY : MonoBehaviour {

    private Vector3 m_pos;
    bool m_judge;

    public float minY;
    public float maxY;

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
            m_pos.y += 0.05f;

            if(m_pos.y > maxY)
            {
                m_judge = false;
            }
        }
        else
        {
            m_pos.y += -0.05f;

            if (m_pos.y < minY)
            {
                m_judge = true;
            }
        }
    }
}
