using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Stage4 : MonoBehaviour
{
    public Transform Cam;

    public Transform Event1CamPos;
    private Animator anim;
    public BoxCollider2D event1point;

    [Header("門座標")]
    public Transform RedDoor1_On_Pos;
    public Transform RedDoor2_On_Pos;

    [Header("門物件")]
    public GameObject RedDoor1;
    public GameObject RedDoor2;

    [Header("瓦片物件、瓦片碰撞體")]
    public Tilemap RedGround1Tilemap;
    public TilemapCollider2D RedGround1Collider;

    [Header("風沙粒子特效")]
    public ParticleSystem Wind2PS;
    public ParticleSystem Wind5PS;

    [Header("風沙阻力")]
    public AreaEffector2D Wind2AE;
    public AreaEffector2D Wind5AE;

    private Color PS_off;
    private Color PS_on;

    // Start is called before the first frame update
    void Start()
    {
        PS_on = new Color(0.97f, 0.87f, 0.71f, 1);
        PS_off = new Color(0.97f, 0.87f, 0.71f, 0);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(event_Start_S4.event1_S4)
        {
            StartCoroutine(Start_S4());            
        }

        //Door
        RD1();
        RD2();
        RG1();

        End();
    }


    void RD1()
    {
        if (TieRod1_S4.TR1_S4_ON)
        {
            RedDoor1.transform.position = Vector3.Lerp(RedDoor1.transform.position, RedDoor1_On_Pos.position, 0.04f);
            var main = Wind2PS.main;
            main.startColor = Color.Lerp(main.startColor.color, PS_off, 0.04f);
            Wind2AE.forceMagnitude = Mathf.Lerp(Wind2AE.forceMagnitude, 0, 0.04f);
        }
    }

    void RD2()
    {
        if (TieRod2_S4.TR2_S4_ON)
        {
            RedDoor2.transform.position = Vector3.Lerp(RedDoor2.transform.position, RedDoor2_On_Pos.position, 0.04f);
            var main = Wind5PS.main;
            main.startColor = Color.Lerp(main.startColor.color, PS_on, 0.04f);
            Wind5AE.forceMagnitude = Mathf.Lerp(Wind5AE.forceMagnitude, 50, 0.04f);
        }
    }

    void RG1()
    {
        if (RedButton1_S4.RB1_S4_ON)
        {
            RedGround1Tilemap.color = new Color(1, 0.382f, 0.382f, 1);
            RedGround1Collider.enabled = true;
        }
        else
        {
            RedGround1Tilemap.color = new Color(1, 0.382f, 0.382f, 0.2f);
            RedGround1Collider.enabled = false;
        }
    }

    private IEnumerator Start_S4()
    {     
        PlayerControl.STOP = true;
        //AreaCheck.B = false;
        Cam.position = Vector3.Lerp(Cam.position, Event1CamPos.position, 0.01f);
        anim.SetBool("open1", true);
        yield return new WaitForSeconds(2f);
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
}
