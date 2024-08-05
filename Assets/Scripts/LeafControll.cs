using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeafControll : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer[] LeafB = new SpriteRenderer[3];

    int[] ActiveLeafB = new int[3];

    // Update is called once per frame
    private void Awake()
    {
        for (int i = 0; i < 3; i++)
            ActiveLeafB[i] = DataManager.instance.getStageLeafB(i);

        for (int i = 0; i < 3; i++)
            if (ActiveLeafB[i] == 1)
                LeafB[i].color = new Color32(255, 255, 0, 128);
    }
}
