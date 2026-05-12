using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HideGround1_S3 : MonoBehaviour
{
    public Tilemap HideGround1;
    private bool isTounch;

    void Start()
    {
        isTounch = false;
    }

    void Update()
    {
        if (isTounch)
        {
            Color FadeOut = new Color(1, 1, 1, 0);
            HideGround1.color = Color.Lerp(HideGround1.color, FadeOut, 0.1f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "QQ")
        {
            isTounch = true;
        }
    }
}
