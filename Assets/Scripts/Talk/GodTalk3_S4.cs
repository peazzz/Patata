using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

public class GodTalk3_S4 : MonoBehaviour
{
    [SerializeField]
    ESMessageSystem msgSys;

    private bool istalked;
    private bool nexttalk;
    public static bool talk3;
    private int progress = 0;
    private bool isGameEnd = false;
    void Start()
    {
        talk3 = false;
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
                    msgSys.ReadTextFromResource("GodTalk_3_S4");
                    break;

                case 1:
                    msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");

                    if (!nexttalk)
                    {
                        msgSys.SetupButtonItem("DefaultButtonItemPrefab", "不想", () =>
                        {
                            msgSys.Resume();
                            msgSys.RemoveButtonUI();
                            msgSys.ReadTextFromResource("GodTalk_3_S4_1");
                            istalked = false;
                            nexttalk = true;
                            Debug.Log("A");
                            progress = 1;
                        });
                        msgSys.SetupButtonItem("DefaultButtonItemPrefab", "想你了", () =>
                        {
                            msgSys.Resume();
                            msgSys.RemoveButtonUI();
                            msgSys.ReadTextFromResource("GodTalk_3_S4_2");
                            istalked = false;
                            nexttalk = true;
                            Debug.Log("B");
                            progress = 1;
                        });
                    }
                    else
                    {                        
                        istalked = true;
                        Debug.Log("C");
                    }

                    break;

                case 2:

                    if (istalked)
                    {
                        Debug.Log("D");
                        isGameEnd = true;
                    }
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
            talk3 = true;
            isGameEnd = false;
            Debug.Log(talk3);
        }
    }
}
