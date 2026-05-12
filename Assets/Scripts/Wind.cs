using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public static bool BigWind;
    public static bool inWind;
    public static bool inWind_D;
    public static bool inWind_E_inhouse;

    // Start is called before the first frame update
    void Start()
    {
        inWind = false;
        BigWind = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (NextStage1_3.lv3)
        {
            inWind = true;
            if (AreaCheck.E)
            {
                BigWind = true;
            }
            else
            {
                BigWind = false;
            }

            if (event2_S4.Event2_S4)
            {
                inWind = false;
                BigWind = false;                
            }
        }
        else 
        {
            inWind_D = false;
            inWind = false;
            BigWind = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!event2_S4.Event2_S4)
            {
                inWind = true;
            }
            else
            {
                inWind_D = true;
            }

            if (InOut.InDoor)
            {
                inWind_E_inhouse = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inWind = false;
            if (AreaCheck.D)
            {
                inWind_D = false;
            }

            if (InOut.InDoor)
            {
                inWind_E_inhouse = false;
            }
        }
    }
}
