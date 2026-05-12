using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdShoot : MonoBehaviour
{
    [Header("基本")]
    public Transform QQ;
    public Transform player;
    //public GameObject Arrow;
    public Rigidbody2D PlayerRb;
    public Rigidbody2D QQrb;
    //public CircleCollider2D QQcc;
    public GameObject QQarea;
    private float time;
    public static bool birdX;
    public static bool birdS;
    public static bool touchbird;
    public static float QQTime;
    public static bool birdZ;
    public static Vector2 dir;
    private bool up;
    public static float QQpower;
    public static float QQFullpower;
    private float QQpowerloss;
    private float EasyModBouns;
    private float FinalStageBouns;
    public static bool MouseInput0;
    public static bool QQMainControl;
    public SpriteRenderer UpArrow;
    public SpriteRenderer DownArrow;
    public SpriteRenderer LeftArrow;
    public SpriteRenderer RightArrow;
    private Color _Transparent;
    private Color _White;
    private Color _Green;

    public GameObject Sweat;
    //public static bool P2_birdS;

    public GameObject QQSParticle;
    [Header("體力條")]
    public Image PowerBar;
       
    [Header("音效")]
    public GameObject BirdDashAudio;

    //private bool touchQQ;
    public static bool canDash;
    public static bool isDashing;
    private float dashingTime = 0.15f;
    private BirdFollow BF;
    [Header("衝刺軌跡")]
    public TrailRenderer tr;

    // Start is called before the first frame update
    void Awake()
    {
        QQarea.SetActive(false);
    }

    void Start()
    {
        _Transparent = new Color(1, 1, 1, 0);
        _White = new Color(1, 1, 1, 1);
        _Green = new Color(0, 1, 0, 1);
        BF = GameObject.FindGameObjectWithTag("QQ").GetComponent<BirdFollow>();
        birdZ = false;
        //touchQQ = false;
        QQFullpower = 10;
        QQpower = QQFullpower;
        UpArrow.color = _Transparent;
        DownArrow.color = _Transparent;
        LeftArrow.color = _Transparent;
        RightArrow.color = _Transparent;
    }

    // Update is called once per frame
    void Update()
    {
        if (!SwitchCharacter.two_player && BirdFollowCheck.QQFollow)
        {
            QQSParticle.SetActive(false);
        }

        if (QQpower >= 10)
        {
            QQpower = 10;
        }

        if (Stage4_new.Action)
        {
            FinalStageBouns = 1.5f;
        }
        else
        {
            FinalStageBouns = 1;
        }

        if (PlayerControl.EasyMod)
        {
            EasyModBouns = 2;
        }
        else
        {
            EasyModBouns = 1;
        }

        if (!NextStage2_2_1.lv5_1)
        {
            QQpowerloss = 5;
        }
        else
        {
            QQpowerloss = 1;
        }

        if (isDashing)
        {
            return;           
        }

        if (!PlayerControl.Dead)
        {
            if (!PlayerControl.isGrabbing)
            {
                Z();
            }
            //X();
        }

        if (QQpower <= 0 && !BirdFollow.sleep)
        {
            Sweat.SetActive(true);
        }
        else
        {
            Sweat.SetActive(false);
        }

        S();
        //A();
        moveTime();
        QQPOWER();
        twoPlayerControl();
    }

    void twoPlayerControl()
    {
        if (SwitchCharacter.two_player && !PlayerControl.STOP)
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseInput0 = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                MouseInput0 = false;
                QQMainControl = false;
            }

            if (!BirdFollow.Rest)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    if (birdS && !touchbird)
                    {
                        birdS = false;
                        QQarea.SetActive(false);
                    }
                    else if (!birdS)
                    {
                        birdS = true;
                        QQarea.SetActive(true);
                    }
                }
            }

            if (!birdS)
            {
                QQarea.SetActive(false);
            }

            if (canDash)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    birdS = false;
                    touchbird = false;
                    StartCoroutine(RDash());
                    QQTime = 0;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    birdS = false;
                    touchbird = false;
                    StartCoroutine(LDash());
                    QQTime = 0;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    birdS = false;
                    touchbird = false;
                    StartCoroutine(UDash());
                    QQTime = 0;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    birdS = false;
                    touchbird = false;
                    StartCoroutine(DDash());
                    QQTime = 0;
                }
            }
        }
        else if (PlayerControl.STOP)
        {
            MouseInput0 = false;
        }
    }

    void Z()//滑翔
    {
        if (!SwitchCharacter.two_player)
        {
            if (!SwitchCharacter.switchCharacter)
            {
                if (!birdX && BirdFollowCheck.QQFollow && !canDash && !PlayerControl.isHead)
                {
                    if ((Input.GetButton("Glide") && QQTime <= 0))
                    {
                        birdZ = true;
                    }
                    else
                    {
                        birdZ = false;
                    }
                }
            }
        }

        if (PlayerControl.isHead)
        {
            birdZ = false;
        }
    }

    void S()//操作QQ時，定位
    {
        if (!SwitchCharacter.two_player)
        {
            if (!SwitchCharacter.switchCharacter && birdS)
            {
                QQSParticle.SetActive(true);
                QQrb.gravityScale = 0;
                QQrb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
            else if (SwitchCharacter.switchCharacter && !birdS)
            {
                QQSParticle.SetActive(false);
                birdS = false;
                QQrb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else if (!SwitchCharacter.switchCharacter && !birdS)
            {
                QQSParticle.SetActive(false);
            }

            if (!BirdFollowCheck.QQFollow)
            {
                QQarea.SetActive(true);
            }
            else if (BirdFollowCheck.QQFollow)
            {
                QQarea.SetActive(false);
            }
        }

        if (SwitchCharacter.two_player)
        {
            if (birdS)
            {
                QQSParticle.SetActive(true);
                QQrb.gravityScale = 0;
                QQrb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                QQSParticle.SetActive(false);
                QQrb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }

        if (!SwitchCharacter.switchCharacter)
        {
            if (touchbird)
            {
                if (!SwitchCharacter.two_player)
                {
                    BirdFollowCheck.QQFollow = true;
                }
                QQarea.SetActive(false);
                player.position = new Vector3(QQ.position.x, QQ.position.y + 0.5f, QQ.position.z);
                canDash = true;
                UpArrow.color = _White;
                DownArrow.color = _White;
                LeftArrow.color = _White;
                RightArrow.color = _White;
            }
            else
            {
                UpArrow.color = Color.Lerp(UpArrow.color, _Transparent, 0.2f);
                DownArrow.color = Color.Lerp(DownArrow.color, _Transparent, 0.2f);
                LeftArrow.color = Color.Lerp(LeftArrow.color, _Transparent, 0.2f);
                RightArrow.color = Color.Lerp(RightArrow.color, _Transparent, 0.2f);
            }

            if (canDash && !SwitchCharacter.switchCharacter && touchbird)
            {
                if (!PlayerControl.usingJoystick)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        RightArrow.color = _Green;
                        birdS = false;
                        touchbird = false;
                        StartCoroutine(RDash());
                        QQTime = 0;
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        LeftArrow.color = _Green;
                        birdS = false;
                        touchbird = false;
                        StartCoroutine(LDash());
                        QQTime = 0;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        UpArrow.color = _Green;
                        birdS = false;
                        touchbird = false;
                        StartCoroutine(UDash());
                        QQTime = 0;
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        DownArrow.color = _Green;
                        birdS = false;
                        touchbird = false;
                        StartCoroutine(DDash());
                        QQTime = 0;
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow) || PlayerControl.moveDirX > 0.9f)
                    {
                        RightArrow.color = _Green;
                        birdS = false;
                        touchbird = false;
                        StartCoroutine(RDash());
                        QQTime = 0;
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || PlayerControl.moveDirX < -0.9f)
                    {
                        LeftArrow.color = _Green;
                        birdS = false;
                        touchbird = false;
                        StartCoroutine(LDash());
                        QQTime = 0;
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow) || PlayerControl.moveDirY > 0.9f)
                    {
                        UpArrow.color = _Green;
                        birdS = false;
                        touchbird = false;
                        StartCoroutine(UDash());
                        QQTime = 0;
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow) || PlayerControl.moveDirY < -0.9f)
                    {
                        DownArrow.color = _Green;
                        birdS = false;
                        touchbird = false;
                        StartCoroutine(DDash());
                        QQTime = 0;
                    }
                }
            }
        }
        else
        {
            UpArrow.color = Color.Lerp(UpArrow.color, _Transparent, 0.2f);
            DownArrow.color = Color.Lerp(DownArrow.color, _Transparent, 0.2f);
            LeftArrow.color = Color.Lerp(LeftArrow.color, _Transparent, 0.2f);
            RightArrow.color = Color.Lerp(RightArrow.color, _Transparent, 0.2f);
        }
    }

    void A()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            QQ.position = transform.position;
        }
     
    }

    void moveTime()
    {
        if (birdX)
        {
            time += Time.deltaTime;
        }
        else if (!birdX)
        {
            time = 1;
        }
    }

    void QQPOWER()
    {
        if (PowerBar != null)
        {
            PowerBar.fillAmount = QQpower / QQFullpower;

            if (birdZ && !PlayerFoot.touchGround && !SwitchCharacter.switchCharacter && QQpower > 0)
            {
                QQpower -= Time.deltaTime * QQpowerloss / EasyModBouns / FinalStageBouns;
            }

            //if (QQpower < 10 && !touchQQ && !birdZ )
            //{
            //    QQpower += Time.deltaTime * EasyModBouns;
            //}
        }
    }

    private IEnumerator RDash()
    {
        Instantiate(BirdDashAudio, transform.position, transform.rotation);
        canDash = false;
        isDashing = true;
        float originalGravity = PlayerRb.gravityScale;
        PlayerRb.gravityScale = 0f;
        PlayerRb.velocity = new Vector2(20, 0);
        tr.emitting = true;       
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        PlayerRb.gravityScale = originalGravity;
        isDashing = false;
    }

    private IEnumerator LDash()
    {
        Instantiate(BirdDashAudio, transform.position, transform.rotation);
        canDash = false;
        isDashing = true;
        float originalGravity = PlayerRb.gravityScale;
        PlayerRb.gravityScale = 0f;
        PlayerRb.velocity = new Vector2(-20, 0);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        PlayerRb.gravityScale = originalGravity;
        isDashing = false;
    }

    private IEnumerator UDash()
    {
        Instantiate(BirdDashAudio, transform.position, transform.rotation);
        canDash = false;
        isDashing = true;
        float originalGravity = PlayerRb.gravityScale;
        PlayerRb.gravityScale = 0f;
        PlayerRb.velocity = new Vector2(0, 12);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        PlayerRb.gravityScale = originalGravity;
        isDashing = false;
    }

    private IEnumerator DDash()
    {
        Instantiate(BirdDashAudio, transform.position, transform.rotation);
        canDash = false;
        isDashing = true;
        float originalGravity = PlayerRb.gravityScale;
        PlayerRb.gravityScale = 0f;
        PlayerRb.velocity = new Vector2(0, -20);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        PlayerRb.gravityScale = originalGravity;
        isDashing = false;
    }
}
