using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringLeft : MonoBehaviour
{
    public Rigidbody2D playerRB2D;
    private Animator anim;
    public GameObject SpringAudio;
    public static bool touchSpring;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            touchSpring = true;
            anim.SetTrigger("touch");
            Instantiate(SpringAudio, transform.position, transform.rotation);
            PlayerControl.CanDash = true;
            //playerRB2D.AddForce(Vector2.left * 1000);
            //Invoke("cancelTouch", 0.2f);
        }
    }

    void cancelTouch()
    {
        touchSpring = false;
    }
}
