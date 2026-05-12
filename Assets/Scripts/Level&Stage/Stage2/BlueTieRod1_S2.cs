using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTieRod1_S2 : MonoBehaviour
{
    public static bool BTR1_S2_ON;
    private Animator anim;
    public GameObject PullAudio;
    public GameObject PullAudio2;
    // Start is called before the first frame update
    void Start()
    {
        BTR1_S2_ON = false;
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "QQ")
        {
            if (!BTR1_S2_ON)
            {
                Instantiate(PullAudio, transform.position, transform.rotation);
                BTR1_S2_ON = true;
                anim.SetBool("On", true);
            }
            else if (BTR1_S2_ON)
            {
                Instantiate(PullAudio2, transform.position, transform.rotation);
                BTR1_S2_ON = false;
                anim.SetBool("On", false);
            }
        }
    }
}
