using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectEpisode : MonoBehaviour
{
    public GameObject[] Stages = new GameObject[4];
    public Sprite[] EpiNumTemp;
    public Sprite[] EpiNameTemp;

    public Sprite UnlockImg;

    public Image CageImg;
    public Sprite UnlockCage;
    private Sprite lockCage;

    public Sprite UnlockSelect;
    private Sprite lockSelect;

    public Button SelectBtn;

    public Image EpiName;
    public Image EpiNum;

    public MainSceneControll SceneControll;

    [HideInInspector]
    public int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        EpiNumTemp = new Sprite[] { };
        EpiNameTemp = new Sprite[] { };

        lockSelect = SelectBtn.GetComponent<Image>().sprite;
        lockCage = CageImg.sprite;

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
            SceneControll.OnSelectEpisode(index);
    }

    void moveSelect()
    {
        if (Input.GetKeyDown(KeyCode.A) && index > 0)
            index -= 1;
        else if (Input.GetKeyDown(KeyCode.D) && index < 3)
            index += 1;

        GetComponent<RectTransform>().anchoredPosition = new Vector2(-500 * index, 0);

        if (index < DataManager.instance.GetSavedEpisode() + 1)
        {
            SelectBtn.GetComponent<Image>().sprite = UnlockSelect;
            CageImg.sprite = UnlockCage;

            /*
            EpiName.sprite = EpiNameTemp[index];
            EpiNum.sprite = EpiNumTemp[index];
            */
        }
        else
        {
            SelectBtn.GetComponent<Image>().sprite = lockSelect;
            CageImg.sprite = lockCage;
        }

        for (int i = 0; i < 4; i++)
        {
            if (i == index)
                Stages[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            else
                Stages[i].GetComponent<Image>().color = new Color32(0, 0, 0, 128);
        }
    }
}