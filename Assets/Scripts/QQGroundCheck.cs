using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QQGroundCheck : MonoBehaviour
{
    public Transform QQ;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground" && !PlayerControl.Dead)
        {
            Debug.Log("123");
            QQ.position = Player.position;
        }
    }
}
