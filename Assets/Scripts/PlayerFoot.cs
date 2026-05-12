using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    public static bool touchGround;
    public Animator anim;

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            touchGround = true;

            if (PlayerControl.LandTime > 0.3f)
            {
                anim.SetTrigger("land");
                PlayerControl.LandTime = 0;
            }
        }
        else if (other.gameObject.tag == "Platform")
        {
            touchGround = true;
        }
        else if (other.gameObject.tag == "Box")
        {
            touchGround = true;
        }
        else if (other.gameObject.tag == "Desert")
        {
            touchGround = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            touchGround = true;
        }
        else if (other.gameObject.tag == "Platform")
        {
            touchGround = true;
        }
        else if (other.gameObject.tag == "Box")
        {
            touchGround = true;
        }
        else if (other.gameObject.tag == "Desert")
        {
            touchGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            touchGround = false;
        }
        else if (other.gameObject.tag == "Platform")
        {
            touchGround = false;
        }
        else if (other.gameObject.tag == "Box")
        {
            touchGround = false;
        }
        else if (other.gameObject.tag == "Desert")
        {
            touchGround = false;
        }
    }

}
