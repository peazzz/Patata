using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBox : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y+0.1f);
    }
}
