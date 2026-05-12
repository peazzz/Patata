using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton1_S3 : MonoBehaviour
{
    public static bool BB1_S3_ON;
    private Animator anim;
    public GameObject PushAudio;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "QQ" || other.gameObject.tag == "Player")
        {
            Instantiate(PushAudio, transform.position, transform.rotation);
            BB1_S3_ON = true;
            anim.SetBool("press", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "QQ" || other.gameObject.tag == "Player")
        {
            BB1_S3_ON = false;
            anim.SetBool("press", false);
        }
    }
}
