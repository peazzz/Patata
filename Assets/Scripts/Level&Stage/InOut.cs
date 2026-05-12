using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOut : MonoBehaviour
{
    public static bool In;
    public static bool Out;
    private float cooldown;
    public static bool InDoor;

    // Start is called before the first frame update
    void Start()
    {
        In = false;
        Out = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else if (cooldown <= 0)
        {
            cooldown = 0;
        }
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        if (Input.GetKey(KeyCode.UpArrow) && !In && cooldown<=0)
    //        {
    //            In = true;
    //            Out = false;
    //            Debug.Log("in");
    //            cooldown = 1;
    //            InDoor = true;
    //        }
    //        else if (Input.GetKey(KeyCode.UpArrow) && In && cooldown <= 0)
    //        {
    //            In = false;
    //            Out = true;
    //            Debug.Log("out");
    //            cooldown = 1;
    //            InDoor = false;
    //        }
    //    }
    //}
}
