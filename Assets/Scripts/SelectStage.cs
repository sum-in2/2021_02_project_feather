using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectStage : MonoBehaviour
{

    public Sprite[] text_SavedEpiNum;
    public Sprite[] text_SavedEpiName;
    public Image[] Btns;
    public Image[] Bars;

    public SelectEpisode SE;
    public Image Text_NowEpiName;
    public Image Text_NowEpiNum;

    int NowEpiNum;
    [HideInInspector]
    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        NowEpiNum = SE.index;

        //Text_NowEpiNum.sprite = text_SavedEpiNum[NowEpiNum];
        //Text_NowEpiName.sprite = text_SavedEpiName[NowEpiNum];

        moveSelect();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            moveSelect();
        }

        if (Input.GetKeyDown(KeyCode.Return))
            SceneManager.LoadScene("Stage" + (index + 1));
    }

    void moveSelect()
    {
        int SavedStage = DataManager.instance.GetSavedStage();

        if (Input.GetKeyDown(KeyCode.A) && index > 0)
            index -= 1;
        else if (Input.GetKeyDown(KeyCode.D) && index < 3 && index < SavedStage)
            index += 1;

        for (int i = 0; i < 4; i++)
        {
            Btns[i].rectTransform.localScale = Vector3.one;
            if (i > SavedStage)
            {
                Btns[i].color = Color.black;
                Bars[i-1].color = Color.black;
            }
        }

        Btns[index].rectTransform.localScale = new Vector3(1.5f, 1.5f, 1);
    }
}
