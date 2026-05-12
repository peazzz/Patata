using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

public class GodTalk2 : MonoBehaviour
{
    [SerializeField]
    ESMessageSystem msgSys;

    public static bool talk2;
    private int progress = 0;
    private bool isGameEnd = false;
    void Start()
    {
        // Define your customized keyword functions.
        msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction);
    }
    private void CustomizedFunction()
    {
        Debug.Log("Hi! This is called by CustomizedFunction!");
    }

    void Update()
    {
        // ----- Integration DEMO -----
        // Your own logic control.
        if (msgSys.isCompleted && !isGameEnd)
        {
            switch (progress)
            {
                case 0:
                    msgSys.ReadTextFromResource("GodTalk_2");
                    break;
                case 1:
                    isGameEnd = true;
                    break;
            }
            progress++;
        }

        if (!isGameEnd && Input.GetKeyDown(KeyCode.Space))
        {
            //Continue the messages, stoping by [w] or [lr] keywords.
            msgSys.Next();
        }

        if (isGameEnd)
        {
            isGameEnd = false;
            talk2 = true;
        }
    }
}
