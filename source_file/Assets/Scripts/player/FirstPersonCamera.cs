using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    Vector3 rot = new Vector3(0, 0, 0);   //先定义一个Vectory3类型的变量rot（0,0,0）
    public float speed=1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X")*speed;       
        float MouseY = Input.GetAxis("Mouse Y")*speed;
        rot.x = rot.x - MouseY;
        rot.y = rot.y + MouseX;  
        rot.z = 0;   //锁定摄像头移动的角度z轴，防止左右倾斜
        transform.eulerAngles = rot;   //所有方向设定好后，摄像头的角度=rot
    }
}
