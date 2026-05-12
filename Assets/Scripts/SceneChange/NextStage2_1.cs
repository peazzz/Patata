using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class NextStage2_1 : MonoBehaviour
{
    public static bool lv4;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                SceneManager.LoadScene("Stage5");
                lv4 = true;
                NextStage1_3.lv3 = false;
            }
        }
    }
}
