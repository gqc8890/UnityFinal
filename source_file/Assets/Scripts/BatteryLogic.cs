using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLogic : MonoBehaviour
{
    [SerializeField]
    AudioClip battery;

    AudioSource m_audio;
    int batterystate=1;

    public void pickbattery(){
        m_audio.clip = battery;
        m_audio.SetScheduledStartTime(0.5f);
        m_audio.Play();
        GetComponent<MeshRenderer>().enabled=false;
        GetComponent<Collider>().enabled=false;
        batterystate=0;
        //gameObject.SetActive(false);
    }

    public void Save(int index)
    {
        PlayerPrefs.SetInt("BatteryState"+ index, batterystate);
        m_audio = GetComponent<AudioSource>();
    }

    public void Load(int index)
    {
        batterystate= PlayerPrefs.GetInt("BatteryState"+ index);
        GetComponent<MeshRenderer>().enabled = (batterystate!=0);
        GetComponent<Collider>().enabled = (batterystate!=0);
    }
}
