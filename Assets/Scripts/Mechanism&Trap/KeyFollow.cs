using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFollow : MonoBehaviour
{
    public GameObject player;
    public List<Vector3> positionList;
    public GameObject KeyAudio;
    private BoxCollider2D bc;
    private bool Follow;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bc=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Follow)
        {
            anim.enabled = false;
            positionList.Add(player.transform.position);
            if (positionList.Count > 15)
            {
                positionList.RemoveAt(0);
                transform.position = Vector3.Lerp(transform.position, positionList[0], 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            bc.enabled = false;
            Follow = true;
            Instantiate(KeyAudio, transform.position, transform.rotation);
        }
    }
}
