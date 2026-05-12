using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallLimit : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < -1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, -1);
        }
    }
}
