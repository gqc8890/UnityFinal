using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    const float ROTATE_SPEED = 1.0f;
    collectManager manager;

    //MeshRenderer m_meshRenderer;
    //Collider m_collider;

    //[SerializeField]
    //AudioClip collectedaudio;

    //AudioSource m_audio;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<collectManager>();
        //m_collider = GetComponent<Collider>();
        //m_meshRenderer = GetComponent<MeshRenderer>();
        //m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * ROTATE_SPEED);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //m_audio.PlayOneShot(collectedaudio)
            //m_collider.enabled = false;
            //m_meshRenderer.enabled = false;
            gameObject.SetActive(false);
            manager.num_keys += 1;
        }
    }
}
