using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodTalk1_S4 : MonoBehaviour
{
    public static bool GT1_S4;
    public Text Godtext;
    private Animator anim;
    private bool Continue;
    public static bool TalkEnd;
    private int nextMessage;
    private bool loopOnce;//讓switch只執行一次
    public GameObject _Button1;
    public GameObject _Button2;
    public GameObject Space_Continue;
    private float continueTime;

    public GameObject GodTalkAudio;

    private bool textOver;
    private int i;

    private bool button1;
    private bool button2;

    // Start is called before the first frame update
    void Start()
    {
        Space_Continue.SetActive(false);
        continueTime = 0;
        button1 = false;
        button2 = false;
        TalkEnd = false;
        textOver = false;
        loopOnce = false;
        anim = GetComponent<Animator>();
        nextMessage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GT1_S4)
        {
            anim.SetBool("show", true);
            Invoke("Message", 0.5f);
            GT1_S4 = false;
        }

        Talk();

        if (continueTime > 2)
        {
            Space_Continue.SetActive(true);
        }
        else
        {
            Space_Continue.SetActive(false);
        }

        if (loopOnce)
        {
            continueTime += Time.deltaTime;
        }
    }

    void Message()
    {
        Continue = true;
    }

    void Talk()
    {
        if (Continue)
        {
            if (!loopOnce)
            {
                switch (nextMessage)
                {
                    case 0:
                        textOver = false;
                        StartCoroutine(TypeWriterText(Godtext, "你還想我嗎?", 0.1f));
                        break;
                    case 1:
                        anim.SetBool("player", true);
                        textOver = false;
                        StartCoroutine(TypeWriterText(Godtext, " ", 0.1f));
                        break;
                    case 2:
                        _Button1.SetActive(true);
                        _Button2.SetActive(true);
                        break;
                    case 3:
                        _Button1.SetActive(false);
                        _Button2.SetActive(false);
                        anim.SetBool("PtoG", true);
                        if (button1)
                        {
                            textOver = false;
                            StartCoroutine(TypeWriterText(Godtext, "你好變態哦", 0.1f));
                        }
                        else if (button2)
                        {
                            textOver = false;
                            StartCoroutine(TypeWriterText(Godtext, "嗚嗚...我好傷心", 0.1f));
                        }
                        break;
                    case 4:
                        textOver = false;
                        StartCoroutine(TypeWriterText(Godtext, "這裡快要被淹沒了", 0.1f));
                        Stage4_new.Event = true;
                        Stage4_new.CamShake = true;
                        break;
                    case 5:
                        textOver = false;
                        StartCoroutine(TypeWriterText(Godtext, "我要離開了", 0.1f));
                        break;
                    case 6:
                        textOver = false;
                        StartCoroutine(TypeWriterText(Godtext, "2ㄏ2ㄏ2ㄏ", 0.1f));
                        break;
                    case 7:
                        anim.SetBool("HwithP", true);
                        Continue = false;
                        TalkEnd = true;
                        Stage4_new.Action = true;
                        Stage4_new.CamShake = false;
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 7 && textOver)
            {
                continueTime = 0;
                loopOnce = false;
                nextMessage++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 7 && !textOver)
            {
                textOver = true;
            }
        }
    }

    public void Button1()
    {
        button1 = true;
        loopOnce = false;
        nextMessage++;
    }

    public void Button2()
    {
        button2 = true;
        loopOnce = false;
        nextMessage++;
    }

    IEnumerator TypeWriterText(Text godtext, string str, float interval)
    {
        loopOnce = true;
        i = 0;
        while (i <= str.Length)
        {
            if (textOver)
            {
                i = str.Length;
            }
            Instantiate(GodTalkAudio, transform.position, transform.rotation);
            textOver = false;
            godtext.text = str.Substring(0, i++);
            yield return new WaitForSeconds(interval);
        }
        textOver = true;
    }
}
