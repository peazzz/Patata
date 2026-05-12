using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGround2_S5 : MonoBehaviour
{
    public GameObject OpenAudio;
    public static bool LG2_S5_open;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (Key2_S5.getKey2_S5)
        {
            if (other.gameObject.tag == "Player")
            {
                LG2_S5_open = true;
                Instantiate(OpenAudio, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
