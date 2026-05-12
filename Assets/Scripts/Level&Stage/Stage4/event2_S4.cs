using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event2_S4 : MonoBehaviour
{
    public BoxCollider2D bc;
    public static bool Event2_S4;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            bc.enabled = false;
            Event2_S4 = true;
        }
    }
}
