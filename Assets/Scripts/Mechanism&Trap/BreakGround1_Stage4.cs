using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGround1_Stage4 : MonoBehaviour
{
    public GameObject dustEffect;
    public GameObject breakEffect;
    public Transform point;
    public Animator hideGroundAnim;
    private bool touched;

    // Start is called before the first frame update
    void Start()
    {
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!touched)
            {
                Instantiate(dustEffect, point.position, Quaternion.identity);
                touched = true;
            }
            else if (touched)
            {
                Break();
            }
        }
    }

    void Break()
    {
        Instantiate(breakEffect, point.position, Quaternion.identity);
        hideGroundAnim.SetBool("hide", true);
        Destroy(this.gameObject);
    }
}
