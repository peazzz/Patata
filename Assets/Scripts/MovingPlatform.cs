using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float LoopTime;
    public float MovingTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoopTime += Time.deltaTime;
        if (LoopTime < MovingTime)
        {
            transform.Translate(0.01f, 0, 0);
        }
        else if (LoopTime > MovingTime && LoopTime < MovingTime*2)
        {
            transform.Translate(-0.01f, 0, 0);
        }
        else if (LoopTime > MovingTime*2)
        {
            LoopTime = 0;
        }
    }
}
