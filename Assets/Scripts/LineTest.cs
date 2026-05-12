using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTest : MonoBehaviour
{
    private LineRenderer lr;
    public GameObject QQTongue;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawLinee();
    }

    void DrawLinee()
    {
        lr.SetPosition(0, QQTongue.transform.position);
        lr.SetPosition(1, player.transform.position);
    }
}
