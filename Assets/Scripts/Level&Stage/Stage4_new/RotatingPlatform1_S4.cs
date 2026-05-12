using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform1_S4 : MonoBehaviour
{
    public GameObject RP1;
    public Transform RP1_On_Pos;
    public Transform RP1_Off_Pos;
    public ParticleSystem Wind1PS;//ParticleSystem
    private bool isTouched;
    private float TouchTime;
    private bool On;
    private float OnTime;
    private Color PS_off;
    private Color PS_on;
    public AreaEffector2D AE2D;

    // Start is called before the first frame update
    void Start()
    {
        PS_off = new Color(0.97f, 0.87f, 0.71f, 0);
        PS_on = new Color(0.97f, 0.87f, 0.71f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched)
        {
            TouchTime += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TouchTime = 0.2f;
            }
        }
        else if (!isTouched)
        {
            TouchTime = 0;
        }

        if (TouchTime > 0.18f)
        {
            On = true;
            OnTime = 1f;
        }

        if (On)
        {
            if (OnTime > 0)
            {
                OnTime -= Time.deltaTime;
            }
            else if (OnTime <= 0)
            {
                On = false;
                OnTime = 0;
            }
            var main = Wind1PS.main;
            main.startColor= Color.Lerp(main.startColor.color, PS_off, 0.04f);
            RP1.transform.rotation = Quaternion.Lerp(RP1.transform.rotation, RP1_On_Pos.rotation, 0.04f);
            AE2D.forceMagnitude = Mathf.Lerp(AE2D.forceMagnitude , 0 , 0.04f);
        }
        else
        {
            var main = Wind1PS.main;
            main.startColor = Color.Lerp(main.startColor.color, PS_on, 0.04f);
            RP1.transform.rotation = Quaternion.Lerp(RP1.transform.rotation, RP1_Off_Pos.rotation, 0.04f);
            AE2D.forceMagnitude = Mathf.Lerp(AE2D.forceMagnitude, 50, 0.04f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouched = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTouched = false;
        }
    }
}
