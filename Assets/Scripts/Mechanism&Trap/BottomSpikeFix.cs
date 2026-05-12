using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomSpikeFix : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerFoot.touchGround)
            {
                PlayerControl.Dead = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerFoot.touchGround)
            {
                PlayerControl.Dead = true;
            }
        }
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        if (PlayerControl.touchGround)
    //        {
    //            PlayerControl.Dead = true;
    //        }
    //    }
    //}

}
