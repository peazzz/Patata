using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class END : MonoBehaviour
{
    public static bool isEND;

    public GameObject PlayerUI;
    public GameObject LOGO;
    public GameObject BackGround;
    public GameObject Re;
    private float TBCtime;
    public Text TimeText;
    private Color _White;
    private Color transparent;

    // Start is called before the first frame update
    void Start()
    {
        isEND = false;
        _White = new Color(1, 1, 1, 1);
        transparent = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEND)
        {
            DisplayTime(GameStop.timer);
            TimeText.color = _White;
            PlayerUI.SetActive(false);
            LOGO.SetActive(true);
            BackGround.SetActive(true);

            if (TBCtime >= 2)
            {
                Re.SetActive(true);
            }
            else if (TBCtime < 2)
            {
                TBCtime += Time.deltaTime;
            }
        }
        else
        {
            TimeText.color = transparent;
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isEND = true;
            nextFinalStage.lv4 = false;
        }
    }
}
