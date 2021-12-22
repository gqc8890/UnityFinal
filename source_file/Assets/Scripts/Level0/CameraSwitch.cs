using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum switchPhase
{
    p_1,
    p_2
}
public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    switchPhase phase;

    CameraLogic[] m_cameras;

    void Start()
    {
        m_cameras = FindObjectsOfType<CameraLogic>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (phase == switchPhase.p_1)
            {
                m_cameras[0].mode = CameraState.lookback;
                m_cameras[1].mode = CameraState.lookback;
            }
                
            else
            {
                m_cameras[0].mode = CameraState.final;
                m_cameras[1].mode = CameraState.final;
            }
                
        }
    }
}
