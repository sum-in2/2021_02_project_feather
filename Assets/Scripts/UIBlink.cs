using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBlink : MonoBehaviour
{
    public Image Img;
    float t = 1;
    float alpha = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (Img == null)
            Img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha > 0.7f) t = -1;
        else if (alpha < 0.3f) t = 1;

        alpha += (t * Time.deltaTime);

        Img.color = new Color32(255, 255, 255, (byte)(alpha * 255));
    }
}
