using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    public GameObject BreakPlatform;
    public GameObject moreBreakPlatform;
    private bool touch;

    public GameObject DustEffect;
    public GameObject BreakEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && !touch)
        {
            BreakPlatform.SetActive(false);
            Instantiate(DustEffect, transform.position, Quaternion.identity);
            moreBreakPlatform.SetActive(true);
            touch = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && touch)
        {
            Instantiate(BreakEffect, transform.position, Quaternion.identity);
            moreBreakPlatform.SetActive(false);
            Destroy(gameObject);
        }
    }
}
