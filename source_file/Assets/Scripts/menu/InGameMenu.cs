using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ingameMenu;
    int is_stop = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && is_stop==0)
        {
            is_stop = 1;
            Time.timeScale = 0;
            ingameMenu.SetActive(true);
            CursorLogic.locked = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && is_stop == 1)
        {
            Quit();
        }
    }
    void Start()
    {

    }

    public void OnReturnClicked()
    {
        Debug.Log("Clicked Start");
        Quit();
    }

    public void OnLoadClicked()
    {
        Debug.Log("Clicked Load");
    }

    public void OnQuitClicked()
    {
        Debug.Log("Clicked Quit");
        SceneManager.LoadScene("MainMenu");
        Quit();

    }

    private void Quit()
    {
        is_stop = 0;
        ingameMenu.SetActive(false);
        Time.timeScale = 1f;
        CursorLogic.locked = true;
    }

}
