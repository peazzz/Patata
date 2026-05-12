using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger : MonoBehaviour
{
    public Rigidbody2D trapRB;
    // Start is called before the first frame update
    void Start()
    {
        trapRB.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" | other.gameObject.tag == "QQ")
        {
            trapRB.gravityScale = 1;
        }
    }
}
