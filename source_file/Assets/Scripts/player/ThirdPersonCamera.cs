// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ThirdPersonCamera : MonoBehaviour
// {
//     Vector3 m_cameraTarget;
//     float m_cameraTargetOffset = 2.0f;

//     float m_distanceZ = 3.0f;
//     const float MIN_Z = 2.0f;
//     const float MAX_Z = 5.0f;

//     float m_rotationX = 0.0f;
//     const float MIN_X = -50.0f;
//     const float MAX_X = 50.0f;

//     float m_rotationY = 0.0f;

//     GameObject m_player;
//     Vector3 m_cameraOffset;

//     // Start is called before the first frame update
//     void Start()
//     {
//         m_player = GameObject.FindGameObjectWithTag("Player");
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // Increase Camera Rotations
//         if(Input.GetButton("Fire2"))
//         {
//             m_rotationY += Input.GetAxis("Mouse X");
//             m_rotationX -= Input.GetAxis("Mouse Y");
//             m_rotationX = Mathf.Clamp(m_rotationX, MIN_X, MAX_X);
//         }

//         // Zoom in / out
//         m_distanceZ -= Input.GetAxis("Mouse ScrollWheel");
//         m_distanceZ = Mathf.Clamp(m_distanceZ, MIN_Z, MAX_Z);

//         // Set Camera Target above Player position
//         m_cameraTarget = m_player.transform.position;
//         m_cameraTarget.y += m_cameraTargetOffset;
//     }

//     void LateUpdate()
//     {
//         // Calculate Camera Offset
//         m_cameraOffset = new Vector3(0, 0, -m_distanceZ);

//         // Calculate Camera Position based on Rotations
//         Quaternion cameraRotation = Quaternion.Euler(m_rotationX, m_rotationY, 0);
//         transform.position = m_cameraTarget + cameraRotation * m_cameraOffset;

//         // Look at Target
//         transform.LookAt(m_cameraTarget);
//     }

//     public Vector3 GetForwardVector()
//     {
//         // Calculate the Forward Vector of the Camera without X Axis rotations
//         Quaternion rotation = Quaternion.Euler(0, m_rotationY, 0);
//         return rotation * Vector3.forward;
//     }
// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ThirdPersonCamera : MonoBehaviour {
 
	//目标物体
    public Transform target;
    //相机与目标物体的距离
    public float distance;
    //横向角度
    public float rotDegree = 0;
    public float rotSpeed = 1.0f;
    float rot; //弧度
    //纵向角度
    public float rollDegree = 0;
    public float rollSpeed = 0.4f;
    public float minRollDegree = -15;
    public float maxRollDegree = 15;
    float roll; //弧度
    //摄像机移动速度(滚轮控制)
    public float zoomSpeed = 1.5f;
    public float minDis = 0.01f;
    public float maxDis = 0.01f;
    //视角锁定
    private bool isLock = false;
    //相机和角色之间的距离
    private float sourceDis;

    bool is_cg=false;

    float mid;



    Ray ray;

    GameObject m_flash;
 
    // Use this for initialization
    void Start () {
        GetTarget(target.gameObject);
        m_flash=GameObject.Find("FlashLight");

    }
    
    // Update is called once per frame
    void LateUpdate () {
        if (isLock == false)
        {
            Rotate();
            Roll();
            Zoom();
            if(is_cg){
                Debug.Log("gfsf");
                    mid-=3f*rotSpeed;
                    rotDegree-=3f*rotSpeed;
                    if(mid<=0f){
                        is_cg=false;
                    }
            }
        }

        //角度转换成弧度
        rot = rotDegree * Mathf.PI / 180;
        roll = rollDegree * Mathf.PI / 180;
        //计算相机的地面投影和相机高度
        float d = distance * Mathf.Cos(roll);
        float height = distance * Mathf.Sin(roll);
        Vector3 cameraPos = Vector3.zero;
        //计算相机的坐标
        if (target != null)
        {
            cameraPos.x = target.transform.position.x + d * Mathf.Cos(rot);
            cameraPos.z = target.transform.position.z + d * Mathf.Sin(rot);
            cameraPos.y = target.transform.position.y + height;
 
            this.transform.position = cameraPos;
            this.transform.LookAt(target.transform.position);
        }
        // if (Input.GetButton("Fire2")) {
        //     distance=minDis;
        // }else{
        //     distance=maxDis;
        // }
        sourceDis = Vector3.Distance(transform.position, target.position);
        CameraDefend();
        React();
    }
    //鼠标水平滑动调整视角
    void Rotate() {
        if(!is_cg){
            float value = 3*Input.GetAxis("Mouse X");
            rotDegree -= value * rotSpeed;
        }
    }
    //鼠标垂直方向调整视角
    void Roll() {
        float value = -Input.GetAxis("Mouse Y");
        rollDegree += value * rollSpeed;
        rollDegree = Mathf.Clamp(rollDegree, minRollDegree, maxRollDegree);
    }
    //滚轮调整视角的远近
    void Zoom() {
        //float value = Input.GetAxis("Mouse ScrollWheel");
        //distance -= value * zoomSpeed;
        //distance = Mathf.Clamp(distance, minDis, maxDis);
        if (Input.GetButton("Fire2")) {
            distance=1.2f;
        }else{
            distance=0.01f;
        }
    }
 
    //让相机始终跟随目标物体身上的某一点
    private void GetTarget(GameObject target) {
        if (target.transform.Find("cameraPoint") != null)
        {
            this.target = target.transform.Find("cameraPoint");
            Debug.Log("找到Target点");
        }
    }
    //恢复默认参数
    public void DefaultValue() {
        distance = 5;
        //横向角度
        rotDegree = 270;
        //纵向角度
        rollDegree = -10;
    }
    public Vector3 temp = new Vector3(0, -0.7f, 0);
    private void CameraDefend() {
        RaycastHit hit;
        //从角色向相机发射一条射线
        if (Physics.Linecast(this.target.position + temp, transform.position, out hit)) {
            string name = hit.collider.gameObject.tag;
            if (name != "MainCamera" || name != "Fire") {
                float currentDistance = Vector3.Distance(target.position, hit.point);
                //如果射线碰撞点小于玩家与相机本来的距离，就说明角色身后是有东西，为了避免穿墙，就把相机拉近
                if (currentDistance < sourceDis) {
                    //transform.position = hit.point;
                    transform.position = Vector3.Lerp(transform.position, hit.point,10);
                }
            }
        }
    }

    public float GetRotationX()
    {
        return rotDegree;
    }

    public float GetRotationY()
    {
        return rollDegree;
    }
    public bool React(){
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            string name = hit.collider.gameObject.tag;
            float dis=Vector3.Distance(hit.collider.gameObject.transform.position,gameObject.transform.position);
            if (name == "Button" && Input.GetButtonDown("Fire1") && dis<=1.5f){
                hit.collider.gameObject.GetComponent<ButtonLogic>().opendoor();
                return true;
            }
            else if (name == "Demon_head" && Input.GetButtonDown("Fire1") && dis<=3.0f){
                hit.collider.gameObject.GetComponent<DemonHead>().startup();
                return true;
            }
            else if (name == "Battery" && Input.GetButtonDown("Fire1") && dis<=1.7f){
                hit.collider.gameObject.GetComponent<BatteryLogic>().pickbattery();
                m_flash.GetComponent<FlashLightLogic>().pickbattery();
                return true;
            }
            else{
                return false;
            }
        }
        return false;
    }


    public void lookback1(){
        is_cg=true;
        mid=180f;
    }
}