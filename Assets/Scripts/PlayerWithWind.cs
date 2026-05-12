using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWithWind : MonoBehaviour
{
    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (Stage4_new.Action)
		{
			if (BirdShoot.birdZ)
			{
				if (Input.GetKey(KeyCode.UpArrow))
				{
					playerRb.velocity = new Vector2(playerRb.velocity.x, 5f);
				}
				else if (Input.GetKey(KeyCode.DownArrow))
				{
					playerRb.velocity = new Vector2(playerRb.velocity.x, -1f);
				}
				else
				{
					playerRb.velocity = new Vector2(playerRb.velocity.x, 3f);
				}
			}
			//else if (!BirdShoot.birdZ)
			//{
			//	playerRb.velocity = new Vector2(playerRb.velocity.x, -5f);
			//}
		}
	}
}
