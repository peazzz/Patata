using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieRod1_S1 : MonoBehaviour
{
    private bool istouched;
    public static bool TR1_S1_ON;
    private Animator anim;
    public GameObject PullAudio;
    // Start is called before the first frame update
    void Start()
    {
        istouched = false;
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!istouched)
            {
                Instantiate(PullAudio, transform.position, transform.rotation);
                TR1_S1_ON = true;
                istouched = true;
                anim.SetBool("turn", true);
            }
        }
    }
}
