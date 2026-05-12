using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public bool Npc1;
    public bool Npc2;
    public bool Npc3;
    public bool Npc4;
    public bool Npc5;

    public Animator anim;


    public Text NPCtext;
    public GameObject TalkAudio;
    private int nextMessage;
    private int i;
    private bool isTalking;
    private bool loopOnce;
    private bool textOver;
    private bool TalkArea;
    public GameObject talkHint;
    // Start is called before the first frame update
    void Start()
    {
        talkHint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (TalkArea && !SwitchCharacter.switchCharacter)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                TalkArea = false;
                PlayerControl.STOP = true;
                anim.SetBool("show", true);
                isTalking = true;
            }
        }

        if (isTalking)
        {
            PlayerControl.STOP = true;
            isTalk();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {      
        if (other.gameObject.tag == "Player")
        {
            if (!SwitchCharacter.switchCharacter)
            {
                talkHint.SetActive(true);
            }
            TalkArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!SwitchCharacter.switchCharacter)
            {
                talkHint.SetActive(false);
            }
            TalkArea = false;
        }
    }

    void isTalk()
    {
        if (Npc1)
        {
            if (!loopOnce)
            {
                switch (nextMessage)
                {
                    case 0:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "...", 0.1f));
                        break;
                    case 1:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "有什麼事嗎?", 0.1f));
                        break;
                    case 2:
                        NPCtext.text = "";
                        anim.SetBool("show", false);
                        isTalking = false;
                        PlayerControl.STOP = false;
                        TalkArea = true;
                        nextMessage = 0;
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 2 && textOver)
            {
                loopOnce = false;
                nextMessage++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 2 && !textOver)
            {
                textOver = true;
            }
        }
        else if (Npc2)
        {
            if (!loopOnce)
            {
                switch (nextMessage)
                {
                    case 0:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "你知道嗎", 0.1f));
                        break;
                    case 1:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "我的生日是4月24號", 0.1f));
                        break;
                    case 2:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "這邊有4個人也是4/24出生的哦 ㄎㄎ", 0.1f));
                        break;
                    case 3:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "加上你的話那就是五個人了", 0.1f));
                        break;
                    case 4:
                        NPCtext.text = "";
                        anim.SetBool("show", false);
                        isTalking = false;
                        PlayerControl.STOP = false;
                        TalkArea = true;
                        nextMessage = 0;
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 4 && textOver)
            {
                loopOnce = false;
                nextMessage++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 4 && !textOver)
            {
                textOver = true;
            }
        }
        else if (Npc3)
        {
            if (!loopOnce)
            {
                switch (nextMessage)
                {
                    case 0:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "其實我原本是來收集鳥蛋的", 0.1f));
                        break;
                    case 1:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "聽說被認可的人才能進入那座塔...", 0.1f));
                        break;
                    case 2:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "我花了1年的時間還是進入不了那座塔", 0.1f));
                        break;
                    case 3:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "可悲阿", 0.1f));
                        break;
                    case 4:
                        NPCtext.text = "";
                        anim.SetBool("show", false);
                        isTalking = false;
                        PlayerControl.STOP = false;
                        TalkArea = true;
                        nextMessage = 0;
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 4 && textOver)
            {
                loopOnce = false;
                nextMessage++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 4 && !textOver)
            {
                textOver = true;
            }
        }
        else if (Npc4)
        {
            if (!loopOnce)
            {
                switch (nextMessage)
                {
                    case 0:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "雖然我站在商店前面", 0.1f));
                        break;
                    case 1:
                        textOver = false;
                        StartCoroutine(TypeWriterText(NPCtext, "但你找錯人了，我並不是商人", 0.1f));
                        break;
                    case 2:
                        NPCtext.text = "";
                        anim.SetBool("show", false);
                        isTalking = false;
                        PlayerControl.STOP = false;
                        TalkArea = true;
                        nextMessage = 0;
                        break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 3 && textOver)
            {
                loopOnce = false;
                nextMessage++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && nextMessage < 3 && !textOver)
            {
                textOver = true;
            }
        }
    }

    IEnumerator TypeWriterText(Text npctext, string str, float interval)
    {
        loopOnce = true;
        i = 0;
        while (i <= str.Length)
        {
            if (textOver)
            {
                i = str.Length;
            }
            Instantiate(TalkAudio, transform.position, transform.rotation);
            textOver = false;
            npctext.text = str.Substring(0, i++);
            yield return new WaitForSeconds(interval);
        }
        textOver = true;
    }
}
