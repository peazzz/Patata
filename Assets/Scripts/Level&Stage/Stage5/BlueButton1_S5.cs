using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton1_S5 : MonoBehaviour
{
    public static bool BB1_S5_ON;
    private Animator anim;
    public GameObject PushAudio;
    private bool isAudio;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "QQ" || other.gameObject.tag == "Player" || other.gameObject.tag == "Box")
        {
            if (!isAudio)
            {
                Instantiate(PushAudio, transform.position, transform.rotation);
                isAudio = true;
            }
            BB1_S5_ON = true;
            anim.SetBool("press", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "QQ" || other.gameObject.tag == "Player" || other.gameObject.tag == "Box")
        {
            isAudio = false;
            BB1_S5_ON = false;
            anim.SetBool("press", false);
        }
    }
}
