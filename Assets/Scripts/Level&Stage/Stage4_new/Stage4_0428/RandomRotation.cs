using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public Transform player;
    public bool playerstand;
    private bool isRotated;
    private bool isRotated2;
    public float torque = 20f;
    private Rigidbody2D rb;
    public BoxCollider2D touchGround;
    private Vector3 OriginalPos;
    private float randomTorque;
    private float randomGS;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        OriginalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Stage4_new.Event)
        {
            if (!isRotated && !playerstand)
            {
                float randomTorque = Random.Range(-torque, torque);
                rb.AddTorque(randomTorque);
                isRotated = true;
            }

            if (Stage4_new.Action && player.position.y > 5)
            {
                Stage4_new.Action2 = true;
            }

            if (playerstand && !isRotated2 && Stage4_new.Action2)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                randomTorque = Random.Range(-torque, torque);
                randomGS = Random.Range(-0.2f, -1);               
                rb.AddTorque(randomTorque);
                rb.gravityScale = randomGS;
                isRotated2 = true;
                if (touchGround != null)
                {
                    touchGround.enabled = false;
                }                
            }          

            if (PlayerControl.Dead && !Stage4_new.Action2)
            {
                randomTorque = 0;
                randomGS = 0;
                if (playerstand)
                {
                    isRotated2 = false;                   
                    transform.position = OriginalPos;
                    transform.rotation = Quaternion.identity;
                    rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                    rb.gravityScale = 0;
                }
                
                if (touchGround != null)
                {
                    touchGround.enabled = true;
                }
            }
        }       
    }
}
