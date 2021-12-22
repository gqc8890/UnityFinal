using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGGHOSTtransform : MonoBehaviour
{
    const float MOVEMENT_SPEED = 1.6f;
    [SerializeField]
    Transform targetTrans;
    [SerializeField]
    Camera m_camera;

    CameraLogic cameraLogic;
    bool chase = false;
    // Start is called before the first frame update
    private void Start()
    {
        cameraLogic = m_camera.GetComponent<CameraLogic>();
    }
    // Update is called once per frame
    void Update()
    {
        if(cameraLogic.mode == CameraState.lookback)
            chase = true;
        if(chase)
            transform.position = Vector3.MoveTowards(transform.position, targetTrans.position, Time.deltaTime * MOVEMENT_SPEED);
    }
}
