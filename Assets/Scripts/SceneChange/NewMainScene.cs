using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class NewMainScene : MonoBehaviour
{
    private Animator anim;
    public GameObject player;
    public GameObject playerImg;
    public GameObject QQ;
    public GameObject MainCam;
    public GameObject OpeningCam;
    public GameObject HeadUI;
    public GameObject PowerUI;
    public GameObject PUI;
    public GameObject Black;
    public GameObject UpArrow;
    private int nextpage;
    private bool opening;
    public static bool End;
    public static bool nextLevel;
    public Image L;
    public Image R;
    private Color transparent;

    public GameObject Space_Continue;
    private float continueTime;
    [Header("º©µe­¶¼Æ")]
    public GameObject comic1;
    public GameObject comic2;
    public GameObject comic3;
    public GameObject comic4;
    public GameObject COMIC;
    // Start is called before the first frame update
    void Start()
    {
        transparent = new Color(1, 1, 1, 0);
        Space_Continue.SetActive(false);
        continueTime = 0;

        if (!BacktoNewMainScene.backNewMainScene)
        {
            COMIC.SetActive(true);
            HeadUI.SetActive(false);
            PowerUI.SetActive(false);
            PUI.SetActive(false);
            OpeningCam.SetActive(true);
            MainCam.SetActive(false);
            comic1.SetActive(true);
            Invoke("One", 1);
        }
        else
        {
            OpeningCam.SetActive(false);
            MainCam.SetActive(true);
            COMIC.SetActive(false);
            End = true;
        }
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl.moveDirX != 0)
        {
            L.color= Color.Lerp(L.color, transparent, 0.05f);
            R.color = Color.Lerp(R.color, transparent, 0.05f);
        }

        if (!End)
        {
            PlayerControl.STOP = true;
        }

        Opening();

        if (TowerPoint.inTowerPoint)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                UpArrow.SetActive(false);
                player.SetActive(false);
                QQ.SetActive(false);
                HeadUI.SetActive(false);
                PowerUI.SetActive(false);
                PUI.SetActive(false);
                anim.SetTrigger("enter");
                Invoke("enterTower", 2.5f);
            }
        }

        if (BacktoNewMainScene.backNewMainScene)
        {
            HeadUI.SetActive(true);
            PowerUI.SetActive(true);
            PUI.SetActive(true);
            UpArrow.SetActive(true);
            player.transform.position = new Vector2(16.5f, -2.5f);
            QQ.transform.position = new Vector2(16.5f, -2.5f);
            MainCam.transform.position = new Vector2(16.5f, -2.5f);
            BacktoNewMainScene.backNewMainScene = false;
        }

        if (continueTime > 2f)
        {
            Space_Continue.SetActive(true);
        }
        else
        {
            Space_Continue.SetActive(false);
        }
    }

    void enterTower()
    {
        nextLevel = true;
        SceneManager.LoadScene("Stage1_Tutorial");
    }

    void One()
    {
        opening = true;
    }

    void Opening()
    {
        if (opening)
        {
            switch (nextpage)
            {
                case 0:
                    continueTime += Time.deltaTime;
                    break;
                case 1:
                    continueTime += Time.deltaTime;
                    comic1.SetActive(false);
                    comic2.SetActive(true);
                    break;
                case 2:
                    continueTime += Time.deltaTime;
                    comic2.SetActive(false);
                    comic3.SetActive(true);
                    break;
                case 3:
                    continueTime += Time.deltaTime;
                    comic3.SetActive(false);
                    comic4.SetActive(true);
                    break;
                case 4:
                    continueTime += Time.deltaTime;
                    comic1.SetActive(false);                    
                    anim.SetBool("end", true);
                    Invoke("OpeningEnd", 1.5f);
                    break;
                case 5:
                    break;
            }            
        }
    
        if (Input.GetKeyDown(KeyCode.Space)&& nextpage<5&& opening)
        {
            continueTime = 0;
            nextpage++;
        }
    }

    void OpeningEnd()
    {
        continueTime = 0;
        Black.SetActive(false);
        OpeningCam.SetActive(false);
        MainCam.SetActive(true);
        End = true;
        PlayerControl.STOP = false;
        HeadUI.SetActive(true);
        PowerUI.SetActive(true);
        PUI.SetActive(true);
        comic4.SetActive(false);  
    }
}
