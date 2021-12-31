using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonHead : MonoBehaviour
{
    [SerializeField]
    GameObject finaldoor;
    [SerializeField]
    AudioClip clicked;

    bool complete = false;
    [SerializeField]
    GameObject effect;

    AudioSource m_audio;
    SaveManager m_save;
    // Start is called before the first frame update
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
        effect.SetActive(false);
        m_save = FindObjectOfType<SaveManager>();
        }

    public void startup()
    {
        Debug.Log("setup");
        effect.SetActive(true);
        if (!complete)
        {
            m_audio.PlayOneShot(clicked);
            complete = true;
            // m_save.Save1();
        }
        finaldoor.SetActive(false);
    }
}
