using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraState
{
    patrol,
    lookback,
    run,
    final
}

public class CameraLogic : MonoBehaviour
{
    public const float FINAL_DELAY = 4.0f;
    const float PATROL_PHASE = 3.0f;
    const float LOOKAROUND = 2.0f;
    
    const float CAMERA_X_OFFSET = -.01f;

    const float CAMERA_X_ROT = 15.0f;
    const float CAMERA_Y_ROT = 30.0f;


    public float final_time = 0.0f;
    float patrol_time = 0.0f;
    float look_time = 0.0f;
    bool lookaround = false;
    int lookphase = 0;

    public CameraState mode = CameraState.patrol;

    Vector3 m_cameraTarget;

    GameObject m_player;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_cameraTarget = m_player.transform.position;
        transform.position = m_cameraTarget + new Vector3(CAMERA_X_OFFSET, 0, 0);
        transform.LookAt(m_cameraTarget);
    }

    // Update is called once per frame
    void Update()
    {
        m_cameraTarget = m_player.transform.position;
        m_cameraTarget.y += .88f;
    }

    void LateUpdate()
    {
        // Calculate Rotation based on Mouse Movement
        transform.position = m_cameraTarget + new Vector3(CAMERA_X_OFFSET, 0, 0);
        if (mode == CameraState.patrol)
        {
            //transform.position = m_cameraTarget + new Vector3(0, 0, CAMERA_Z_OFFSET);
            if (patrol_time >= PATROL_PHASE)
            {
                LookAround();
            }
            else
            {
                transform.LookAt(m_cameraTarget);
                patrol_time += Time.deltaTime;
            }
        }

        else if (mode == CameraState.lookback)
        {
            //transform.position = m_cameraTarget + new Vector3(0, 0, CAMERA_Z_OFFSET);
            Quaternion lookback_rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookback_rotation, Time.deltaTime * 800.0f);
        }
        else if (mode == CameraState.run)
        {
            //transform.position = m_cameraTarget + new Vector3(0, 0, CAMERA_Z_OFFSET);
            Quaternion lookback_rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookback_rotation, Time.deltaTime * 800.0f);
            //transform.LookAt(m_cameraTarget);
            //    else
            //    {
            //        final_rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            //        transform.rotation = Quaternion.RotateTowards(transform.rotation, final_rotation, Time.deltaTime * 100.0f);
            //    }
        }
        else
        {
            if (final_time < FINAL_DELAY)
            {
                Quaternion lookback_rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookback_rotation, Time.deltaTime * 800.0f);
                final_time += Time.deltaTime;
            }
            else
            {
                Quaternion final_rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, final_rotation, Time.deltaTime * 100.0f);
            }
        }
    }

    void LookAround()
    {
        Quaternion lookaround_rotation;
        if (lookphase == 0)
        {
            lookaround_rotation = Quaternion.Euler(-CAMERA_X_ROT, 90-CAMERA_Y_ROT, 0.0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookaround_rotation, Time.deltaTime * 50.0f);
            look_time += Time.deltaTime;
            if (look_time >= LOOKAROUND)
                lookphase = 1;
        }
        else if(lookphase == 1)
        {
            lookaround_rotation = Quaternion.Euler(-CAMERA_X_ROT, 90+CAMERA_Y_ROT, 0.0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookaround_rotation, Time.deltaTime * 100.0f);
            look_time -= Time.deltaTime;
            if (look_time <= 0)
                lookphase = 2;
        }
        else
        {
            lookaround_rotation = Quaternion.Euler(0, 90.0f, 0.0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookaround_rotation, Time.deltaTime * 50.0f);
        }
    }
}
