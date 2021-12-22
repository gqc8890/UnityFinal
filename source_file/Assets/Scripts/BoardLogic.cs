using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoardLogic : MonoBehaviour
{
    const float MOVE_SPEED = -0.1f;

    [SerializeField]
    int m_dir=1;

    [SerializeField]
    int m_mode = 1;
    // 1 for rotate, 2 for move up and down
    [SerializeField]
    float m_min;
    [SerializeField]
    float m_max;
    [SerializeField]
    float m_speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(m_mode==1)
        {
            transform.Rotate(Vector3.up, m_dir * MOVE_SPEED);
        }
        if(m_mode==2)
        {
            if (transform.localPosition.y<m_min || transform.localPosition.y > m_max)
            {
                m_speed *= -1;
            }
            transform.Translate(Vector3.up * m_speed, Space.World);
        }
        if (m_mode == 3)
        {
            if (transform.localPosition.x <m_min || transform.localPosition.x >m_max)
            {
                m_speed *= -1;
            }
            transform.Translate(Vector3.right * m_speed, Space.World);
        }
        if (m_mode == 4)
        {
            if (transform.localPosition.z < m_min || transform.localPosition.z > m_max)
            {
                m_speed *= -1;
            }
            transform.Translate(Vector3.forward * m_speed, Space.World);
        }
    }
}

