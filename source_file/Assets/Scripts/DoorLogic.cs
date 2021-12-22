using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    GameObject m_enemy;
    [SerializeField]
    AudioClip m_door_hit;
    [SerializeField]
    AudioClip m_door_break;
    AudioSource m_AudioSource;

    public bool is_destroyable=false;
    bool is_trigger=false;
    // Start is called before the first frame update

    private void Start() {
        m_enemy=GameObject.FindGameObjectWithTag("Enemy");
        m_AudioSource = GetComponent<AudioSource> ();
        m_AudioSource.clip=m_door_hit;
    }

    private void Update() {
        if(is_trigger && is_destroyable){
            m_AudioSource.PlayOneShot(m_door_hit);
            //m_AudioSource.clip=m_door_break;
            Invoke("playbreak",4.5f);
            Invoke("DestroyDoor",5.5f);
            Debug.Log("sasa");
            is_trigger=false;
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if(other.name=="enemy"){
            is_trigger=true;
        }

    }

    void playbreak(){
        m_AudioSource.clip=m_door_break;
        m_AudioSource.PlayOneShot(m_door_break);
    }

    void DestroyDoor(){
        gameObject.SetActive(false);
    }
}
