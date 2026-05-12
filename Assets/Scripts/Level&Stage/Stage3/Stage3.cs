using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Stage3 : MonoBehaviour
{
    [Header("門_物件")]
    public GameObject BlueDoor5;
    public GameObject BlueDoor6;
    public GameObject BlueDoor7;
    public GameObject BlueDoor8;
    public GameObject RedDoor1;
    public GameObject RedDoor2;

    [Header("門_座標")]
    public Transform BlueDoor5_On_Pos;
    public Transform BlueDoor5_Off_Pos;
    public Transform BlueDoor6_On_Pos;
    public Transform BlueDoor6_Off_Pos;
    public Transform BlueDoor7_On_Pos;
    public Transform BlueDoor7_Off_Pos;
    public Transform BlueDoor8_On_Pos;
    public Transform BlueDoor8_Off_Pos;
    public Transform RedDoor1_On_Pos;
    public Transform RedDoor1_Off_Pos;
    public Transform RedDoor2_On_Pos;
    [Header("過場")]
    public Transform PlayerNextPos1;
    public Transform PlayerNextPos2;
    private Color black;
    private Color transparent;
    public Image Black;

    private Transform playerPos;
    private Transform QQPos;
    private Transform CameraPos;
    private float RedDoor1Time;

    void Awake()
    {
        AreaCheck.Follow = false;
        playerPos = GameObject.Find("PLAYER 1").GetComponent<Transform>();
        QQPos = GameObject.Find("QQfin").GetComponent<Transform>();
        CameraPos = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        black = new Color(0, 0, 0, 1);
        transparent = new Color(0, 0, 0, 0);
        Black.color = black;
        if (!ToStage1_3.Tolv3)
        {
            playerPos.position = new Vector3(0, 0.5f, 0);
            QQPos.position = new Vector3(0, 0.5f, 0);
            CameraPos.position= new Vector3(11.05f, 5.45f, -10);
        }
        else if (ToStage1_3.Tolv3)
        {
            playerPos.position = new Vector3(1, 51.5f, 0);
            QQPos.position = new Vector3(1, 51.5f, 0);
            CameraPos.position = new Vector3(14f, 56.63f, -10);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        nextLevel();

        BD5();
        BD6();
        BD7();
        BD8();
        RD1();
        RD2();

    }

    void BD5()
    {
        if (BlueButton1_S3.BB1_S3_ON)
        {
            BlueDoor5.transform.position = Vector3.Lerp(BlueDoor5.transform.position, BlueDoor5_On_Pos.position, 0.04f);
        }
        else if (!BlueButton1_S3.BB1_S3_ON)
        {
            BlueDoor5.transform.position = Vector3.Lerp(BlueDoor5.transform.position, BlueDoor5_Off_Pos.position, 0.04f);
        }
    }
    void BD6()
    {
        if (BlueButton1_S3.BB1_S3_ON)
        {
            BlueDoor6.transform.position = Vector3.Lerp(BlueDoor6.transform.position, BlueDoor6_On_Pos.position, 0.04f);
        }
        else if (!BlueButton1_S3.BB1_S3_ON)
        {
            BlueDoor6.transform.position = Vector3.Lerp(BlueDoor6.transform.position, BlueDoor6_Off_Pos.position, 0.04f);
        }
    }
    void BD7()
    {
        if (BlueButton1_S3.BB1_S3_ON)
        {
            BlueDoor7.transform.position = Vector3.Lerp(BlueDoor7.transform.position, BlueDoor7_On_Pos.position, 0.04f);
        }
        else if (!BlueButton1_S3.BB1_S3_ON)
        {
            BlueDoor7.transform.position = Vector3.Lerp(BlueDoor7.transform.position, BlueDoor7_Off_Pos.position, 0.04f);
        }
    }
    void BD8()
    {
        if (BlueButton1_S3.BB1_S3_ON)
        {
            BlueDoor8.transform.position = Vector3.Lerp(BlueDoor8.transform.position, BlueDoor8_On_Pos.position, 0.04f);
        }
        else if (!BlueButton1_S3.BB1_S3_ON)
        {
            BlueDoor8.transform.position = Vector3.Lerp(BlueDoor8.transform.position, BlueDoor8_Off_Pos.position, 0.04f);
        }
    }
    void RD1()
    {
        if (RedButton1_S3.RB1_S3_ON)
        {
            RedDoor1.transform.position = Vector3.Lerp(RedDoor1.transform.position, RedDoor1_On_Pos.position, 0.2f);
            RedDoor1Time = 1;
        }
        else if (!RedButton1_S3.RB1_S3_ON)
        {            
            if (RedDoor1Time > 0)
            {
                RedDoor1Time -= Time.deltaTime;
            }
            else if (RedDoor1Time <= 0)
            {
                RedDoor1.transform.position = Vector3.Lerp(RedDoor1.transform.position, RedDoor1_Off_Pos.position, 0.04f);
            }
        }
    }
    void RD2()
    {
        if (TieRod1_S3.TR1_S3_ON)
        {
            RedDoor2.transform.position = Vector3.Lerp(RedDoor2.transform.position, RedDoor2_On_Pos.position, 0.04f);
        }
    }
   

    void nextLevel()
    {
        if (ToStage1_1.Tolv1)
        {
            Black.color = Color.Lerp(Black.color, black, 0.2f);
            playerPos.position = PlayerNextPos1.position;
        }
        else if (NextStage1_3.lv3)
        {
            Black.color = Color.Lerp(Black.color, black, 0.2f);
            playerPos.position = PlayerNextPos2.position;
        }
        else
        {
            Black.color = Color.Lerp(Black.color, transparent, 0.05f);
        }
    }
}
