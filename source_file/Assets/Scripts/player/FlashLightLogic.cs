using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashLightLogic : MonoBehaviour
{
    Light m_light;
    int battery_num=3;

    [SerializeField]
    TextMeshProUGUI m_batteryTMP;

    [SerializeField]
    TextMeshProUGUI m_electricTMP;

    // Start is called before the first frame update
    void Start()
    {
        m_light=GetComponent<Light>();
        UpdateBatteryUI();
        UpdateElectricUI();
    }

    // Update is called once per frame
    void Update()
    {
        m_light.intensity-=0.001f;
        if(Input.GetButtonDown("Reload") && battery_num>0){
            m_light.intensity=2.0f;
            battery_num-=1;
            UpdateBatteryUI();
        }
        if(m_light.intensity<=0.3f && battery_num>0){
            m_light.intensity=2.0f;
            battery_num-=1;
            UpdateBatteryUI();
        }
        UpdateElectricUI();
        
    }

    public bool havebattery(){
        m_light=GetComponent<Light>();
        if(m_light.intensity<=0.1f){
            return true;
        }else{
            return false;
        }
    }

    public void pickbattery(){
        battery_num+=1;
        UpdateBatteryUI();
    }

    void UpdateBatteryUI()
    {
        m_batteryTMP.text = " "+battery_num;
    }

    void UpdateElectricUI()
    {
        m_electricTMP.text = " "+(int)((m_light.intensity/2f)*100);
<<<<<<< HEAD
=======
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Electric", m_light.intensity);
        PlayerPrefs.SetInt("Battery", battery_num);


    }

    public void Load()
    {
        m_light.intensity = PlayerPrefs.GetFloat("Electric");
        battery_num = PlayerPrefs.GetInt("Battery");
        UpdateBatteryUI();
        UpdateElectricUI();
>>>>>>> e5e1a2531424588bd8fcbcb2bff2c9f99298caae
    }
}
