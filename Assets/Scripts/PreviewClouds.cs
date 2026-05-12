using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewClouds : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * 1f));

        if (transform.position.x < -85)
        {
            Destroy(gameObject);
        }
    }
}
