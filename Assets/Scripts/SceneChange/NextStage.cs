using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class NextStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NextStage1_1.lv1)//lv1已完成關卡
        {
            Invoke("Level1_2", 3.2f);
        }
        else if (NextStage1_2.lv2)//lv2已完成關卡
        {
            Invoke("Level1_3", 3.2f);
        }
        else if (NextStage1_3.lv3)//lv3已完成關卡
        {
            Invoke("Level2_1", 3.2f);
        }
    }

    void Level1_2()
    {
        SceneManager.LoadScene("Stage2");
    }

    void Level1_3()
    {
        SceneManager.LoadScene("Stage3_new");
    }

    void Level2_1()
    {
        SceneManager.LoadScene("Stage4");
    }
}
