using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MovingBox : MonoBehaviour
{
    public bool up;
    public bool down;
    public bool right;
    public bool left;
    private bool soundplay;

    private bool istouched;
    private bool touchG;
    private bool getback;
    private bool run;


    public Light2D PointLight;

    [Header("­µ®Ä")]
    public AudioSource MovingAudio;
    public GameObject StopAudio;
    public GameObject ResetAudio;

    // Start is called before the first frame update
    void Start()
    {
        run = false;
        MovingAudio.enabled = false;
        istouched = false;
        soundplay = false;
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (touchG)
        {
            MovingAudio.pitch = Mathf.Lerp(MovingAudio.pitch, 3, 0.01f);
        }
        else
        {
            MovingAudio.pitch = 1;
        }

        if (getback)
        {
            Back();
        }

        if (istouched)
        {
            PointLight.color = new Color(0.5f, 0.9f, 0.5f, 1);
            PointLight.intensity = Mathf.Lerp(PointLight.intensity, 5, 0.05f);
            if(!soundplay)
            {
                
                MovingAudio.enabled = true;
                soundplay = true;
            }
            
            if (up)
            {
                UpMoving();
            }
            else if (down)
            {
                DownMoving();
            }
            else if (right)
            {
                RightMoving();
            }
            else if (left)
            {
                LeftMoving();
            }
        }
        //else
        //{
        //    PointLight.intensity = Mathf.Lerp(PointLight.intensity, 0, 0.05f);
        //}
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!run)
            {
                istouched = true;
                run = true;
            }
        }

        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Box")
        {
            if (run)
            {
                touchG = true;
                istouched = false;
                Invoke("stopBox", 1f);
            }
        }
    }

    void UpMoving()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.07f);
    }

    void DownMoving()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.07f);
    }

    void RightMoving()
    {
        transform.position = new Vector2(transform.position.x+0.07f, transform.position.y);
    }

    void LeftMoving()
    {
        transform.position = new Vector2(transform.position.x-0.07f, transform.position.y);
    }

    void stopBox()
    {
        touchG = false;
        MovingAudio.enabled = false;
        Instantiate(StopAudio, transform.position, transform.rotation);
        PointLight.color= new Color(0.9f, 0, 0, 1);

        Invoke("boolBack", 0.5f);
    }

    private void OnBecameInvisible()
    {
        if (run && !getback)
        {
            touchG = true;
            istouched = false;
            Invoke("stopBox", 1f);
        }
    }

    void boolBack()
    {
        getback = true;
    }

    void Back()
    {
        soundplay = false;

        if (up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.15f);
        }
        else if (down)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.15f);
        }
        else if (right)
        {
            transform.position = new Vector2(transform.position.x - 0.15f, transform.position.y);
        }
        else if (left)
        {
            transform.position = new Vector2(transform.position.x + 0.15f, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (getback)
        {
            if (other.gameObject.tag == "BoxStop")
            {
                Instantiate(ResetAudio, transform.position, transform.rotation);
                getback = false;
                run = false;
                PointLight.intensity = 0;
            }
        }

        if (!run)
        {
            if (other.gameObject.tag == "PlayerGrab")
            {
                istouched = true;
                run = true;
            }
        }
    }
}
