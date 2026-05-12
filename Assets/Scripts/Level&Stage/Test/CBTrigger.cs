using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBTrigger : MonoBehaviour
{

    public static bool CB;
    private float CBtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CB)
        {
            CBtime += Time.deltaTime;
        }

        if (CBtime > 5)
        {
            CBtime = 0;
            PlayerControl.STOP = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CB = true;
            PlayerControl.STOP = true;
        }
    }
}
