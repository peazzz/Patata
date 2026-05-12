using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton1_S1 : MonoBehaviour
{
    public static bool RB1_S1_ON;
    private Animator anim;
    private float pushtime;
    public GameObject PushAudio;
    private bool audioplay;

    void Start()
    {
        audioplay = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (pushtime > 0)
        {
            pushtime -= Time.deltaTime;
            RB1_S1_ON = true;
            if (!audioplay)
            {
                audioplay = true;
                Instantiate(PushAudio, transform.position, transform.rotation);
            }
        }
        else if (pushtime <= 0)
        {
            audioplay = false;
            pushtime = 0;
            RB1_S1_ON = false;
            anim.SetBool("press", false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pushtime = 2f;
            anim.SetBool("press", true);
        }
    }
}
