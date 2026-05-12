using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class NextStage2_2_1 : MonoBehaviour
{
    public static bool lv5_1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            lv5_1 = true;
            NextStage2_1.lv4 = false;
            SceneManager.LoadScene("Stage5_2");            
        }
    }
}
