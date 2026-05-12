using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    public GameObject EatAudio;
    private SpriteRenderer nutImg;
    private BoxCollider2D BC;
    public GameObject lightt;
    private float time;
    public bool Bad;
    // Start is called before the first frame update
    void Start()
    {
        nutImg = GetComponent<SpriteRenderer>();
        BC= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if(time<=0)
        {
            time = 0;
            nutImg.enabled = true;
            lightt.SetActive(true);
            BC.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="QQ" || other.gameObject.tag == "Player")
        {
            if (!Bad)
            {
                Instantiate(EatAudio, transform.position, transform.rotation);
                BirdShoot.QQpower = BirdShoot.QQFullpower;
                nutImg.enabled = false;
                lightt.SetActive(false);
                BC.enabled = false;
                time = 3;
            }
            else
            {
                Instantiate(EatAudio, transform.position, transform.rotation);
                BirdShoot.QQpower = 0;
                nutImg.enabled = false;
                lightt.SetActive(false);
                BC.enabled = false;
                time = 3;
            }
        }
    }
}
