using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastText : MonoBehaviour
{
    public static bool isLast;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnBecameVisible()
    {
        Debug.Log("aaaaa");
        isLast = true;
    }
}
