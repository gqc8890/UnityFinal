using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGtransform : MonoBehaviour
{
    const float PATROL_SPEED = .5f;
    const float WALK_BACK_SPEED = .18f;
    const float RUN_SPEED = 1.5f;

    const float WALK_BACK_DUR = 1.5f;

    float walkbacktime = 0.0f;
    [SerializeField]
    Transform targetTrans;
    [SerializeField]
    Camera m_camera;

    CameraLogic[] m_cameras;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        m_cameras = FindObjectsOfType<CameraLogic>();
    }
    // Update is called once per frame
    void Update()
    {
        if(m_cameras[0].mode == CameraState.patrol)
            transform.position = Vector3.MoveTowards(transform.position, targetTrans.position, Time.deltaTime * PATROL_SPEED);
        else if(m_cameras[0].mode == CameraState.lookback)
        {
            walkbacktime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetTrans.position, Time.deltaTime * WALK_BACK_SPEED);
            if(walkbacktime >= WALK_BACK_DUR)
            {
                m_cameras[0].mode = CameraState.run;
                m_cameras[1].mode = CameraState.run;
            }
        }
        else if(m_cameras[0].mode == CameraState.run)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTrans.position, Time.deltaTime * RUN_SPEED);
        }
        else
        {
            if(m_cameras[0].final_time >= 4.0f)
                transform.position = Vector3.MoveTowards(transform.position, targetTrans.position, Time.deltaTime * PATROL_SPEED);
        }
    }
}
