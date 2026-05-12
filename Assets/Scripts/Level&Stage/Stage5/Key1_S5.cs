using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1_S5 : MonoBehaviour
{
    public static bool getKey1_S5;


    void Update()
    {
        if (LockGround1_S5.LG1_S5_open)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            getKey1_S5 = true;
        }
    }
}
