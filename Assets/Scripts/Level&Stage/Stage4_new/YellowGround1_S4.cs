using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGround1_S4 : MonoBehaviour
{
    public Transform StartPos;
    public Transform EndPos;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartPos.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BirdShoot.isDashing)
        {
            transform.position = Vector3.Lerp(transform.position, EndPos.position, 0.65f);
            time = 1.5f;
        }
        else
        {
            if (time == 0)
            {
                transform.position = Vector3.Lerp(transform.position, StartPos.position, 0.05f);
            }
        }
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if (time <= 0)
        {
            time = 0;
        }
    }
}
