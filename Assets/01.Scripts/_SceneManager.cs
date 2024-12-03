using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _SceneManager : MonoBehaviour
{
    public GameObject PausePanel;

    void Update()
    {

    }

    public void GameCheck(float ProgressPer)
    {
        string ProgressText = string.Empty;

        Time.timeScale = 0;

        if (ProgressPer >= 100)
            ProgressText = string.Format("진행률  : 100%");
        else
            ProgressText = string.Format("진행률 : {0:P}", ProgressPer);

        GameObject canvasTemp = GameObject.Find("Canvas").transform.Find("Panel").gameObject;

        canvasTemp.SetActive(true);
        canvasTemp.transform.Find("Text").GetComponent<Text>().text = ProgressText;
    }

    public void pauseGame()
    {
        if (!DataManager.instance.bPause)
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
    }
}