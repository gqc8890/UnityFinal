<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDownTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject m_door;
    [SerializeField]
    AudioClip shut;

    Vector3 copy_trans;
    bool setdoordown = false;
    AudioSource m_audio;
    bool startplay = false;
    // Start is called before the first frame update
    void Start()
    {
        copy_trans = m_door.transform.position;
        m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (setdoordown)
        {
            if (!startplay)
            {
                Invoke("playshut", 0.5f);
                startplay = true;
            }
                
            m_door.transform.position = Vector3.MoveTowards(m_door.transform.position, copy_trans + new Vector3(0.0f,5.0f,0), Time.deltaTime * 8.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            setdoordown = true;
        }
    }

    void playshut()
    {
        m_audio.PlayOneShot(shut);
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDownTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject m_door;
    [SerializeField]
    AudioClip shut;

    Vector3 copy_trans;
    bool setdoordown = false;
    AudioSource m_audio;
    bool startplay = false;
    // Start is called before the first frame update
    void Start()
    {
        copy_trans = m_door.transform.position;
        m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (setdoordown)
        {
            if (!startplay)
            {
                Invoke("playshut", 0.5f);
                startplay = true;
            }
                
            m_door.transform.position = Vector3.MoveTowards(m_door.transform.position, copy_trans + new Vector3(0.0f,5.0f,0), Time.deltaTime * 8.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            setdoordown = true;
        }
    }

    void playshut()
    {
        m_audio.PlayOneShot(shut);
    }
}
>>>>>>> e5e1a2531424588bd8fcbcb2bff2c9f99298caae
