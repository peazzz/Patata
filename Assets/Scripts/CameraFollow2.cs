using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public GameObject cam;
    public Transform player;
    public float z;
    public float smoothing;
    public Vector2 minpos;
    public Vector2 maxpos;

    public static bool inPlayer;
    private Vector3 cameraPos;
    private Vector3 originalPosition;

    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;

    [Header("加畒夹")]
    public Transform a;
    public Transform b;
    public Transform c;
    public Transform d;
    public Transform e;
    [Header("加畒夹")]
    public Transform a_2;
    public Transform b_2;
    public Transform c_2;
    public Transform d_2;
    public Transform e_2;
    [Header("加畒夹")]
    public Transform a_3;
    public Transform b_3;
    public Transform c_3;
    public Transform d_3;
    public Transform e_3;
    [Header("加畒夹")]
    public Transform b_4;
    public Transform c_4;

    public Transform _H;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!AreaCheck.Follow && !PlayerControl.STOP && !Stage4_new.CamShake)
        {
            AreaCam();
        }
        else if (AreaCheck.Follow && !PlayerControl.STOP && !Stage4_new.CamShake)
        {
            FollowCam();
        }
        else if (Stage4_new.CamShake && PlayerControl.STOP)
        {
            StartCoroutine(Shake());
        }
    }

    void AreaCam()
    {
        if (cam != null)
        {
            if (AreaCheck.Half)
            {
                if (_H != null)
                {
                    transform.position = Vector3.Lerp(cam.transform.position, _H.position, 0.05f);
                }
            }
            else if (!AreaCheck.Second && !AreaCheck.Third && !AreaCheck.Forth)
            {
                if (AreaCheck.A)
                {
                    if (a != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, a.position, 0.05f);
                    }
                }
                else if (AreaCheck.B)
                {
                    if (b != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, b.position, 0.05f);
                    }
                }
                else if (AreaCheck.C)
                {
                    if (c != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, c.position, 0.05f);
                    }
                }
                else if (AreaCheck.D)
                {
                    if (d != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, d.position, 0.05f);
                    }
                }
                else if (AreaCheck.E)
                {
                    if (e != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, e.position, 0.05f);
                    }
                }
            }
            else if (AreaCheck.Second)
            {
                if (AreaCheck.A)
                {
                    if (a_2 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, a_2.position, 0.05f);
                    }
                }
                else if (AreaCheck.B)
                {
                    if (b_2 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, b_2.position, 0.05f);
                    }
                }
                else if (AreaCheck.C)
                {
                    if (c_2 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, c_2.position, 0.05f);
                    }
                }
                else if (AreaCheck.D)
                {
                    if (d_2 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, d_2.position, 0.05f);
                    }
                }
                else if (AreaCheck.E)
                {
                    if (e_2 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, e_2.position, 0.05f);
                    }
                }
            }
            else if (AreaCheck.Third)
            {
                if (AreaCheck.A)
                {
                    if (a_3 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, a_3.position, 0.05f);
                    }
                }
                else if (AreaCheck.B)
                {
                    if (b_3 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, b_3.position, 0.05f);
                    }
                }
                else if (AreaCheck.C)
                {
                    if (c_3 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, c_3.position, 0.05f);
                    }
                }
                else if (AreaCheck.D)
                {
                    if (d_3 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, d_3.position, 0.05f);
                    }
                }
                else if (AreaCheck.E)
                {
                    if (e_3 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, e_3.position, 0.05f);
                    }
                }
            }
            else if (AreaCheck.Forth)
            {
                if (AreaCheck.B)
                {
                    if (b_4 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, b_4.position, 0.05f);
                    }
                }
                else if (AreaCheck.C)
                {
                    if (c_4 != null)
                    {
                        transform.position = Vector3.Lerp(cam.transform.position, c_4.position, 0.05f);
                    }
                }
            }
            else
            {
                transform.position = Vector3.Lerp(cam.transform.position, player.position, 0.01f);
            }
        }
    }

    void FollowCam()
    {
        if (player != null)
        {
            if (transform.position != player.position)
            {
                cameraPos = new Vector3(player.position.x, player.position.y + 0.2f, z);
                cameraPos.x = Mathf.Clamp(cameraPos.x, minpos.x, maxpos.x);
                cameraPos.y = Mathf.Clamp(cameraPos.y, minpos.y, maxpos.y);
                transform.position = Vector3.Lerp(transform.position, cameraPos, smoothing);
            }

            float distance = Vector3.Distance(transform.position, cameraPos);
            if (distance < 0.1f && !PlayerControl.Dead)
            {
                inPlayer = true;
            }
            else
            {
                inPlayer = false;
            }
        }
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = cameraPos + new Vector3(x, y, 0);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = cameraPos;
    }

    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minpos = minPos;
        maxpos = maxPos;
    }
}
