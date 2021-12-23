using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLogic : MonoBehaviour {

    // Use this for initialization
    public static bool locked=true;
    void Start () {
    }
    // Update is called once per frame

    void Update () {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Locked;//锁定指针到视图中心
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        //     if (Input.GetKeyDown(KeyCode.A)) {
        //         Cursor.visible = false;
        //     }
        //     if (Input.GetKeyDown(KeyCode.S))
        //     {
        //         Cursor.visible = true;
        //     }
         }
}