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
    bool startplay = false;
    bool startplay2 = false;
    [SerializeField]
    Transform targetTrans;
    [SerializeField]
    Camera m_camera;

    [SerializeField]
    AudioClip walkbreath;
    [SerializeField]
    AudioClip runbreath;

    [SerializeField]
    AudioClip step;

    AudioSource[] m_audio;
    CameraLogic[] m_cameras;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        m_cameras = FindObjectsOfType<CameraLogic>();
        m_audio = GetComponents<AudioSource>();
        m_audio[0].loop = true;
        m_audio[1].loop = true;
        m_audio[0].clip = walkbreath;
        m_audio[1].clip = step;
        m_audio[1].pitch = 0.5f;
        m_audio[0].Play();
        m_audio[1].Play();
    }
    // Update is called once per frame
    void Update()
    {
        if(m_cameras[0].mode == CameraState.patrol)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTrans.position, Time.deltaTime * PATROL_SPEED);
        }
            
        else if(m_cameras[0].mode == CameraState.lookback)
        {
            walkbacktime += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetTrans.position, Time.deltaTime * WALK_BACK_SPEED);
            if(walkbacktime >= WALK_BACK_DUR)
            {
                m_audio[0].clip = runbreath;
                m_audio[1].clip = step;
                m_audio[1].pitch = 0.8f;
                m_audio[0].Play();
                m_audio[1].Play();
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
            m_audio[0].clip = walkbreath;
            if (!startplay)
            {
                m_audio[0].Play();
                startplay = true;
                m_audio[1].pitch = 0.5f;
                m_audio[1].Pause();
            }
            
            if (m_cameras[0].final_time >= 4.0f)
            {
                if (!startplay2)
                {
                    m_audio[1].Play();
                    startplay2 = true;
                }
                //transform.position = Vector3.MoveTowards(transform.position, targetTrans.position, Time.deltaTime * PATROL_SPEED);
            }
            transform.position = Vector3.MoveTowards(transform.position, targetTrans.position, Time.deltaTime * PATROL_SPEED);
        }
    }
}
