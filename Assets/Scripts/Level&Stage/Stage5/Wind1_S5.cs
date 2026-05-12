using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind1_S5 : MonoBehaviour
{
    public static bool inWind1_S5;

    void Update()
    {
        if (!NextStage2_1.lv4)
        {
            inWind1_S5 = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inWind1_S5 = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inWind1_S5 = false;
        }
    }
}
