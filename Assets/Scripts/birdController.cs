using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class birdController : MonoBehaviour
{
    bool isdead = false;
    bool isClear = false;
    int Cnt_leafA;
    int Cnt_leafB;

    SpriteRenderer SR;

    [HideInInspector]
    public bool isVertical = false;

    [SerializeField]
    float speed = 1;

    [SerializeField]
    float clearPosX = 280;
    Vector3 StartPos = new Vector3(-21f, 4f, 5f);
    float startPosX;

    bool isInvincibility = false;
    bool isCoolTime = false;
    public float SetCoolTime;
    public Image ImgSkillInv;
    public Image ImgSkillRes;
    [SerializeField]
    int SetResCnt;

    bool isSaved = false;
    Vector3 SavePt;
    bool isRes = false;


    private void Start()
    {
        Cnt_leafA = 0;
        Cnt_leafB = 0;
        transform.position = StartPos;
        startPosX = transform.position.x;
        SR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isSaved)
        {
            isSaved = true;
            StartCoroutine("SavePoint");
        }

        if (transform.position.x > clearPosX && !isClear)
        {
            isClear = true;
            DataManager.instance.ClearStage();
        }

        if (Input.GetKeyDown("space") && !isCoolTime)
        {
            StartCoroutine(Invincibility());
            StartCoroutine(CoolTime());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("SceneManager").GetComponent<_SceneManager>().pauseGame();
        }

        if (!isdead){
            if (isClear)
            {
                GameObject.Find("TimeLineController").GetComponent<TimelineController>().Play(2);
            }
            else
                MoveBird();
        }
        else{
            if(Cnt_leafA > SetResCnt - 1 && !isRes)
            {
                StartCoroutine(LoadSavePoint());
            }
            else
                DeadDisplay();
        }

        ImgSkillRes.fillAmount = (1.0f / SetResCnt) * Cnt_leafA;
    }
    IEnumerator SavePoint()
    {
        SavePt = transform.position;
        yield return new WaitForSeconds(2f);
        isSaved = false;
    }

    IEnumerator LoadSavePoint()
    {
        transform.position = SavePt;
        ImgSkillRes.color = new Color32(0, 0, 0, 128);
        yield return new WaitForSeconds(3f);
        isdead = false;
        isRes = true;
    }

    IEnumerator Invincibility()
    {
        isInvincibility = true;
        SR.color = new Color32(255, 255, 255, 100);
        yield return new WaitForSeconds(3f);

        isInvincibility = false;
        SR.color = new Color32(255, 255, 255, 255);
    }

    IEnumerator CoolTime()
    {
        ImgSkillInv.fillAmount = 0;
        isCoolTime = true;
        ImgSkillInv.color = new Color32(255, 255, 255, 128);

        while(ImgSkillInv.fillAmount < 1)
        {
            ImgSkillInv.fillAmount += (1f / SetCoolTime) * 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        ImgSkillInv.color = new Color32(255, 255, 255, 255);
        isCoolTime = false;

    }

    void DeadDisplay()
    {
        isdead = false;

        float PerTemp = (transform.position.x - startPosX) / (clearPosX - startPosX);
        GameObject.Find("SceneManager").GetComponent<_SceneManager>().GameCheck(PerTemp);
    }

    void MoveBird()
    {
        float input;
        Vector3 dir;

        if (Equals(isVertical, false))
        {
            dir = new Vector3(speed * Time.deltaTime, 0, 0);
            if ((input = Input.GetAxis("Vertical")) != 0)
            {
                dir += new Vector3(0, input * 7.5f * Time.deltaTime);
            }
        }
        else
        {
            dir = new Vector3(0, -speed * Time.deltaTime, 0);
            if ((input = Input.GetAxis("Vertical")) != 0)
            {
                dir -= new Vector3(input * 7.5f * Time.deltaTime, 0);
            }
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.y < 0f || pos.y > 1f) isdead = true;

        transform.position += dir;
    }

    public bool getClear()
    {
        return isClear;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Equals(other.gameObject.name, "VerticalSection"))
        {
            isVertical = true;
        }

        if (other.gameObject.CompareTag("leafA")) //other.gameObject.CompareTag("leafB"))
        {
            other.gameObject.SetActive(false);

            Cnt_leafA++;
        }

        if( other.gameObject.CompareTag("leafB"))
        {
            other.gameObject.SetActive(false);
            Cnt_leafB++;
            DataManager.instance.setLeafB( int.Parse(other.gameObject.name.Replace("leafB_", "")));
        }

        if (Equals(other.gameObject.tag.CompareTo("obstacle"), 0) && !isInvincibility)
        {
            isdead = true;
        } 
        if (Equals(other.gameObject.tag.CompareTo("ground"), 0))
        {
            isdead = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (Equals(other.gameObject.name, "VerticalSection"))
        {
            isVertical = false;
        }
    }
}

