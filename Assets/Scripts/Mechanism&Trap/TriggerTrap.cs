using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    private bool isTrigger;
    public GameObject trap;
    public GameObject HideGround;
    public GameObject BreakEffect;
    public GameObject DescentEffect;
    public GameObject BreakAudio;
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
        if (!isTrigger)
        {
            if (other.gameObject.tag == "Player" | other.gameObject.tag == "QQ")
            {
                Instantiate(BreakAudio, transform.position, transform.rotation);
                HideGround.SetActive(false);
                BreakEffect.SetActive(true);
                trap.SetActive(true);
                Invoke("DE", 1);
                isTrigger = true;
            }
        }
    }

    void DE()
    {
        DescentEffect.SetActive(true);
    }
}
