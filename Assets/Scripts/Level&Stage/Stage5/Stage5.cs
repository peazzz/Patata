using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5 : MonoBehaviour
{
    public static bool start; 
    public GameObject warningUI;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start)
        {
            Time.timeScale = 0;
        }
        else
        {
            warningUI.SetActive(false);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            warningUI.SetActive(false);
            start = true;
        }
    }
}
