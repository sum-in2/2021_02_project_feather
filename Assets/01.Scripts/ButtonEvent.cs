using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{

    public void OnRetryBtn()
    {
        string stage = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(stage);
        Time.timeScale = 1;
    }

    public void OnQuitBtn()
    {
#if UNITY_EDITOR
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
#else
        Application.Quit();
#endif
    }

    public void OnMenuBtn()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }

    public void OnStartBtn()
    {
        GameObject.Find("StartBtn").SetActive(false);
        GameObject.Find("Canvas").transform.Find("StageOneBtn").gameObject.SetActive(true);
        //GameObject.Find("Canvas").transform.Find("Scroll View").Find("StageOneBtn").gameObject.SetActive(true);
    }

    public void OnStageOneBtn()
    {
        SceneManager.LoadScene("stage1");
        Time.timeScale = 1;
    }

    public void OnResumeBtn()
    {
        Time.timeScale = 1;
        DataManager.instance.bPause = false;
        GameObject.Find("Canvas").transform.Find("PausePanel").gameObject.SetActive(false);
    }
}
