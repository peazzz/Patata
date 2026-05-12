using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class NextStage1_2 : MonoBehaviour
{
    public static bool lv2;
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
            lv2 = true;
            Invoke("nextscene", 1f);
        }
    }

    void nextscene()
    {
        SceneManager.LoadScene("Stage3_new");
    }
}
