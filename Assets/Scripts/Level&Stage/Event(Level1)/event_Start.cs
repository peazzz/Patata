using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_Start : MonoBehaviour
{
    public BoxCollider2D bc;
    public static bool event1;

    void Start()
    {
        event1 = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            bc.enabled = false;
            event1 = true;
        }
    }
}
