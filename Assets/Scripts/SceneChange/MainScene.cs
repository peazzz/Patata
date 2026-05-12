using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainScene : MonoBehaviour
{
    //public GameObject comic1;
    //public GameObject comic2;
    //public GameObject comic3;
    //public GameObject comic4;
    //public GameObject comic5;
    //public GameObject comic6;
    //public GameObject comic7;
    //public GameObject Particle;

    //private bool opening;
    //private int nextpage;
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //comic1.SetActive(true);
        //Particle.SetActive(false);
        //anim = GetComponent<Animator>();
        //Invoke("One", 1);
        //PlayerControl.STOP = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Opening();

        
        //else
        //{
        //    anim.SetBool("tower", false);
        //}
    }

    void enterTower()
    {
        SceneManager.LoadScene("TowerLobby");
    }

    //void One()
    //{
    //    opening = true;
    //}
    //
    //void Opening()
    //{
    //    if (opening)
    //    {
    //        switch (nextpage)
    //        {
    //            case 0:
    //                break;
    //            case 1:
    //                comic1.SetActive(false);
    //                comic2.SetActive(true);
    //                break;
    //            case 2:
    //                comic2.SetActive(false);
    //                comic3.SetActive(true);
    //                break;
    //            case 3:
    //                comic3.SetActive(false);
    //                comic4.SetActive(true);
    //                break;
    //            case 4:
    //                comic4.SetActive(false);
    //                comic5.SetActive(true);
    //                break;
    //            case 5:
    //                comic5.SetActive(false);
    //                comic6.SetActive(true);
    //                break;
    //            case 6:
    //                comic6.SetActive(false);
    //                comic7.SetActive(true);
    //                Particle.SetActive(true);
    //                break;
    //            case 7:
    //                comic1.SetActive(false);
    //                anim.SetBool("end",true);
    //                Invoke("OpeningEnd", 1.5f);
    //                break;
    //            case 8:
    //                break;
    //        }            
    //    }
    //
    //    if (Input.GetKeyDown(KeyCode.Space)&& nextpage<8&& opening)
    //    {
    //        nextpage++;
    //    }
    //}
    //
    //void OpeningEnd()
    //{
    //    comic7.SetActive(false);
    //    anim.SetBool("end", false);
    //    PlayerControl.STOP = false;
    //}
}
