using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioforMyth2 : MonoBehaviour
{
    [SerializeField]
    AudioClip openaudio;
    [SerializeField]
    AudioClip wrongaudio;

    AudioSource m_audio;
    // Start is called before the first frame update
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    public void playopendoor()
    {
        m_audio.PlayOneShot(openaudio);
    }
    public void playwronglist()
    {
        m_audio.PlayOneShot(wrongaudio);
    }
}
