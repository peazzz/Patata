using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPick : MonoBehaviour
{
    public static bool player1;
    public static bool player2;
    public GameObject Option1;
    public GameObject Option2;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControl.STOP = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void character1()
    {
        player1 = true;
        player2 = false;
        Option1.SetActive(false);
        Option2.SetActive(false);
        PlayerControl.STOP = false;
    }

    public void character2()
    {
        player1 = false;
        player2 = true;
        Option1.SetActive(false);
        Option2.SetActive(false);
        PlayerControl.STOP = false;
    }
}
