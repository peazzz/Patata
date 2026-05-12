using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class EventControl : MonoBehaviour
{
    [Header("下一關過場物件")]
    public GameObject Player;
    public Transform PlayerNextPos;
    public Transform PlayerNextPos2;
    public Transform PlayerNextPos3;
    private Color black;
    private Color transparent;
    public Image Black;
    [Header("事件物件")]
    public GameObject RockWall;
    public GameObject Spikes;
    public GameObject Ceiling;
    public GameObject God;
    public GameObject MainCam;
    public GameObject EventCam;
    [Header("特效&音效")]
    public GameObject BreakEffect;
    public GameObject DescentEffect;
    public GameObject BreakAudio;

    private Animator anim;
    private bool PlayerStopFix;
    private bool audioplay;
    public static bool over;//確認第一關流程有跑完
    public static bool Talk1over;

    public Tilemap RedGround1Tilemap;
    public TilemapCollider2D RedGround1Collider;
    public GameObject RG1DC;

    private Transform playerPos;
    private Transform QQPos;
    private Transform CameraPos;

    void Awake()
    {
        AreaCheck.Follow = false;
        playerPos = GameObject.Find("PLAYER").GetComponent<Transform>();
        QQPos = GameObject.Find("QQfin").GetComponent<Transform>();
        CameraPos = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Ceiling.SetActive(true);
        BreakEffect.SetActive(false);
        DescentEffect.SetActive(false);
        Spikes.SetActive(false);
        EventCam.SetActive(false);
        God.SetActive(false);
        Talk1over = false;
        over = false;
        audioplay = false;
        black = new Color(0, 0, 0, 1);
        transparent = new Color(0, 0, 0, 0);
        anim = GetComponent<Animator>();
        Black.color = black;

        if (ToStage1_1.Tolv1)
        {
            playerPos.position = new Vector3(24f, 105f, 0);
            QQPos.position = new Vector3(24f, 105f, 0);
            CameraPos.position = new Vector3(11.05f, 104.4f, -10);
        }
    }

    // Update is called once per frame
    void Update()
    {       
        nextLevel();
        RG1();

        if (event_Start.event1 && !event_Start_cam.TriggerEvent1)
        {
            if (EventCam != null)
            {
                EventCam.SetActive(true);
            }
            Ceiling.SetActive(false);
            BreakEffect.SetActive(true);
            if (!audioplay)
            {
                Instantiate(BreakAudio, transform.position, transform.rotation);
                audioplay = true;
            }
            Spikes.SetActive(true);
            anim.SetTrigger("start");
            PlayerControl.STOP = true;
            Invoke("DE", 0.55f);
            Invoke("GodAnim", 0.7f);
            Invoke("GodTalk", 3);           
        }

        if (event_Start2.event2 && !event_Start_cam.TriggerEvent2)
        {
            MainCam.SetActive(false);
            if (EventCam != null)
            {
                EventCam.SetActive(true);
            }
            PlayerControl.STOP = true;
        }

        if (TieRod1_S1.TR1_S1_ON)
        {
            PlayerControl.STOP = true;
            if (!event_Start_cam.RockDoorEvent)
            {
                if (EventCam != null)
                {
                    EventCam.SetActive(true);
                }
            }            
            
            if (event_Start_cam.debug)
            {
                anim.SetTrigger("dooropen");
                Invoke("godTalk2", 2.5f);
            }
        }

        if (GodTalk1_S1.TalkEnd)
        {
            PlayerControl.STOP = false;
            GodTalk1_S1.TalkEnd = false;
        }

        if (GodTalk2_S1.TalkEnd)
        {            
            PlayerControl.STOP = false;
            PlayerStopFix = true;
            TieRod1_S1.TR1_S1_ON = false;
            RockWall.SetActive(false);
            anim.SetTrigger("end");            
            GodTalk2_S1.TalkEnd = false;
            Destroy(EventCam);
            Invoke("Over", 2f);
        }

        if (PlayerStopFix)
        {
            PlayerControl.STOP = false;
        }
    }

    void RG1()
    {
        if (RedButton1_S1.RB1_S1_ON)
        {
            RedGround1Tilemap.color = new Color(1, 0.382f, 0.382f, 1);
            RedGround1Collider.enabled = true;
            RG1DC.SetActive(false);
        }
        else
        {
            RedGround1Tilemap.color = new Color(1, 0.382f, 0.382f, 0.2f);
            RedGround1Collider.enabled = false;
            RG1DC.SetActive(true);
        }
    }

    void DE()
    {
        DescentEffect.SetActive(true);
    }

    void GodAnim()
    {
        God.SetActive(true);        
    }

    void GodTalk()
    {
        Talk1over = true;
        GodTalk1_S1.GT1_S1=true;
    }
    void godTalk2()
    {
        event_Start_cam.RockDoorEvent = true;
        GodTalk2_S1.GT2_S1 = true;
    }

    void Over()
    {
        over = true;
    }

    void nextLevel()
    {
        if (BacktoNewMainScene.backNewMainScene)
        {
            Black.color = Color.Lerp(Black.color, black, 0.2f);
            Player.transform.position = PlayerNextPos3.position;
        }
        else if (ToStage1_3.Tolv3)
        {
            Black.color = Color.Lerp(Black.color, black, 0.2f);
            Player.transform.position = PlayerNextPos2.position;
        }
        else if (NextStage1_1.lv1 && !ToStage1_3.Tolv3)
        {
            Black.color = Color.Lerp(Black.color, black, 0.2f);
            Player.transform.position = PlayerNextPos.position;
        }
        else
        {
            Black.color = Color.Lerp(Black.color, transparent, 0.05f);
        }
    }
}
