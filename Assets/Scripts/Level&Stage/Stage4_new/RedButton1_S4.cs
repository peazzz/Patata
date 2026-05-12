using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton1_S4 : MonoBehaviour
{
    public static bool RB1_S4_ON;
    private Animator anim;
    private float pushtime;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (pushtime > 0)
        {
            pushtime -= Time.deltaTime;
            RB1_S4_ON = true;
        }
        else if (pushtime <= 0)
        {
            pushtime = 0;
            RB1_S4_ON = false;
            anim.SetBool("press", false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {           
            pushtime = 1f;
            anim.SetBool("press", true);
        }
    }
}
