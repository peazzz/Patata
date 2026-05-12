using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBoxButton1_S2 : MonoBehaviour
{
    public GameObject UpBox;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("press", true);
            UpBox.transform.position = new Vector2(UpBox.transform.position.x, UpBox.transform.position.y + 0.1f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("press", false);
        }
    }
}
