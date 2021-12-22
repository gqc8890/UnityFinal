using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCG : MonoBehaviour
{
    GameObject m_camera;
    ThirdPersonCamera m_logic;
    public GameObject enemy;
    public GameObject bornpoint;
    // Start is called before the first frame update
    void Start()
    {
        m_camera=GameObject.FindGameObjectWithTag("MainCamera");
        m_logic=m_camera.GetComponent<ThirdPersonCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(){
        Debug.Log("fds");
        m_logic.lookback1();
        bornpoint.GetComponent<AudioSource>().Play();
        Invoke("bo",0.0f);
        Invoke("bo",0.1f);
        //GameObject.FindGameObjectWithTag("Enemy").GetComponent<NewEnemy>().born();
        Invoke("disable",0.3f);
    }

    void bo(){
        enemy.GetComponent<NewEnemy>().born();
    }

    void disable(){
        gameObject.SetActive(false);
    }

}
