using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingPlatform : MonoBehaviour
{
    public GameObject platform;
    public GameObject axis;
    private LineRenderer lr;
    public Rigidbody2D platformRb;
    // Start is called before the first frame update
    void Start()
    {
        platformRb.gravityScale = 0;
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, platform.transform.position);
        lr.SetPosition(1, axis.transform.position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            platformRb.gravityScale = 3;
        }
    }
}
