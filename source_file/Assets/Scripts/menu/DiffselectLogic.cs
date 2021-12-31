using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiffselectLogic : MonoBehaviour
{
    DiffManageLogic manager;
    private void Start()
    {
        manager = FindObjectOfType<DiffManageLogic>();
    }
    public void OnEasyClicked()
    {
        manager.diff_mode = "Easy";
        Debug.Log(manager.diff_mode);
        SceneManager.LoadScene("LoadScene");
    }
    public void OnNormalClicked()
    {
        manager.diff_mode = "Normal";
        Debug.Log(manager.diff_mode);
        SceneManager.LoadScene("LoadScene");
    }
    public void OnHardClicked()
    {
        manager.diff_mode = "Hard";
        Debug.Log(manager.diff_mode);
        SceneManager.LoadScene("LoadScene");
    }
}
