using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{

    public PlayableDirector StartTimeLine;
    public PlayableDirector EndingTimeLine;
    private bool isFirst;
    public GameObject ClearPanel;

    public GameObject[] GameObjects = new GameObject[3];

    private void Start()
    {
        Play(1);
        isFirst = false;
        if (ClearPanel == null)
        {
            ClearPanel = GameObject.Find("ClearCanvas");
        }
    }

    public void Play(int Select)
    {
        if (Select == 1)
        {
            StartTimeLine.Play();
        }
        else if (Select == 2 && isFirst == false)
        {
            isFirst = true;
            EndingTimeLine.Play();
        }
    }

    public void StartSignal()
    {
        Time.timeScale = 1;
        for (int i = 0; i < GameObjects.Length; i++)
        {
            GameObjects[i].gameObject.SetActive(true);
        }
    }

    public void EndSignal()
    {
        Time.timeScale = 0;
        ClearPanel.gameObject.SetActive(true);
    }
}
