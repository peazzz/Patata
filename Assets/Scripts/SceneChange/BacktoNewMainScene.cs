using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoNewMainScene : MonoBehaviour
{
    public static bool backNewMainScene;
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
            backNewMainScene = true;
            Invoke("backScene", 0.5f);
            PlayerControl.STOP = true;
        }
    }

    void backScene()
    {
        PlayerControl.STOP = false;
        SceneManager.LoadScene("NewMainScene");     
    }
}
