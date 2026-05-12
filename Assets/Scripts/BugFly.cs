using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugFly : MonoBehaviour
{
    public float speed = 0.1f;
    public float wallCheckRadius = 0.1f;
    public GameObject Flyparticle;
    private Rigidbody2D rb2d;
    private float effecttime;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (effecttime >= 0.15f)
        {
            Instantiate(Flyparticle, transform.position, new Quaternion(0, 180, 0, 0));
            effecttime = 0;
        }
        else
        {
            effecttime += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {    
        Vector2 direction = Random.insideUnitCircle.normalized;
        Vector2 force = direction * speed;
        rb2d.AddForce(force);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, wallCheckRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Ground"))
            {
                Vector2 wallNormal = collider.transform.up;
                Vector2 reflectedForce = Vector2.Reflect(force, wallNormal);
                rb2d.AddForce(reflectedForce);
            }
        }

        if (rb2d.velocity.x < -0.1f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else 
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
    }
}
