using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_branch : MonoBehaviour
{
    public float speed = 5f;
    public float RotSpeed = 90;
    public GameObject bird;

    private void Start()
    {
        speed += Random.Range(-2f, 2f);
        RotSpeed += Random.Range(-60f, 61f);
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.transform.position.x > transform.position.x - 50f)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * RotSpeed);
            transform.position -= new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0);
        }


        if (transform.position.y < -14) {
            if (transform.position.x < 150)
                transform.position = new Vector2(transform.position.x + 100, 20);
            else
                gameObject.SetActive(false);
        }
    }
}
