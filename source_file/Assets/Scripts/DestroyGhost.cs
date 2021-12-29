using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGhost : MonoBehaviour
{
    void OnTriggerEnter (Collider other)
    {
        if (other.name=="Ghost")
        {
            other.gameObject.SetActive(false);
        }
    }

}
