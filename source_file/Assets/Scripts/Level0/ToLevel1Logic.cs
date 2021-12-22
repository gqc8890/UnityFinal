using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel1Logic : MonoBehaviour
{


    void OnTriggerEnter (Collider other)
    {
        SceneManager.LoadScene("MainScene");
    }
}
