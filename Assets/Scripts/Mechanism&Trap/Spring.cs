using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public Rigidbody2D playerRB2D;
    private Animator anim;
    public GameObject SpringAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (!NextStage1_3.lv3)
        {
            anim = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Player")
        {
            if (!BirdShoot.touchbird)
            {
                Instantiate(SpringAudio, transform.position, transform.rotation);
                PlayerControl.CanDash = true;
                if (!NextStage1_3.lv3)
                {
                    playerRB2D.velocity = Vector2.up * 25;
                    anim.SetTrigger("touch");
                }
                else
                {
                    playerRB2D.velocity = Vector2.up * 15;
                }
                
            }
        }
    }
}
