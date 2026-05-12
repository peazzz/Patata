using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2_S5 : MonoBehaviour
{
    public static bool getKey2_S5;


    void Update()
    {
        if (LockGround2_S5.LG2_S5_open)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            getKey2_S5 = true;
        }
    }
}
