using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ToStage1_3 : MonoBehaviour
{
    public static bool Tolv3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            NextStage1_1.lv1 = true;
            NextStage1_2.lv2 = true;
            ToStage1_1.Tolv1 = false;
            Tolv3 = true;
            Invoke("nextscene", 0.5f);
        }
    }

    void nextscene()
    {
        SceneManager.LoadScene("Stage3_new");
    }
}
