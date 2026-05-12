using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGround2_S3 : MonoBehaviour
{
    public static bool LG2_S3_open;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (Key2_S3.getKey2_S3)
        {
            if (other.gameObject.tag == "Player")
            {
                LG2_S3_open = true;
                Destroy(this.gameObject);
            }
        }
    }
}
