using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    TriggerLogic[] triggers;
    bool permiss = false;
    int count;
    Timer timecounter;
    

    AudioSource m_audio;
    // Start is called before the first frame update
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
        triggers = FindObjectsOfType<TriggerLogic>();
        timecounter = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        count = 0;
        for(int i=0; i<5; i++)
        {
            if (triggers[i].judge)
            {
                count +=1;
            }
            if (triggers[i].restart)
            {
                Debug.Log(i);
                triggers[i].restart = false;
                for(int j = 0; j < 5; j++)
                {
                    triggers[j].litoff();
                    triggers[j].judge = false;
                }
                break;
            }
        }

        if (count == 5)
        {
            for (int j = 0; j < 5; j++)
            { 
                triggers[j].completed = true;
            }
            timecounter.playopendoor();
            gameObject.SetActive(false);
        }
    }
}
