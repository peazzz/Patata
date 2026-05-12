using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCharacter : MonoBehaviour
{
    public static bool two_player;

    private CircleCollider2D QQcc;
    public static bool switchCharacter;
    public GameObject playerHeadUI;
    public GameObject QQHeadUI;
    public Text P;


    // Start is called before the first frame update
    void Start()
    {
        QQcc= GameObject.FindGameObjectWithTag("QQ").GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnePlayer();
        TwoPlayer();

        if (two_player)
        {
            P.text = "2P";
        }
        else
        {
            P.text = "1P";
        }
    }

    void OnePlayer()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (two_player)
            {
                two_player = false;
                BirdFollow.isLast = false;
                BirdShoot.birdS = false;
                BirdShoot.MouseInput0 = false;
                BirdFollow.inPlayerBody = false;
            }
        }

        if (!nextFinalStage.lv4 && !two_player)
        {
            if (!BirdFollow.inGround && (!PlayerControl.isHead || !BirdFollow.sleep) && !BirdShoot.birdZ)
            {
                if (Input.GetButtonDown("Change"))
                {
                    if (switchCharacter)
                    {
                        switchCharacter = false;
                        BirdShoot.birdS = true;                        
                    }
                    else if (!switchCharacter)
                    {
                        switchCharacter = true;
                        BirdShoot.birdS = false;
                        QQcc.isTrigger = false;
                    }
                }
            }
        }       

        if (switchCharacter)
        {
            BirdShoot.canDash = false;
            BirdShoot.touchbird = false;
            QQHeadUI.SetActive(true);
            playerHeadUI.SetActive(false);
        }
        else if (!switchCharacter)
        {
            QQHeadUI.SetActive(false);
            playerHeadUI.SetActive(true);
        }

    }

    void TwoPlayer()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (!two_player)
            {
                two_player = true;            
            }
            else
            {
                two_player = false;
                BirdFollow.isLast = false;
                BirdShoot.MouseInput0 = false;
                BirdFollow.inPlayerBody = false;
                BirdShoot.birdS = false;
            }
        }

        if (two_player)
        {
            switchCharacter = false;
        }
    }
}
