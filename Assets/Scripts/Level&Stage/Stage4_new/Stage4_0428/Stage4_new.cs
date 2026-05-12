using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage4_new : MonoBehaviour
{
    public Transform Cam;
    public Transform Event1CamPos;
    public Transform OriginalCamPos;
    public BoxCollider2D event1point;
    public Rigidbody2D[] FakeGroundrb2d;
    private Animator anim;
    public GameObject sandSea;
    public GameObject sandParticle;
    public BoxCollider2D AllGround;
    public GameObject Tutorial;
    public GameObject BlueDoor1;
    private Vector3 BlueDoor1_ON;
    private Vector3 BlueDoor1_OFF;
    public GameObject Music;
    public Transform PlayerNextPos;

    public Image Black;
    private Color black;
    private Color transparent;
    public static bool Event;
    public static bool CamShake;
    public static bool Action;
    public static bool Action2;
    private Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        black = new Color(0, 0, 0, 1);
        transparent = new Color(0, 0, 0, 0);
        Music.SetActive(false);
        BlueDoor1_ON = new Vector3(-9, 74, 0);
        BlueDoor1_OFF = new Vector3(-12, 74, 0);
        sandSea.SetActive(false);
        sandParticle.SetActive(false);
        CamShake = false;
        Event = false;
        anim = GetComponent<Animator>();
        playerPos = GameObject.Find("PLAYER 1").GetComponent<Transform>();
        Black.color = black;
    }

    void Update()
    {
        BD1();
        SandSea();
        nextLevel();

        if (Event)
        {
            Music.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (event_Start_S4.event1_S4)
        {           
            StartCoroutine(Start_S4());
        }
        End();       
    }

    private IEnumerator Start_S4()
    {
        AreaCheck.B = true;
        AreaCheck.Half = false;
        AreaCheck.Second = false;
        AreaCheck.Third = false;
        AreaCheck.Forth = false;
        AreaCheck.Fifth = false;
        PlayerControl.STOP = true;
        //AreaCheck.B = false;
        Cam.position = Vector3.Lerp(Cam.position, Event1CamPos.position, 0.02f);
        anim.SetBool("open1", true);
        yield return new WaitForSeconds(2f);
        Cam.position = Vector3.Lerp(Cam.position, OriginalCamPos.position, 0.05f);
        yield return new WaitForSeconds(0.5f);
        event_Start_S4.event1_S4 = false;
        Invoke("GodTalk", 0.2f);
    }


    void GodTalk()
    {      
        GodTalk1_S4.GT1_S4 = true;
        AreaCheck.B = true;
        event1point.enabled = false;
    }

    void End()
    {
        if (GodTalk1_S4.TalkEnd)
        {
            PlayerControl.STOP = false;
            anim.SetBool("end1", true);
        }
    }

    void SandSea()
    {
        if (Event)
        {
            for (int i = 0; i < FakeGroundrb2d.Length; i++)
            {
                float randomGS = Random.Range(-0.2f, -1);
                FakeGroundrb2d[i].gravityScale = randomGS;
            }
            Tutorial.SetActive(true);
            sandParticle.SetActive(true);
            sandSea.SetActive(true);
            AllGround.enabled = false;
        }
    }

    void BD1()
    {
        if (BlueButton1_S5.BB1_S5_ON)
        {
            BlueDoor1.transform.position = Vector3.Lerp(BlueDoor1.transform.position, BlueDoor1_ON, 0.04f);
        }
        else if (!BlueButton1_S5.BB1_S5_ON)
        {
            BlueDoor1.transform.position = Vector3.Lerp(BlueDoor1.transform.position, BlueDoor1_OFF, 0.04f);
        }
    }

    void nextLevel()
    {
        if (nextFinalStage.lv4)
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
