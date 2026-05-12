using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2 : MonoBehaviour
{
    [Header("下一關過場物件")]
    private Color black;
    private Color transparent;
    public Transform PlayerNextPos;
    public Image Black;

    [Header("物件")]
    public GameObject BlueDoor1;

    [Header("座標")]
    public Transform BlueDoor1_OnPos;
    public Transform BlueDoor1_OffPos;

    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("PLAYER 1").GetComponent<Transform>();
        AreaCheck.Follow = false;
        black = new Color(0, 0, 0, 1);
        transparent = new Color(0, 0, 0, 0);
        Black.color = black;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BTR1();
        nextLevel();
    }

    void BTR1()
    {
        if (BlueTieRod1_S2.BTR1_S2_ON)
        {
            BlueDoor1.transform.position = Vector3.Lerp(BlueDoor1.transform.position, BlueDoor1_OnPos.position, 0.04f);
        }
        else if (!BlueTieRod1_S2.BTR1_S2_ON)
        {
            BlueDoor1.transform.position = Vector3.Lerp(BlueDoor1.transform.position, BlueDoor1_OffPos.position, 0.04f);
        }
    }

    void nextLevel()
    {
        if (NextStage1_2.lv2)
        {
            Black.color = Color.Lerp(Black.color, black, 0.2f);
            playerPos.position = PlayerNextPos.position;
        }
        else
        {
            Black.color = Color.Lerp(Black.color, transparent, 0.05f);
        }
    }
}
