using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum first
{
    yes,
    not
}

public class TriggerLogic2 : MonoBehaviour
{
    //[SerializeField]
    //GameObject lit_sys;

    const float TIME_LOCK = 0.1f;
    float time_lock = 0.0f;

    bool lock_on = false;
    [SerializeField]
    mythOrder stat;
    [SerializeField]
    first whether;
    [SerializeField]
    GameObject checker;
    [SerializeField]
    Light sublight;
    [SerializeField]
    AudioClip stataudio;
    
    AudioSource m_audio;
    Check2 checklogic;
    
    bool completed = false;
    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
        checklogic = checker.GetComponent<Check2>();
        sublight.intensity = 0.0f;
    }

    private void Update()
    {
        if (lock_on)
        {
            time_lock += Time.deltaTime;
        }
        if(time_lock >= TIME_LOCK)
        {
            lock_on = false;
            time_lock = 0.0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !lock_on && !completed)
        {
            if(whether == first.yes)
            {
                checklogic.permiss = true;
            }
            if (checklogic.permiss)
            {
                m_audio.PlayOneShot(stataudio);
                sublight.intensity = 2.0f;
                checklogic.contemp.Add(stat);
                lock_on = true;
            }
        }
    }
    public void lightoff()
    {
        sublight.intensity = 0.0f;
    }
    public void lighton()
    {
        completed = true;
        sublight.intensity = 2.0f;
    }
}
