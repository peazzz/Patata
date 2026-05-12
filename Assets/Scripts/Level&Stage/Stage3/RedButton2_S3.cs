using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton2_S3 : MonoBehaviour
{
    public static bool RB2_S3_ON;
    private Animator anim;
    private float time;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (time > 0 && RB2_S3_ON)
        {
            time -= Time.deltaTime;
        }
        else if (time <= 0 && RB2_S3_ON)
        {
            RB2_S3_ON = false;
            anim.SetBool("press", false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            time = 1;
            RB2_S3_ON = true;
            anim.SetBool("press", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {          
            time = 1;
        }
    }
}
