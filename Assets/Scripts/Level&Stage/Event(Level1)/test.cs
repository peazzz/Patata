using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject God;
    //public GameObject QQ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AreaCheck.Second)
        {
            if (God != null)
            {
                God.SetActive(false);
                //QQ.SetActive(false);
            }
        }

        if (!AreaCheck.Second && !AreaCheck.Third && !AreaCheck.Forth && !AreaCheck.Fifth)
        {
            if (EventControl.Talk1over)
            {
                if (!EventControl.over)
                {
                    God.SetActive(true);
                }
                else if (EventControl.over)
                {
                    God.SetActive(false);
                }
            }
        }
    }
}
