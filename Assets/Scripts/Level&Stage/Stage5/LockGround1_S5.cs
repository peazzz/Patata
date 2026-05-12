using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGround1_S5 : MonoBehaviour
{
    public GameObject OpenAudio;
    public static bool LG1_S5_open;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (Key1_S5.getKey1_S5)
        {
            if (other.gameObject.tag == "Player")
            {
                LG1_S5_open = true;
                Instantiate(OpenAudio, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
