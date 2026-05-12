using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton1_S3 : MonoBehaviour
{
    public static bool RB1_S3_ON;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            RB1_S3_ON = true;
            anim.SetBool("press", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            RB1_S3_ON = false;
            anim.SetBool("press", false);
        }
    }
}
