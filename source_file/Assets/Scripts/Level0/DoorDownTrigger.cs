using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDownTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject m_door;

    Vector3 copy_trans;
    bool setdoordown = false;
    // Start is called before the first frame update
    void Start()
    {
        copy_trans = m_door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (setdoordown)
        {
            m_door.transform.position = Vector3.MoveTowards(m_door.transform.position, copy_trans + new Vector3(0.0f,5.0f,0), Time.deltaTime * 5.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            setdoordown = true;
        }
    }
}
