using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ButtonLogic : MonoBehaviour
{
    //public static ButtonLogic _instance:


    [SerializeField]
    GameObject door;

    [SerializeField]
    AudioClip openaudio;

    AudioSource m_audio;

    // Start is called before the first frame update
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void opendoor(){
        if(door.activeInHierarchy){
            m_audio.PlayOneShot(openaudio);
            Invoke("opendelay", 0.3f);
        }else{
            m_audio.PlayOneShot(openaudio);
            Invoke("closedelay", 0.3f);
            door.SetActive(true);
        }
    }

    public void closedoor(){
     
        door.SetActive(false);
    }

    void opendelay()
    {
        door.SetActive(false);
    }
    void closedelay()
    {
        door.SetActive(true);
    }
}
