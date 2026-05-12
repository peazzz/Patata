using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SandSea : MonoBehaviour
{
    public Volume globalVolume;
    private FilmGrain filmGrain;
    private Vector3 OriginalPos;
    private Vector3 SecondPos;
    private Vector3 ThirdPos;

    public static bool ismoving;

    // Start is called before the first frame update
    void Start()
    {
        OriginalPos = new Vector3(0,-15,0);
        SecondPos = new Vector3(0, 25, 0);
        ThirdPos = new Vector3(0, 65, 0);
        globalVolume.profile.TryGet(out filmGrain);
    }

    void Update()
    {
        if (PlayerControl.Dead && Stage4_new.Action2)
        {
            Stage4_new.Action2 = false;
            Invoke("OP", 1);           
        }

        if (Input.anyKeyDown)
        {
            ismoving = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Stage4_new.Action2 && !AreaCheck.Second && !AreaCheck.Third)
        {
            if (transform.position.y >= -15f)
            {
                transform.position = new Vector3(transform.position.x, -15, transform.position.z);
            }
        }
        else if (AreaCheck.Second && !ismoving && !AreaCheck.Third)
        {
            if (transform.position.y >= 25f)
            {
                transform.position = new Vector3(transform.position.x, 25, transform.position.z);
            }
        }
        else if (!AreaCheck.Second && !ismoving && AreaCheck.Third)
        {
            if (transform.position.y >= 65f)
            {
                transform.position = new Vector3(transform.position.x, 65, transform.position.z);
            }
        }

        transform.position = new Vector2(transform.position.x, transform.position.y + 0.045f);

        if (Stage4_new.Event)
        {
            GVFG();
        }
    }

    void OP()
    {
        if (AreaCheck.Second)
        {
            transform.position = Vector3.Lerp(transform.position, SecondPos, 0.1f);
        }
        else if (AreaCheck.Third)
        {
            transform.position = Vector3.Lerp(transform.position, ThirdPos, 0.1f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, OriginalPos, 0.1f);
        }
    }

    void GVFG()
    {
        filmGrain.intensity.Override(1f);
    }
}
