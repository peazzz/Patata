using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class EggSystem : MonoBehaviour
{
    public Image EggUI;
    public GameObject EggUIText;
    private float hidetime;
    public static int egg;
    public TMP_Text eggCount;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        eggCount.text = "x" + egg;

        if (Egg.isTrigger)
        {
            hidetime = 3;
            anim.SetTrigger("plus");
            Egg.isTrigger = false;
        }

        if (hidetime > 0)
        {
            EggUI.enabled=true;
            EggUIText.SetActive(true);
            hidetime -= Time.deltaTime;
        }
        else if(hidetime <= 0)
        {
            EggUI.enabled = false;
            EggUIText.SetActive(false);
            hidetime = 0;
        }
       
    }
}
