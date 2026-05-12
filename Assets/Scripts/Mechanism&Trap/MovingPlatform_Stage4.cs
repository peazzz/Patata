using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_Stage4 : MonoBehaviour
{
    public Transform Endpoint;
    public Transform Startpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (MovingPlatformButton_Stage4.MP_On_S4)
        {
            transform.position = Vector3.Lerp(transform.position, Endpoint.position, 0.04f);
        }
        else if (!MovingPlatformButton_Stage4.MP_On_S4)
        {
            transform.position = Vector3.Lerp(transform.position, Startpoint.position, 0.005f);
        }
    }
}
