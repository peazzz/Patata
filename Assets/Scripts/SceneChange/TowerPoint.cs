using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPoint : MonoBehaviour
{
    public static bool inTowerPoint;
    public Image Enter;
    public Text EnterText;
    public Image UpArrow;

    private Color _White;
    private Color transparent;

    // Start is called before the first frame update
    void Start()
    {
        _White = new Color(1, 1, 1, 1);
        transparent = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (inTowerPoint)
        {
            Enter.color = Color.Lerp(Enter.color, _White, 0.05f);
            EnterText.color = Color.Lerp(EnterText.color, _White, 0.05f);
            UpArrow.color = Color.Lerp(UpArrow.color, _White, 0.05f);
        }
        else
        {
            Enter.color = Color.Lerp(Enter.color, transparent, 0.05f);
            EnterText.color = Color.Lerp(EnterText.color, transparent, 0.05f);
            UpArrow.color = Color.Lerp(UpArrow.color, transparent, 0.05f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTowerPoint = true;           
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTowerPoint = false;           
        }
    }
}
