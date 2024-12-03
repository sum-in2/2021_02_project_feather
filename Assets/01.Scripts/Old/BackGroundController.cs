using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    int count = 2;
    int index = 2;
    public int repeat = 10;
    float Progress = 0;
    public float ProgressPer;

    public float speed;

    public GameObject[] BackGrounds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
            gameObject.transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);

        Progress = (-gameObject.transform.localPosition.x / 12.8f);
        count = 2 + (int)(Progress);

        if ((index) != count)
        {
            BackGrounds[count % 3].transform.localPosition = new Vector3(count * 12.8f, 0, 1);
            index = count;
            Progress++;
        }

        ProgressPer = Progress / repeat * 100;
        if (ProgressPer >= 100)
        {
            GameObject.Find("SceneManager").GetComponent<_SceneManager>().GameCheck(ProgressPer);
        }
    }
}