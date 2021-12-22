using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGGHOSTtransform : MonoBehaviour
{
    const float MOVEMENT_SPEED = 1.5f;
    [SerializeField]
    Transform targetTrans;
    [SerializeField]
    Camera m_camera;

    [SerializeField]
    AudioClip cryaudio;

    AudioSource m_audio;
    CameraLogic cameraLogic;
    bool chase = false;
    // Start is called before the first frame update
    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
        cameraLogic = m_camera.GetComponent<CameraLogic>();
        Invoke("playsound", 5.0f);
    }
    // Update is called once per frame
    void Update()
    {
        if(cameraLogic.mode == CameraState.lookback)
            chase = true;
        if(chase)
            transform.position = Vector3.MoveTowards(transform.position, targetTrans.position, Time.deltaTime * MOVEMENT_SPEED);
    }

    void playsound()
    {
        m_audio.clip = cryaudio;
        m_audio.loop = true;
        m_audio.Play();
    }
}
