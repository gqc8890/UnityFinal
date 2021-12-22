using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;

    //[Serialized]
    public AudioClip m_run;
    public AudioClip m_walk;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource[] m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    private GameObject m_camera;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponents<AudioSource> ();
        m_camera=GameObject.Find("FirstPersonCamera");
        m_AudioSource[1].clip=m_walk;
        m_AudioSource[1].Play();
    }

    void FixedUpdate ()
    {
        RotateCtrl();
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        
        m_Movement.Set(1.1f*horizontal, 0f, 1.1f*vertical);
        //m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        bool isRunning = false;
        m_Animator.SetBool ("IsWalking", isWalking);
        
        if(Input.GetButton("run")){
            m_Movement.Set(1.5f*horizontal, 0f, 1.5f*vertical);
            if(isWalking){
                isRunning=true;
            }
        }
        if (isWalking)
        {
            if (!m_AudioSource[0].isPlaying)
            {
                m_AudioSource[0].Play();
            }
        }
        else
        {
            m_AudioSource[0].Stop ();
        }
        if (isRunning)
        {
            if (m_AudioSource[1].clip!=m_run)
            {
                m_AudioSource[1].clip=m_run;
                m_AudioSource[1].Play();
            }
            m_AudioSource[0].pitch=0.7f;
        }
        else
        {
            m_AudioSource[1].clip=m_walk;
            if (!m_AudioSource[1].isPlaying){
                m_AudioSource[1].Play();
            }
            m_AudioSource[0].pitch=0.5f;
        }
        m_Movement=transform.TransformDirection(m_Movement);
        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }

    private void RotateCtrl() {
        Vector3 tempRot = m_camera.transform.position;
        tempRot.y = transform.position.y;
        Vector3 targetRot = transform.position - tempRot;
        transform.rotation = Quaternion.LookRotation(targetRot);
    }

    public void lookback1(){
        Quaternion lookback_rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookback_rotation, Time.deltaTime * 800.0f);
    }
}