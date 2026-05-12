using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;
	public float z;
	public float smoothing;
	public Vector2 minpos;
	public Vector2 maxpos;

	void FixedUpdate()
	{
		
		if (player != null)
		{
			if (transform.position != player.position)
			{
				Vector3 cameraPos = new Vector3(player.position.x, player.position.y + 0.2f, z);
				cameraPos.x = Mathf.Clamp(cameraPos.x, minpos.x, maxpos.x);
				cameraPos.y = Mathf.Clamp(cameraPos.y, minpos.y, maxpos.y);
				transform.position = Vector3.Lerp(transform.position, cameraPos, smoothing);
			}
		}
	}

	public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
	{
		minpos = minPos;
		maxpos = maxPos;
	}
}
