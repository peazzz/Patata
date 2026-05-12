using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodTalk2_S1 : MonoBehaviour
{
    public static bool GT2_S1;
    public Text Godtext;
    private Animator anim;
    private bool Continue;
    public static bool TalkEnd;
    private int nextMessage;
    private bool loopOnce;//讓switch只執行一次
    public GameObject Space_Continue;
    private float continueTime;

    public GameObject GodTalkAudio;

    private bool textOver;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        Space_Continue.SetActive(false);
        continueTime = 0;
        TalkEnd = false;
        textOver = false;
        loopOnce = false;
        anim = GetComponent<Animator>();
        nextMessage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GT2_S1)
        {
            anim.SetBool("show",true);
            Invoke("Message", 0.5f);
            GT2_S1 = false;
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
                        StartCoroutine(TypeWriterText(Godtext, "咦?", 0.1f));
                        break;
                    case 1:
                        textOver = false;
                        StartCoroutine(TypeWriterText(Godtext, "...", 0.1f));
                        break;
                    case 2:
                        textOver = false;
                        StartCoroutine(TypeWriterText(Godtext, ".........", 0.1f));
                        break;
                    case 3:
                        textOver = false;
                        StartCoroutine(TypeWriterText(Godtext, "那個...", 0.1f));
                        break;
                    case 4:
                        textOver = false;
                        StartCoroutine(TypeWriterText(Godtext, "我在上面等你囉", 0.1f));
                        break;
                    case 5:
                        anim.SetBool("show",false);
                        Continue = false;
                        TalkEnd = true;
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 5 && textOver)
            {
                continueTime = 0;
                loopOnce = false;
                nextMessage++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 5 && !textOver)
            {
                textOver = true;
            }
        }
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
