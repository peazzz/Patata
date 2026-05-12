using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCheck : MonoBehaviour
{
    public static bool A;
    public static bool B;
    public static bool C;
    public static bool D;
    public static bool E;
    public static bool Half;
    public static bool Second;
    public static bool Third;
    public static bool Forth;   
    public static bool Fifth;

    public static bool Follow;

    void Awake()
    {

    }

    void Start()
    {
        Follow = false;
        Half = false;
        Second = false;
        Third = false;
        if (!NextStage1_3.lv3)
        {
            B = true;
        }
    }

    void Update()
    {
        if (!PlayerControl.Moving && !Follow)
        {
            if (!NextStage1_3.lv3)
            {
                if (A)
                {
                    if (transform.position.x >= -4.45f)
                    {
                        transform.position = new Vector3(-4.45f, transform.position.y, transform.position.z);
                    }
                }
                else if (B)
                {
                    if (transform.position.x <= -3.45f)
                    {
                        transform.position = new Vector3(-3.45f, transform.position.y, transform.position.z);
                    }
                    else if (transform.position.x >= 25.55f)
                    {
                        transform.position = new Vector3(25.55f, transform.position.y, transform.position.z);
                    }
                }
            }
            else if(NextStage1_3.lv3)
            {
                if (A)
                {
                    if (transform.position.x >= -13.5f)
                    {
                        transform.position = new Vector3(-13.5f, transform.position.y, transform.position.z);
                    }
                }
                else if (B)
                {
                    if (transform.position.x <= -13f)
                    {
                        transform.position = new Vector3(-13f, transform.position.y, transform.position.z);
                    }
                }
            }
            else if (C)
            {
                if (transform.position.x <= 26.55f)
                {
                    transform.position = new Vector3(26.55f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x >= 55.55f)
                {
                    transform.position = new Vector3(55.55f, transform.position.y, transform.position.z);
                }
            }
            else if (D)
            {
                if (transform.position.x <= 56.55f)
                {
                    transform.position = new Vector3(56.55f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x >= 85.55f)
                {
                    transform.position = new Vector3(85.55f, transform.position.y, transform.position.z);
                }
            }
            else if (E)
            {
                if (transform.position.x <= 86.55f)
                {
                    transform.position = new Vector3(86.55f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x >= 115.55f)
                {
                    transform.position = new Vector3(115.55f, transform.position.y, transform.position.z);
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "follow")
        {
            Follow = true;
        }

        if (other.gameObject.tag == "A")
        {
            BirdFollowCheck.QQFollow = true;
            BirdShoot.birdS = false;
            BirdShoot.touchbird = false;
            A = true;
            B = false;
            C = false;
            D = false;
            E = false;
        }
        else if (other.gameObject.tag == "B")
        {
            BirdFollowCheck.QQFollow = true;
            BirdShoot.birdS = false;
            BirdShoot.touchbird = false;
            A = false;
            B = true;
            C = false;
            D = false;
            E = false;
        }
        else if (other.gameObject.tag == "C")
        {
            BirdFollowCheck.QQFollow = true;
            BirdShoot.birdS = false;
            BirdShoot.touchbird = false;
            A = false;
            B = false;
            C = true;
            D = false;
            E = false;
        }
        else if (other.gameObject.tag == "D")
        {
            BirdFollowCheck.QQFollow = true;
            BirdShoot.birdS = false;
            BirdShoot.touchbird = false;
            A = false;
            B = false;
            C = false;
            D = true;
            E = false;
        }
        else if (other.gameObject.tag == "E")
        {
            BirdFollowCheck.QQFollow = true;
            BirdShoot.birdS = false;
            BirdShoot.touchbird = false;
            A = false;
            B = false;
            C = false;
            D = false;
            E = true;
        }

        if (!Half)
        {
            if (other.gameObject.tag == "Half")
            {
                Half = true;
            }
        }

        if (!Second)
        {
            if (other.gameObject.tag == "Second")//加
            {
                if (!Follow && !Half)
                {
                    BirdFollowCheck.QQFollow = true;
                    BirdShoot.birdS = false;
                    BirdShoot.touchbird = false;
                    GameObject.Find("QQfin").GetComponent<BirdFollow>().BirdReturn();
                }               
                Second = true;
                Third = false;
                Forth = false;
            }
        }

        if (Second)
        {
            if (other.gameObject.tag == "SecondX")//加
            {
                if (!Follow && !Half)
                {
                    BirdFollowCheck.QQFollow = true;
                    BirdShoot.birdS = false;
                    BirdShoot.touchbird = false;
                    GameObject.Find("QQfin").GetComponent<BirdFollow>().BirdReturn();
                }                
                Second = false;
                Third = false;
                Forth = false;
            }
        }

        if (!Third)
        {
            if (other.gameObject.tag == "Third")//加
            {
                if (!Follow && !Half)
                {
                    BirdFollowCheck.QQFollow = true;
                    BirdShoot.birdS = false;
                    BirdShoot.touchbird = false;
                    GameObject.Find("QQfin").GetComponent<BirdFollow>().BirdReturn();
                }               
                Third = true;
                Second = false;
                Forth = false;
            }
        }

        if (!Forth)
        {
            if (other.gameObject.tag == "Forth")//加
            {
                if (!Follow && !Half)
                {
                    BirdFollowCheck.QQFollow = true;
                    BirdShoot.birdS = false;
                    BirdShoot.touchbird = false;
                    GameObject.Find("QQfin").GetComponent<BirdFollow>().BirdReturn();
                }               
                Forth = true;
                Third = false;
                Second = false;
            }
        }

        if (!Fifth)
        {
            if (other.gameObject.tag == "Fifth")//加
            {
                if (!Follow && !Half)
                {
                    BirdFollowCheck.QQFollow = true;
                    BirdShoot.birdS = false;
                    BirdShoot.touchbird = false;
                    GameObject.Find("QQfin").GetComponent<BirdFollow>().BirdReturn();
                }                
                Fifth = true;
                Third = false;
                Forth = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (Half)
        {
            if (other.gameObject.tag == "Half")
            {
                Half = false;
            }
        }

        if (Follow)
        {
            if (other.gameObject.tag == "follow")
            {
                Follow = false;
            }
        }
    }

}
