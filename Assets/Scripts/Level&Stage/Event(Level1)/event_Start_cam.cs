using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class event_Start_cam : MonoBehaviour
{
    public GameObject MainCam;
    public GameObject EventCam;
    public Transform event1;
    public Transform redbutton;
    public Transform rockdoor;
    public Transform event2;
    public Transform B;
    public Transform E;

    public GameObject RockDoorAudio;
    private bool audioplay;

    public static bool TriggerEvent1;
    private bool ButtonEvent;
    public static bool RockDoorEvent;
    public static bool TriggerEvent2;
    public static bool debug;

    // Start is called before the first frame update
    void Start()
    {
        audioplay = false;
        TriggerEvent1 = false;
        RockDoorEvent = false;
        TriggerEvent2 = false;
        debug = false;
    }

    // Update is called once per frame
    void Update()
    {
        Edebug();
        if (event_Start.event1 && !TriggerEvent1)
        {
            Invoke("Event1", 1);
        }
        if (TieRod1_S1.TR1_S1_ON && !ButtonEvent)
        {
            ButtonEvent = true;
            redButton();
        }
    }

    void Event1()
    {
        MainCam.SetActive(false);
        EventCam.SetActive(true);
        transform.position = Vector3.Lerp(transform.position, event1.position, 0.05f);  //事件相機移到event1位置       
        Invoke("areaB", 2); //2秒後執行areaB(執行過程在Script_EventControl)
        TriggerEvent1 = true;
    }

    void redButton()
    {
        MainCam.SetActive(false);
        EventCam.SetActive(true);
        transform.position = redbutton.position;
        Invoke("RockDoorPos", 1);        
    }

    void Event2()
    {
        if (event_Start2.event2 && !TriggerEvent2)
        {
            transform.position = Vector3.Lerp(transform.position, event2.position, 0.05f);
            Invoke("areaE", 2);
        }
    }

    void RockDoorPos()
    {
        if (!audioplay)
        {
            audioplay = true;
            Instantiate(RockDoorAudio, transform.position, transform.rotation);
        }
        transform.position = rockdoor.position;      
        debug = true;
    }

    void Edebug()
    {
        if (debug)
        {
            Invoke("areaE", 2);
        }
    }

    void areaB()
    {       
        transform.position = Vector3.Lerp(transform.position, B.position, 0.05f);
        Invoke("CamChange", 1);
    }

    void areaE()
    {
        transform.position = Vector3.Lerp(transform.position, E.position, 0.05f);
        Invoke("CamChange", 1);
    }

    void CamChange()
    {
        //if (ButtonEvent)
        //{
        //    RockDoorEvent = true;
        //}     
        MainCam.SetActive(true);
        EventCam.SetActive(false);
        debug = false;
    }
}
