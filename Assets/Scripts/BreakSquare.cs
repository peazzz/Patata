using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakSquare : MonoBehaviour
{
    public GameObject BreakSquare1;
    public GameObject BreakSquare2;
    public Transform br1_1;
    public Transform br1_2;
    public Transform br1_3;
    public Transform br2_1;
    public Transform br2_2;
    public Transform br2_3;
    public BoxCollider2D bc;
    private bool break1;
    private Animator anim;
    public GameObject Dusteffect;
    public GameObject Breakeffect;
    // Start is called before the first frame update
    void Start()
    {
        break1 = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (BirdShoot.isDashing && !break1)
            {
                BreakSquare1.SetActive(false);
                BreakSquare2.SetActive(true);
                Instantiate(Dusteffect, br1_1.transform.position, Quaternion.identity);
                Instantiate(Dusteffect, br1_2.transform.position, Quaternion.identity);
                Instantiate(Dusteffect, br1_3.transform.position, Quaternion.identity);
                break1 = true;
            }
            else if (BirdShoot.isDashing && break1)
            {
                Instantiate(Breakeffect, br2_1.transform.position, Quaternion.identity);
                Instantiate(Breakeffect, br2_2.transform.position, Quaternion.identity);
                Instantiate(Breakeffect, br2_3.transform.position, Quaternion.identity);
                BreakSquare2.SetActive(false);
                bc.enabled = false;
                anim.SetTrigger("open");
            }
        }
    }
}
