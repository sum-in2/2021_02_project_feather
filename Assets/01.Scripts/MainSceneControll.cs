using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainSceneControll : MonoBehaviour
{
    public SelectEpisode selectEpisode;
    public SelectStage SS;
    int Episode;
    int Stage;

    GameObject[] Canvases = new GameObject[3];

    int NowCanvas;


    void Start()
    {
        Canvases[0] = transform.Find("FirstCanvas").gameObject;
        Canvases[1] = transform.Find("EpiSelectCanvas").gameObject;
        Canvases[2] = transform.Find("StageCanvas").gameObject;

        CanvasOpen();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown && Canvases[0].activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitQ();
            }
            else
            {
                DataManager.instance.CanvasNum = 1;
                CanvasOpen();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && Canvases[1].activeInHierarchy)
            OnSelectEpisode();

        if (Input.GetKeyDown(KeyCode.Space) && Canvases[2].activeInHierarchy)
            OnSelectStage();
    }

    void ExitQ()
    {
        //transform.Find("ExitCanvas").gameObject.SetActive(true);
    }

    public void OnSelectEpisode()
    {
        DataManager.instance.nowPlayEpisode = selectEpisode.index;
        if (DataManager.instance.nowPlayEpisode < DataManager.instance.GetSavedEpisode() + 1)
        {
            DataManager.instance.CanvasNum = 2;
            CanvasOpen();
        }
    }
    public void OnSelectEpisode(int Episode)
    {
        if (Episode < DataManager.instance.GetSavedEpisode() + 1)
        {
            DataManager.instance.CanvasNum = 3;
            CanvasOpen();
        }
    }

    public void OnSelectStage()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;

        Stage = SS.index;

        if (ButtonName == "Stage" + (Stage + 1) + "Btn")
        {
            DataManager.instance.nowPlayStage = Stage;
            SceneManager.LoadScene(Stage + 1);
        }
    }

    void CanvasOpen()
    {
        for (int i = 0; i < 3; i++)
        {
            Canvases[i].gameObject.SetActive(false);
            if (i == DataManager.instance.CanvasNum)
                Canvases[i].gameObject.SetActive(true);
        }

    }

    public void OnReturnBtn()
    {
        DataManager.instance.CanvasNum -= 1;
        CanvasOpen();
    }
}
