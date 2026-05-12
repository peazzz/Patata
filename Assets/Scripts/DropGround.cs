using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGround : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool isDrapping;
    private float dropTime;
    private Vector3 originalPos;
    private bool isShaking;

    public float shakeSpeed = 20f;
    public float shakeAmount = 0.3f;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb2d.bodyType = RigidbodyType2D.Static;
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrapping)
        {
            if (!isShaking)
            {
                shake();
            }
            dropTime += Time.deltaTime;

            if (dropTime > 1 && dropTime < 5)
            {
                isShaking = true;
                rb2d.bodyType = RigidbodyType2D.Dynamic;
            }
            else if (dropTime > 5 )
            {
                isShaking = false;
                rb2d.bodyType = RigidbodyType2D.Static;
                transform.position = originalPos;
                dropTime = 0;
                isDrapping = false;
            }
        }
    }

    void shake()
    {
        float x = Mathf.PerlinNoise(Time.time * shakeSpeed, 0f) * shakeAmount - (shakeAmount / 2f);
        transform.position = new Vector3(originalPos.x + x, transform.position.y, originalPos.z);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {            
            isDrapping = true;           
        }
    }
}
