using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_Start2 : MonoBehaviour
{
    public BoxCollider2D bc;
    public static bool event2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("event2");
            bc.enabled = false;
            event2 = true;
        }
    }
}
