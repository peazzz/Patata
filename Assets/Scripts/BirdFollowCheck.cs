using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFollowCheck : MonoBehaviour
{
    public static bool QQFollow;
    private bool FollowCheck;

    // Start is called before the first frame update
    void Start()
    {
        QQFollow = true;
        FollowCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SwitchCharacter.switchCharacter)
        {
            if (!FollowCheck)
            {
                QQFollow = false;
                FollowCheck = true;
            }
        }
        else if (!SwitchCharacter.switchCharacter)
        {
            FollowCheck = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (SwitchCharacter.switchCharacter)
        {
            if (other.gameObject.tag == "Player")
            {
                QQFollow = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (SwitchCharacter.switchCharacter)
        {
            if (other.gameObject.tag == "Player")
            {
                QQFollow = false;
            }
        }
    }
}
