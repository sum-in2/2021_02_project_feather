using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance = null;

    [HideInInspector]
    public int nowPlayStage = 0;
    [HideInInspector]
    public int nowPlayEpisode = 0;

    [HideInInspector]
    public int CanvasNum = 0;

    [HideInInspector]
    public bool bPause = false;

    int[,,] LeafB = new int[4, 4, 3];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        if (!PlayerPrefs.HasKey("Episode"))
            PlayerPrefs.SetInt("Episode", 0);

        if (!PlayerPrefs.HasKey("Stage"))
            PlayerPrefs.SetInt("Stage", 0);
    }

    public int GetSavedEpisode()
    {
        int Epi = 0;

        if (PlayerPrefs.HasKey("Episode"))
            Epi = PlayerPrefs.GetInt("Episode");

        return Epi;
    }

    public int GetSavedStage()
    {
        int Stage = 0;

        if (PlayerPrefs.HasKey("Stage"))
            Stage = PlayerPrefs.GetInt("Stage");

        return Stage;
    }

    public void ClearStage()
    {
        if (nowPlayStage == PlayerPrefs.GetInt("Stage"))
            PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 1);
    }

    public void setLeafB(int index)
    {
        index -= 1;

        LeafB[nowPlayEpisode, nowPlayStage, index] = 1;
    }

    public int getStageLeafB(int index)
    {
        return LeafB[nowPlayEpisode, nowPlayStage, index];
    }
}