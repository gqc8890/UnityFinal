using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLogic : MonoBehaviour
{
    int batterystate=1;

    public void pickbattery(){
        GetComponent<MeshRenderer>().enabled=false;
        GetComponent<Collider>().enabled=false;
        batterystate=0;
        //gameObject.SetActive(false);
    }

    public void Save(int index)
    {
        PlayerPrefs.SetInt("BatteryState"+ index, batterystate);

    }

    public void Load(int index)
    {
        batterystate= PlayerPrefs.GetInt("BatteryState"+ index);
        GetComponent<MeshRenderer>().enabled = (batterystate!=0);
        GetComponent<Collider>().enabled = (batterystate!=0);
    }
}
