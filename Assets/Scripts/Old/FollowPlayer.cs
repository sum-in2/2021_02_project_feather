using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float cameraSpeed = 3.0f;
    public float TopY = 3.5f;
    public float BottomY = -3.5f;
    public float minX = 2f;

    public GameObject player;

    float StartY;
    Vector3 trPos;

    private void Start()
    {
        StartY = BottomY;
    }

    private void LateUpdate()
    {
        //if (Equals(SceneManager.GetActiveScene().name, "stage2"))
            //stage2();

        if (Equals(player.GetComponent<birdController>().getClear(), false))//게임 진행중의 카메라
            Moving();
    }

    void Moving()
    {
        Vector3 dir = player.transform.position - transform.position;
        Vector3 moveVector = new Vector3((dir.x + 5f) * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0);

        transform.Translate(moveVector);

        trPos = transform.position;

        if (trPos.y < BottomY)
            trPos = new Vector3(trPos.x, BottomY, -3);
        if (trPos.y > TopY)
            trPos = new Vector3(trPos.x, TopY, -3);
        if (trPos.x < minX)
            trPos = new Vector3(minX, trPos.y, -3);

        transform.position = trPos;
    }

   /*void stage2() 
    {
        float startX = 25f;
        float EndX = 100f;
        float EndY = 8.0f;

        if(startX < transform.position.x && transform.position.x < EndX)
        {
            // miny,maxy값 조절 (경사면)
            // y = 22 ~ 8.4

            ramp(EndY, startX, EndX);
        }

        if(player.GetComponent<birdController>().isVertical == true)
        {
            // 조작 변경
            // x 200 고정
            // y 5 ~ -40

            BottomY = -52f;
            if(transform.position.y < -34f)
                TopY = -34f;
        }
    }

    void ramp(float EndY, float startX, float EndX)
    {
        BottomY -= TopY - Mathf.Lerp(StartY, EndY, (transform.position.x - startX) / (EndX - startX));
        TopY = Mathf.Lerp(StartY, EndY, (transform.position.x - startX) / (EndX - startX));
    }*/
}