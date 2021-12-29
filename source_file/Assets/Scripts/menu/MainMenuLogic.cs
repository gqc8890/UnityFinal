using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnStartClicked()
    {
        Debug.Log("Clicked Start");
        SceneManager.LoadScene("LoadScene");
    }

    public void OnOptionsClicked()
    {
        Debug.Log("Clicked Options");
        SceneManager.LoadScene("Control");
    }

    public void OnQuitClicked()
    {
        Debug.Log("Clicked Quit");
        Application.Quit();
    }
    public void OnMenuClicked()
    {
        Debug.Log("Clicked Menu");
        SceneManager.LoadScene("MainMenu");
    }


}
