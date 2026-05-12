using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodTrashTalk : MonoBehaviour
{
    public Animator anim;
    public GameObject Godtalk1;
    public GameObject Godtalk2;
    public GameObject Godtalk3;
    // Start is called before the first frame update
    void Start()
    {
        Godtalk1.SetActive(false);
        Godtalk2.SetActive(false);
        Godtalk3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GTT1();
        GTT2();
        GTT3();
    }

    void GTT1()
    {
        if (AreaCheck.C)
        {
            if (Godtalk1 != null)
            {
                Godtalk1.SetActive(true);
                anim.SetBool("open", true);               
            }
            Invoke("close", 3);
            Destroy(Godtalk1, 3);
        }
    }

    void GTT2()
    {
        if (PlayerControl.Dead)
        {
            if (Godtalk2 != null)
            {
                Godtalk2.SetActive(true);
                Invoke("Retract", 3);
            }
        }
    }

    void GTT3()
    {
        if (AreaCheck.E)
        {
            if (Godtalk3 != null)
            {
                Godtalk3.SetActive(true);
                anim.SetBool("open", true);
            }
            Destroy(Godtalk3, 5);
            Invoke("close", 5);
        }
    }

    void Retract()
    {
        Godtalk2.SetActive(false);
    }

    void close()
    {
        anim.SetBool("open", false);
    }
}
