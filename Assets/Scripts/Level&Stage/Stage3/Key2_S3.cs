using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2_S3 : MonoBehaviour
{
    public static bool getKey2_S3;


    void Update()
    {
        if (LockGround2_S3.LG2_S3_open)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            getKey2_S3 = true;
        }
    }

}
