using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check2 : MonoBehaviour
{
    List<mythOrder> targetlist = new List<mythOrder>() { mythOrder.s0, mythOrder.s1, mythOrder.s2, mythOrder.s0, mythOrder.s1, mythOrder.s2, mythOrder.s0 };
    public List<mythOrder> contemp = new List<mythOrder>();
    public bool permiss = false;
    int count;

    TriggerLogic2[] triggers;
    AudioforMyth2 m_audio;
    SaveManager m_save;

    // Start is called before the first frame update
    void Start()
    {
        m_audio = FindObjectOfType<AudioforMyth2>();
        triggers = FindObjectsOfType<TriggerLogic2>();
        m_save = FindObjectOfType<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        count = 0;
        if(contemp.Count > 0)
        {
            if (contemp[contemp.Count-1] == targetlist[contemp.Count-1])
                count = contemp.Count;
            else
            {
                permiss = false;
                m_audio.playwronglist();
                count = 0;
                contemp.Clear();
                for(int i=0; i<triggers.Length; i++)
                {
                    triggers[i].lightoff();
                }
            }
        }
        
        if (count == targetlist.Count)
        {
            for (int i = 0; i < triggers.Length; i++)
            {
                triggers[i].lighton();
            }
            m_audio.playopendoor();
            destroy_door();
        }
    }

    void destroy_door()
    {
        gameObject.SetActive(false);
        // m_save.Save1();
    }
}
