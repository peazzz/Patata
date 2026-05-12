using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBoxButton1_S3 : MonoBehaviour
{
    public GameObject RightBox;
    private Animator anim;
    private bool touched;
    public static bool stop;

    void Start()
    {
        stop = false;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (touched)
        {
            if (!stop)
            {
                RightBox.transform.position = new Vector2(RightBox.transform.position.x + 0.08f, RightBox.transform.position.y);
            }
            else
            {
                RightBox.transform.position = new Vector2(102, 41);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            touched = true;
            anim.SetBool("press", true);
        }
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        anim.SetBool("press", false);
    //    }
    //}
}
