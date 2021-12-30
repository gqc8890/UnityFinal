using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum mythOrder
{
    s0,
    s1,
    s2,
    s3,
    s4
}

public class TriggerLogic : MonoBehaviour
{
    [SerializeField]
    Light lit;
    const float BUFFER = .2f;
    [SerializeField]
    GameObject timer;
    [SerializeField]
    mythOrder stat;
    [SerializeField]
    AudioClip stataudio;
    [SerializeField]
    AudioClip wrongaudio;

    public bool judge = false;
    public bool restart = false;
    Timer timerlogic;
    AudioSource m_audio;

    public bool completed = false;
    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
        lit.intensity = 0.0f;
        timerlogic = timer.GetComponent<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !completed)
        {
            
            if(stat == mythOrder.s0)
            {
                timerlogic.begintiming = true;
                m_audio.PlayOneShot(stataudio);
                judge = true;
                timerlogic.time = 0.0f;
            }
                
            if (timerlogic.begintiming)
            {
                lit.intensity = 2.0f;
            }
                
            float upper = 1.0f + BUFFER;
            float lower = 1.0f - BUFFER;
            if(stat != mythOrder.s0)
            {
                if (timerlogic.time >= lower && timerlogic.time <= upper)
                {
                    judge = true;
                    m_audio.PlayOneShot(stataudio);
                    timerlogic.time = 0.0f;
                }
                else
                {
                    if (timerlogic.begintiming)
                        m_audio.PlayOneShot(wrongaudio);
                    restart = true;
                    timerlogic.begintiming = false;
                }
            }
        }
    }

    public void litoff()
    {
        lit.intensity = 0.0f;
    }
}
