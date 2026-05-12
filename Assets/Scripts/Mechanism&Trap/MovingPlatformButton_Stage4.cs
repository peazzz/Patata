using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformButton_Stage4 : MonoBehaviour
{
    public static bool MP_On_S4;
    private Animator anim;
    private float time; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if (time <= 0)
        {
            time = 0;
            MP_On_S4 = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "QQTongue" || other.gameObject.tag == "Player")
        {
            MP_On_S4 = true;
            anim.SetTrigger("push");
            time = 2;
        }
    }
}
