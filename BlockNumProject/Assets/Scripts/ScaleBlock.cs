using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBlock : MonoBehaviour
{

    private Vector3 m_scale;
    bool m_judge;

    public float minScale;
    public float maxScale;

    // Start is called before the first frame update
    void Start()
    {
        m_scale = transform.localScale;
        m_judge = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = m_scale;
        if(m_judge)
        {
            m_scale += new Vector3(0.02f, 0.02f, 0.02f);

            if(m_scale.x > maxScale)
            {
                m_judge = false;
            }
        }
        else
        {
            m_scale -= new Vector3(0.02f, 0.02f, 0.02f);

            if (m_scale.x < minScale)
            {
                m_judge = true;
            }
        }
    }
}
