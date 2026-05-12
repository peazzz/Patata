using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFollow : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    public GameObject playerHead;
    private Rigidbody2D QQrb;
    private CircleCollider2D QQcc;
    private bool StopDistance;
    private float time;
    private float playerY;
    private float playerX;
    private float playerZ;
    private bool isFollow;
    private float touchGroundTime;
    public static bool sleep;
    public static bool Rest;
    private float RestTime;
    private Vector3 LastPos;
    public static bool isLast;
    private bool FirstClick;
    public static bool inPlayerBody;

    private Vector3 MousePosition;
    public static bool inGround;
    public GameObject QQsr;
    public GameObject QQsweat;
    [Header("­«¥ÍÂI")]
    public Transform DeadPosA;
    public Transform DeadPosB;
    public Transform DeadPosC;
    public Transform DeadPosD;
    public Transform DeadPosE;
    public Transform DeadPosA2;
    public Transform DeadPosB2;
    public Transform DeadPosC2;
    public Transform DeadPosD2;
    public Transform DeadPosE2;
    public Transform DeadPosA3;
    public Transform DeadPosB3;
    public Transform DeadPosC3;
    public Transform DeadPosD3;
    public Transform DeadPosE3;
    public Transform DeadPosB4;
    public Transform DeadPosC4;
    public Transform DeadPosB5;



    // Start is called before the first frame update
    void Start()
    {       
        QQrb = GetComponent<Rigidbody2D>();
        QQcc = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (!SwitchCharacter.two_player)
        {
            LastPos = transform.position;
            if (SwitchCharacter.switchCharacter)
            {
                QQrb.gravityScale = 0;
                anim.SetBool("moving", true);
                anim.SetBool("sleep", false);
                Rest = false;
                sleep = false;
                RestTime = 0;
                Control();
                //if (BirdShoot.birdS)
                //{
                //    QQrb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                //}
            }
            else if (!SwitchCharacter.switchCharacter)
            {
                if (BirdShoot.QQTime <= 0)
                {
                    QQrb.velocity = new Vector2(0, 0);
                }               
            }
        }
        else if (SwitchCharacter.two_player)
        {
            if (!BirdShoot.MouseInput0)
            {
                BirdShoot.birdZ = false;
            }

            if (!BirdShoot.birdS && !PlayerControl.STOP)
            {
                if (!isLast)
                {
                    Rest = false;
                    sleep = false;
                    RestTime = 0;
                    transform.position = LastPos;
                    isLast = true;
                }
                if (!Rest)
                {
                    TwoPlayerControl();
                    anim.SetBool("moving", true);
                    anim.SetBool("sleep", false);
                }
                
            }

            if (inPlayerBody)
            {
                if (BirdShoot.MouseInput0)
                {
                    BirdShoot.birdZ = true;
                    BirdShoot.QQMainControl = true;
                }
            }

            if (!BirdShoot.MouseInput0)
            {
                BirdShoot.birdZ = false;
                BirdShoot.QQMainControl = false;
            }

            if (!PlayerControl.STOP && !BirdShoot.birdS && !BirdShoot.QQMainControl)
            {
                if (Input.GetMouseButtonDown(2))
                {
                    if (!Rest)
                    {
                        Rest = true;
                    }
                    else
                    {
                        if (!PlayerControl.isHead)
                        {
                            Rest = false;
                            sleep = false;
                        }
                    }
                }
            }

            if (Rest && !sleep && !PlayerControl.Dead)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.15f);
            }
        }

        if (BirdShoot.birdS)
        {
            anim.SetBool("s", true);
        }
        else
        {
            anim.SetBool("s", false);
        }
    }

    void FixedUpdate()
    {
        if (!SwitchCharacter.two_player)
        {
            if (!SwitchCharacter.switchCharacter)
            {
                if (BirdShoot.QQTime <= 0 && !BirdShoot.birdZ && BirdFollowCheck.QQFollow)
                {
                    if (RestTime < 3 && !BirdShoot.touchbird)
                    {
                        if (!PlayerControl.Dead)
                        {
                            RestTime += Time.deltaTime;
                            anim.SetBool("moving", true);
                            anim.SetBool("sleep", false);
                        }
                        NewFollow();
                    }
                    else if (RestTime >= 3 && !PlayerControl.Dead)
                    {

                        if (transform.position.x < player.transform.position.x)
                        {
                            QQsr.transform.localRotation = Quaternion.Euler(0, 180, 0);
                            QQsweat.transform.localRotation = Quaternion.Euler(0, 180, 0);
                        }
                        else if (transform.position.x > player.transform.position.x)
                        {
                            QQsr.transform.localRotation = Quaternion.Euler(0, 0, 0);
                            QQsweat.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        }
                        RestTime = 5;
                        Rest = true;
                        if (!sleep)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.15f);
                            QQcc.isTrigger = false;
                        }
                        else
                        {
                            QQcc.isTrigger = true;
                            BirdShoot.QQpower += Time.deltaTime * 1.5f;
                            transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
                        }

                    }
                    else if (PlayerControl.Dead)
                    {
                        NewFollow();
                    }
                }
                else if (BirdShoot.birdZ)
                {
                    anim.SetBool("sleep", false);
                    sleep = false;
                    Rest = false;
                    RestTime = 0;
                    birdZpos();
                }
            }
            else if (SwitchCharacter.switchCharacter)
            {
                isFollow = false;
            }
        }
        else if (SwitchCharacter.two_player)
        {            
            if (transform.position.x < player.transform.position.x)
            {
                QQsr.transform.localRotation = Quaternion.Euler(0, 180, 0);
                QQsweat.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if (transform.position.x > player.transform.position.x)
            {
                QQsr.transform.localRotation = Quaternion.Euler(0, 0, 0);
                QQsweat.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (!sleep && !Rest && !PlayerControl.Dead)
            {
                QQcc.isTrigger = false;
            }
            if (!sleep && Rest && !PlayerControl.Dead)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.15f);
                QQcc.isTrigger = false;
            }
            else if(sleep && !PlayerControl.Dead)
            {
                QQcc.isTrigger = true;
                BirdShoot.QQpower += Time.deltaTime*1.5f;
                transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);
            }

            if (FirstClick)
            {
                if (!BirdShoot.birdS)
                {
                    if (!BirdShoot.QQMainControl && !BirdShoot.isDashing)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, MousePosition, 0.15f);
                    }
                    else if(BirdShoot.QQMainControl && !PlayerFoot.touchGround)
                    {
                        float MousePosX = MousePosition.x;
                        transform.position = player.transform.position;
                        Vector3 MousePositionX = new Vector3(MousePosX, transform.position.y, transform.position.z);
                        player.transform.position = Vector3.MoveTowards(transform.position, MousePositionX, 0.12f);
                        
                        if (PlayerControl.playerX)
                        {
                            QQsr.transform.localRotation = Quaternion.Euler(0, 180, 0);
                            QQsweat.transform.localRotation = Quaternion.Euler(0, 180, 0);
                        }
                        else
                        {
                            QQsr.transform.localRotation = Quaternion.Euler(0, 0, 0);
                            QQsweat.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        }
                    }
                }
                else
                {                 
                    MousePosition = transform.position;                    
                }
            }
        }
    }

    void birdZpos()
    {
        if (!SwitchCharacter.two_player)
        {
            if (BirdShoot.birdZ)
            {
                transform.position = playerHead.transform.position;
                if (PlayerControl.playerX)
                {
                    QQsr.transform.localRotation = Quaternion.Euler(0, 180, 0);
                    QQsweat.transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else if (!PlayerControl.playerX)
                {
                    QQsr.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    QQsweat.transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }

    public void BirdReturn()
    {
        transform.position = player.transform.position;
    }

    void NewFollow()
    {
        StopDistance = Physics2D.OverlapCircle(transform.position, 1.5f, LayerMask.GetMask("Player"));
        playerY = player.transform.position.y;
        playerZ = player.transform.position.z;
        //transform.localPosition = new Vector3(transform.position.x, playerY, playerZ);

        if (!StopDistance && !PlayerControl.Dead)
        {
            time += Time.deltaTime;
            //playerX = Mathf.Lerp(transform.position.x, player.transform.position.x, time / 50);
            //transform.localPosition = new Vector3(playerX, transform.position.y , playerZ);
            isFollow = true;
            QQFly();
            transform.position = Vector3.Lerp(transform.position, player.transform.position, time / 50);
        }
        else if (StopDistance && !PlayerControl.Dead)
        {
            isFollow = false;
            time = 2;
            QQIdle();
        }

        if (transform.position.x < player.transform.position.x)
        {
            QQsr.transform.localRotation = Quaternion.Euler(0, 180, 0);
            QQsweat.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.x > player.transform.position.x)
        {
            QQsr.transform.localRotation = Quaternion.Euler(0, 0, 0);
            QQsweat.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (PlayerControl.Dead)
        {
            RestTime = 0;
            Rest = false;
            sleep = false;
            anim.SetBool("sleep", false);
            anim.SetBool("moving", true);
            QQcc.isTrigger = true;
            if (!AreaCheck.Follow)
            {
                if (!AreaCheck.Half && !AreaCheck.Second && !AreaCheck.Third && !AreaCheck.Forth && !AreaCheck.Fifth)
                {
                    if (AreaCheck.A)
                    {
                        if (DeadPosA != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.B)
                    {
                        if (DeadPosB != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB.position, 0.1f);
                        }
                        else if (DeadPosA != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA.position, 0.1f);
                        }            
                    }
                    else if (AreaCheck.C)
                    {
                        if (DeadPosC != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosC.position, 0.1f);
                        }
                        else if (DeadPosB != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB.position, 0.1f);
                        }
                        else if (DeadPosA != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.D)
                    {
                        if (DeadPosD != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosD.position, 0.1f);
                        }
                        else if (DeadPosC != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosC.position, 0.1f);
                        }
                        else if (DeadPosB != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB.position, 0.1f);
                        }
                        else if (DeadPosA != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.E)
                    {
                        if (DeadPosE != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosE.position, 0.1f);
                        }
                        else if (DeadPosD != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosD.position, 0.1f);
                        }
                        else if (DeadPosC != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosC.position, 0.1f);
                        }
                        else if (DeadPosB != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB.position, 0.1f);
                        }
                        else if (DeadPosA != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA.position, 0.1f);
                        }
                    }
                    else
                    {
                        if (DeadPosA)
                        {
                            time += Time.deltaTime;
                            transform.position = DeadPosA.position;
                        }
                    }
                }
                else if (AreaCheck.Second)
                {
                    if (AreaCheck.A)
                    {
                        if (DeadPosA2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA2.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.B)
                    {
                        if (DeadPosB2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB2.position, 0.1f);
                        }
                        else if (DeadPosA2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA2.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.C)
                    {
                        if (DeadPosC2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosC2.position, 0.1f);
                        }
                        else if (DeadPosB2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB2.position, 0.1f);
                        }
                        else if (DeadPosA2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA2.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.D)
                    {
                        if (DeadPosD2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosD2.position, 0.1f);
                        }
                        else if (DeadPosC2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosC2.position, 0.1f);
                        }
                        else if (DeadPosB2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB2.position, 0.1f);
                        }
                        else if (DeadPosA2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA2.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.E)
                    {
                        if (DeadPosE2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosE2.position, 0.1f);
                        }
                        else if (DeadPosD2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosD2.position, 0.1f);
                        }
                        else if (DeadPosC2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosC2.position, 0.1f);
                        }
                        else if (DeadPosB2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB2.position, 0.1f);
                        }
                        else if (DeadPosA2 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA2.position, 0.1f);
                        }
                    }
                }
                else if (AreaCheck.Third)
                {
                    if (AreaCheck.A)
                    {
                        if (DeadPosA3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA3.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.B)
                    {
                        if (DeadPosB3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB3.position, 0.1f);
                        }
                        else if (DeadPosA3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA3.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.C)
                    {
                        if (DeadPosC3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosC3.position, 0.1f);
                        }
                        else if (DeadPosB3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB3.position, 0.1f);
                        }
                        else if (DeadPosA3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA3.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.D)
                    {
                        if (DeadPosD3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosD3.position, 0.1f);
                        }
                        else if (DeadPosC3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosC3.position, 0.1f);
                        }
                        else if (DeadPosB3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB3.position, 0.1f);
                        }
                        else if (DeadPosA3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA3.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.E)
                    {
                        if (DeadPosE3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosE3.position, 0.1f);
                        }
                        else if (DeadPosD3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosD3.position, 0.1f);
                        }
                        else if (DeadPosC3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosC3.position, 0.1f);
                        }
                        else if (DeadPosB3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB3.position, 0.1f);
                        }
                        else if (DeadPosA3 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosA3.position, 0.1f);
                        }
                    }
                }
                else if (AreaCheck.Forth)
                {
                    if (AreaCheck.B)
                    {
                        if (DeadPosB4 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB4.position, 0.1f);
                        }
                    }
                    else if (AreaCheck.C)
                    {
                        if (DeadPosC4 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosC4.position, 0.1f);
                        }
                    }
                }
                else if (AreaCheck.Fifth)
                {
                    if (AreaCheck.B)
                    {
                        if (DeadPosB5 != null)
                        {
                            transform.position = Vector3.Lerp(transform.position, DeadPosB5.position, 0.1f);
                        }
                    }
                }
            }
            else
            {
                transform.position = player.transform.position;
            }
        }
        else if(!isFollow)
        {
            QQcc.isTrigger = false;
        }
    }

    void Control()
    {
        if (QQrb.velocity.x > 0.1f)
        {
            QQsr.transform.localRotation = Quaternion.Euler(0, 180, 0);
            QQsweat.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (QQrb.velocity.x < -0.1f)
        {
            QQsr.transform.localRotation = Quaternion.Euler(0, 0, 0);
            QQsweat.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        float moveDirH = Input.GetAxis("Horizontal");
        float moveDirV = Input.GetAxis("Vertical");
        QQrb.velocity = new Vector2(moveDirH * 6, moveDirV *6);        
    }

    void TwoPlayerControl()
    {
        FirstClick = true;
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 diff = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, objectPos.z)) - transform.position;
        MousePosition = transform.position + diff;       
    }

    public void A()
    {
        anim.SetTrigger("z");
    }

    void QQIdle()
    {
        anim.SetBool("moving", false);
    }

    void QQFly()
    {
        anim.SetBool("moving", true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            inGround = true;
        }

        if (other.gameObject.tag == "Player")
        {
            if (SwitchCharacter.two_player)
            {
                inPlayerBody = true;               
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (!PlayerControl.Dead)
            {
                BirdFollowCheck.QQFollow = true;
                //BirdReturn();               
            }
        }

        if (other.gameObject.tag == "Player")
        {
             if (Rest && !PlayerControl.Dead)
             {
                 anim.SetBool("sleep", true);
                 sleep = true;
             }     
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (isFollow)
            {
                if (!StopDistance)
                {
                    if (touchGroundTime > 1)
                    {
                        QQcc.isTrigger = true;
                    }
                    else if (touchGroundTime <= 1)
                    {
                        touchGroundTime += Time.deltaTime;
                    }
                }
            }
            else
            {
                QQcc.isTrigger = false;
                touchGroundTime = 0;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            inGround = false;
        }

        if (other.gameObject.tag == "Player")
        {
            if (SwitchCharacter.two_player)
            {
                inPlayerBody = false;
            }
        }
    }
}

