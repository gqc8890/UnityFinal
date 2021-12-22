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
    const float BUFFER = .3f;
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
    float[] TIMEFLOW = { 0.0f, 1.0f, 2.0f, 3.0f, 4.0f };
    Dictionary<mythOrder, float> statdict = new Dictionary<mythOrder, float>();
    Timer timerlogic;
    AudioSource m_audio;

    public bool completed = false;
    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
        lit.intensity = 0.0f;
        timerlogic = timer.GetComponent<Timer>();
        statdict.Add(mythOrder.s0, TIMEFLOW[0]);
        statdict.Add(mythOrder.s1, TIMEFLOW[1]);
        statdict.Add(mythOrder.s2, TIMEFLOW[2]);
        statdict.Add(mythOrder.s3, TIMEFLOW[3]);
        statdict.Add(mythOrder.s4, TIMEFLOW[4]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !completed)
        {
            if(stat == mythOrder.s0)
                timerlogic.begintiming = true;
            if (timerlogic.begintiming)
            {
                lit.intensity = 2.0f;
            }
                
            float upper = statdict[stat] + BUFFER;
            float lower = statdict[stat] - BUFFER;
            if (timerlogic.time >= lower && timerlogic.time <= upper)
            {
                judge = true;
                m_audio.PlayOneShot(stataudio);
            }
            else
            {
                if(timerlogic.begintiming)
                    m_audio.PlayOneShot(wrongaudio);
                restart = true;
                timerlogic.begintiming = false;
                timerlogic.time = 0.0f;
            }
        }
    }

    public void litoff()
    {
        lit.intensity = 0.0f;
    }
}
