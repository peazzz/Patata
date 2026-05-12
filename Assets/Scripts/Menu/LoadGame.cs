using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGame : MonoBehaviour
{

    public void Loading()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
