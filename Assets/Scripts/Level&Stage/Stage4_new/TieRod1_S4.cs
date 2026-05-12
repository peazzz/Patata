using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieRod1_S4 : MonoBehaviour
{
    public static bool TR1_S4_ON;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TR1_S4_ON = true;
            anim.SetBool("turn", true);
        }
    }
}
