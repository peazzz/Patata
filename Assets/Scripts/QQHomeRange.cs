using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QQHomeRange : MonoBehaviour
{
    public Transform Cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!AreaCheck.Follow)
        {
            AreaRange();
        }
        else if (AreaCheck.Follow)
        {
            FollowRange();
        }
    }

    void AreaRange()
    {
        if (SwitchCharacter.switchCharacter || SwitchCharacter.two_player)
        {
            if (AreaCheck.A)
            {
                if (transform.position.x >= -4.45f)
                {
                    transform.position = new Vector3(-4.45f, transform.position.y, transform.position.z);
                }
            }
            else if (AreaCheck.B)
            {
                if (transform.position.x <= -3.45f)
                {
                    transform.position = new Vector3(-3.45f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x >= 25.55f)
                {
                    transform.position = new Vector3(25.55f, transform.position.y, transform.position.z);
                }
            }
            else if (AreaCheck.C)
            {
                if (transform.position.x <= 26.55f)
                {
                    transform.position = new Vector3(26.55f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x >= 55.55f)
                {
                    transform.position = new Vector3(55.55f, transform.position.y, transform.position.z);
                }
            }
            else if (AreaCheck.D)
            {
                if (transform.position.x <= 56.55f)
                {
                    transform.position = new Vector3(56.55f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x >= 85.55f)
                {
                    transform.position = new Vector3(85.55f, transform.position.y, transform.position.z);
                }
            }
            else if (AreaCheck.E)
            {
                if (transform.position.x <= 86.55f)
                {
                    transform.position = new Vector3(86.55f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x >= 115.55f)
                {
                    transform.position = new Vector3(115.55f, transform.position.y, transform.position.z);
                }
            }

            if (AreaCheck.Half)
            {
                if (transform.position.y <= 3f)
                {
                    transform.position = new Vector3(transform.position.x, 3f, transform.position.z);
                }
                else if (transform.position.y >= 19f)
                {
                    transform.position = new Vector3(transform.position.x, 19f, transform.position.z);
                }
            }
            else if (!AreaCheck.Second && !AreaCheck.Half && !AreaCheck.Third)
            {
                if (transform.position.y <= -3f)
                {
                    transform.position = new Vector3(transform.position.x, -3f, transform.position.z);
                }
                else if (transform.position.y >= 13f)
                {
                    transform.position = new Vector3(transform.position.x, 13f, transform.position.z);
                }
            }
            else if (AreaCheck.Second)
            {
                if (transform.position.y <= 13f)
                {
                    transform.position = new Vector3(transform.position.x, 13f, transform.position.z);
                }
                else if (transform.position.y >= 29f)
                {
                    transform.position = new Vector3(transform.position.x, 29f, transform.position.z);
                }
            }
            else if (AreaCheck.Third)
            {
                if (transform.position.y <= 29f)
                {
                    transform.position = new Vector3(transform.position.x, 29f, transform.position.z);
                }
                else if (transform.position.y >= 45f)
                {
                    transform.position = new Vector3(transform.position.x, 45f, transform.position.z);
                }
            }
            else if (AreaCheck.Forth)
            {
                if (transform.position.y <= 45f)
                {
                    transform.position = new Vector3(transform.position.x, 45f, transform.position.z);
                }
                else if (transform.position.y >= 61f)
                {
                    transform.position = new Vector3(transform.position.x, 61f, transform.position.z);
                }
            }
            else if (AreaCheck.Fifth)
            {
                if (transform.position.y <= 61f)
                {
                    transform.position = new Vector3(transform.position.x, 61f, transform.position.z);
                }
                else if (transform.position.y >= 77f)
                {
                    transform.position = new Vector3(transform.position.x, 77f, transform.position.z);
                }
            }
        }
    }

    void FollowRange()
    {
        if ((BirdShoot.birdS || CameraFollow2.inPlayer) && !BirdShoot.birdX)//CameraFollow2.inPlayer有包括角色死亡時
        {
            if (transform.position.x <= (Cam.position.x - 14f))
            {
                transform.position = new Vector3(Cam.position.x - 14f, transform.position.y, transform.position.z);
            }
            else if (transform.position.x >= (Cam.position.x + 14f))
            {
                transform.position = new Vector3(Cam.position.x + 14f, transform.position.y, transform.position.z);
            }

            if (transform.position.y <= (Cam.position.y - 8f))
            {
                transform.position = new Vector3(transform.position.x, Cam.position.y - 8f, transform.position.z);
            }
            else if (transform.position.y >= (Cam.position.y + 8f))
            {
                transform.position = new Vector3(transform.position.x, Cam.position.y + 8f, transform.position.z);
            }
        }
    }
}
