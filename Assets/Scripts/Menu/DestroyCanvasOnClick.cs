using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyCanvasOnClick : MonoBehaviour
{
    //要移除的canvas
    public GameObject canvas;
    void Start()
    {
        //按下按鈕後，呼叫ClickEvent()
        GetComponent<Button>().onClick.AddListener(() => {
            ClickEvent();
        });
    }

    void ClickEvent()
    {
        //刪掉canvas
        Destroy(canvas);
    }
}