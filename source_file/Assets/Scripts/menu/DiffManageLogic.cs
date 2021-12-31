using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiffManageLogic : MonoBehaviour
{
    public string diff_mode = "None";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
