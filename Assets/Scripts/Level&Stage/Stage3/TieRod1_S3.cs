using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieRod1_S3 : MonoBehaviour
{
    public static bool TR1_S3_ON;
    private Animator anim;
    public GameObject PullAudio;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(PullAudio, transform.position, transform.rotation);
            TR1_S3_ON = true;
            anim.SetBool("turn", true);
        }
    }
}
