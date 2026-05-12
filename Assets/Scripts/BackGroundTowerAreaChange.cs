using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundTowerAreaChange : MonoBehaviour
{
    public GameObject TowerBG1;//B
    public GameObject TowerBG2;//C
    public GameObject TowerBG3;//D
    public GameObject TowerBG4;//A¡BE

    // Start is called before the first frame update
    void Start()
    {
        TowerBG1.SetActive(false);
        TowerBG2.SetActive(false);
        TowerBG3.SetActive(false);
        TowerBG4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (AreaCheck.A)
        {
            TowerBG4.SetActive(true);
            TowerBG1.SetActive(false);
        }
        else if (AreaCheck.B)
        {
            TowerBG1.SetActive(true);
            TowerBG2.SetActive(false);
            TowerBG4.SetActive(false);
        }
        else if (AreaCheck.C)
        {
            TowerBG2.SetActive(true);
            TowerBG1.SetActive(false);
            TowerBG3.SetActive(false);
        }
        else if (AreaCheck.D)
        {
            TowerBG3.SetActive(true);
            TowerBG2.SetActive(false);
            TowerBG4.SetActive(false);
        }
        else if (AreaCheck.E)
        {
            TowerBG4.SetActive(true);
            TowerBG3.SetActive(false);
        }
    }
}
