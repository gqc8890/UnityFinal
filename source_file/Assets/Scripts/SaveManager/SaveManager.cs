using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance => m_instance;
    static SaveManager m_instance;

    BatteryLogic[] m_batteryLogic;
    PlayerMovement m_playmovement;
    NewEnemy m_enemy;
    Enemysave m_enemy1;
    FlashLightLogic m_flashlogic;


    void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_batteryLogic = FindObjectsOfType<BatteryLogic>();
        m_playmovement = FindObjectOfType<PlayerMovement>();
        m_flashlogic = FindObjectOfType<FlashLightLogic>();
        m_enemy = FindObjectOfType<NewEnemy>();
        m_enemy1 = FindObjectOfType<Enemysave>();
    }

    // Update is called once per frame
    void Update()
    {
        // Save
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("saveveveveveveveveveveve");
            Save1();
        }

        // Load
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load1();
        }
    }

    public void Save1()
    {
        m_playmovement.Save();
        m_flashlogic.Save();
        m_enemy.Save();
        m_enemy1.Save();
        for (int index = 0; index < m_batteryLogic.Length; ++index)
        {
            if(m_batteryLogic[index]){
                m_batteryLogic[index].Save(index);
            }
        }

        PlayerPrefs.Save();
    }

    public void Load1()
    {
        m_playmovement.Load();
        m_flashlogic.Load();
        m_enemy.Load();
        m_enemy1.Load();

        for (int index = 0; index < m_batteryLogic.Length; ++index)
        {
            if(m_batteryLogic[index]){
                m_batteryLogic[index].Load(index);
            }
        }
    }
}
