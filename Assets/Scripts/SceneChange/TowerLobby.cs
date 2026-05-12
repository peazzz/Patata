using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class TowerLobby : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextStage1.next)
        {
            Invoke("nextScene", 0.5f);
            anim.SetTrigger("exit");
            nextStage1.next = false;
            PlayerControl.STOP = true;
        }

        //if (BacktoNewMainScene.backNewMainScene)
        //{
        //    Invoke("backScene", 0.5f);
        //    anim.SetTrigger("exit");
        //    PlayerControl.STOP = true;
        //    //BacktoNewMainScene.backNewMainScene = false;
        //}
    }

    void nextScene()
    {
        SceneManager.LoadScene("Stage1_Tutorial");
        PlayerControl.STOP = false;
    }

    void backScene()
    {
        SceneManager.LoadScene("NewMainScene");
        PlayerControl.STOP = false;
    }
}
