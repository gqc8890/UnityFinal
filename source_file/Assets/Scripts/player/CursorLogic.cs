using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLogic : MonoBehaviour {

    // Use this for initialization

    void Start () {
    }
    // Update is called once per frame

    void Update () {
        Cursor.lockState = CursorLockMode.Locked;//锁定指针到视图中心
        Cursor.visible = false;
        //     if (Input.GetKeyDown(KeyCode.A)) {
        //         Cursor.visible = false;
        //     }
        //     if (Input.GetKeyDown(KeyCode.S))
        //     {
        //         Cursor.visible = true;
        //     }
         }
}