using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton_Common : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "QQ")
        {
            anim.SetBool("press", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "QQ")
        {
            anim.SetBool("press", false);
        }
    }
}
