using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGround1_S3 : MonoBehaviour
{
    private float looptime;
    public float LoopTime;
    public Transform Pos1;
    public Transform Pos2;
    public GameObject StrikeAudio;
    private bool AudioCheck;

    public float upTime;
    public float downTime;
    // Start is called before the first frame update
    void Start()
    {
        AudioCheck = false;
        looptime = LoopTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (looptime > 0)
        {            
            looptime -= Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, Pos1.position, upTime);
        }
        else if (looptime <= 0)
        {
            AudioCheck = false;
            transform.position = Vector3.Lerp(transform.position, Pos2.position, downTime);
            Invoke("Re", 0.2f);
        }
    }

    void Re()
    {
        if (!AudioCheck)
        {
            Instantiate(StrikeAudio, transform.position, transform.rotation);
            AudioCheck = true;
        }
        looptime = LoopTime;
    }
}
