using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    AudioClip openaudio;
    public float time = 0.0f;

    public bool begintiming = false;
    AudioSource m_audio;
    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (begintiming)
        {
            time += Time.deltaTime;
        }
    }

    public void playopendoor()
    {
        m_audio.PlayOneShot(openaudio);
    }
}
