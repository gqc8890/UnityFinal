using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectManager : MonoBehaviour
{
    public int num_keys = 0;
    private int num_copy = 0;
    [SerializeField]
    GameObject corrid_door;
    [SerializeField]
    AudioClip collected;

    AudioSource m_audio;
    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(num_keys != num_copy)
        {
            m_audio.PlayOneShot(collected);
            num_copy = num_keys;
        }
        if(num_keys == 3)
        {
            corrid_door.SetActive(false);
        }   
    }
}
