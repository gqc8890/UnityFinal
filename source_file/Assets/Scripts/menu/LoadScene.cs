using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Text loadingText;
    public Image progressBar;
    private int curProgressValue = 0;
    
    private void Start() {
        curProgressValue=0;
    }

    void FixedUpdate()
    {
        int progressValue = 200;

        if (curProgressValue < progressValue)
        {
            curProgressValue++;
        }

        loadingText.text = "腾腾正在努力加载哦..." + curProgressValue/2 + "%";//实时更新进度百分比的文本显示  

        progressBar.fillAmount = curProgressValue / 200f;//实时更新滑动进度图片的fillAmount值  

        if (curProgressValue == 200)
        {
            loadingText.text = "OK";//文本显示完成OK
            SceneManager.LoadScene(2);
        }
    }
}