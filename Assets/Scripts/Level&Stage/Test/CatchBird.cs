using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchBird : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        AreaCheck.B = true;
        AreaCheck.Half = false;
        AreaCheck.Second = false;
        AreaCheck.Third = false;
        AreaCheck.Forth = false;
        AreaCheck.Fifth = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CBTrigger.CB)
        {
            anim.SetTrigger("trigger");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
