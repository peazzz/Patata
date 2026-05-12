using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
	public static float moveDirX;
	public static float moveDirY;
	public float speed;
	public float jumpforce;
	public Transform footPoint;
	private float jumpFrace;
	private float WalljumpFrace;
	public SpriteRenderer playerSR;
	public GameObject playerCloak;
	private Rigidbody2D rb;
	public Animator anim;
	//public static bool touchGround;
	private bool deadEffect;
	public static int PlayerPower;
	public static bool doubleArrow;
	public static bool JumpKeyDash;
	public static bool AlwaysUp;
	public static bool UpFirst;
	public static bool EasyMod;
	private float EasyModBouns;
	private bool doubleArrowStart;
	private float doubleRightArrowTime;
	private float doubleLeftArrowTime;
	private float doubleUpArrowTime;
	//public static bool AutoGrabWall;
	[Header("死亡重生點")]
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
	public Transform DeadPosA4;
	public Transform DeadPosB4;
	public Transform DeadPosC4;
	public Transform DeadPosD4;
	public Transform DeadPosE4;
	public Transform DeadPosA5;
	public Transform DeadPosB5;

	public static bool CanDash;
	private float Dashcooldown;	


	[Header("特效")]
	public GameObject WalkEffect;
	public GameObject LandEffect;
	public GameObject WalkEffect_mini;
	public TrailRenderer tr;
	public GameObject BloodEffect;
	public GameObject BloodStain;

	[Header("音效")]
	public GameObject WalkAudio1;
	public GameObject WalkAudio2;
	public GameObject SandWalkAudio1;
	public GameObject SandWalkAudio2;
	public GameObject LandAudio;
	public GameObject SandLandAudio;
	public GameObject DashAudio;
	public GameObject QQAudio;
	public GameObject DeadAudio;
	[Header("體力條")]
	public Image PlayerPowerBar;

	private float WalkAudioTime;
	private float EffectTime;
	private float GrabbingEffectTime;
	private float JumpCooldown;
	private bool WalkAudioRound;
	private bool canJump;
	private bool JumpEnd;
	private float FallTime;
	private bool inDesert;
	private bool fallFix;
	private float WallJumpXForce;
	private float WallJumpYForce;
	private bool up;
	private bool isLand;
	private bool M;
	//private bool jump;
	private bool GrabR;
	private bool GrabL;
	public static bool playerX;
	public static bool STOP;
	public static bool Moving;
	public static bool Dead;
	public static float LandTime;
	public static bool isHead;
	public static bool usingJoystick;

	public Transform wallGrabPoint;
	public static bool isGrabbing;
	private float wallJumpTime = 0.2f;
	private float wallJumpCounter=0;
	private float coyoteTime = 0.15f;
	private float coyoteTimeCounter = 0;


	void Awake()
	{
		//NextStage1_3.lv3 = true;
		BirdShoot.isDashing = false;
	}
	// Start is called before the first frame update
	void Start()
    {
		playerX = true;
		usingJoystick = false;
		AlwaysUp = true;
		UpFirst = false;
		JumpKeyDash = true;
		//AutoGrabWall = true;
		doubleArrow = true;
		PlayerGrab.canGrab = false;
		isGrabbing = false;
		GrabR = false;
		GrabL = false;
		//NextStage2_2_1.lv5_1 = true;
		WalkAudioTime = 0;
		isHead = false;
		STOP = false;
		//NextStage1_3.lv3 = true;//測試在風沙關時打開
		//NextStage2_1.lv4 = true;

		rb = GetComponent<Rigidbody2D>();

		JumpEnd = true;
		Dashcooldown = 1f;
		Dead = false;
		speed = 6;
		jumpforce = 18;
		EffectTime = 0.5f;
		JumpCooldown = 0.5f;
		WallJumpXForce = 10;
		WallJumpYForce = 14;
	}

    // Update is called once per frame
    void Update()
    {
		string[] joystickNames = Input.GetJoystickNames();
		

		// 檢測手把是否已連接
		for (int i = 0; i < joystickNames.Length; i++)
		{
			if (!string.IsNullOrEmpty(joystickNames[i]))
			{
				usingJoystick = true;
				break;
			}
		}

		if (EasyMod)
		{
			EasyModBouns = 1.2f;
		}
		else
		{
			EasyModBouns = 1;
		}

		if (PlayerPowerBar != null)
		{
			PlayerPowerBar.fillAmount = PlayerPower / 1;
		}

		//if (Input.GetButtonDown("Master"))//作弊模式
		//{
		//	M = !M;
		//}

		moveDirX = Input.GetAxis("Horizontal");
		moveDirY = Input.GetAxis("Vertical");

		if (!Dead)
		{
			if (BirdShoot.QQMainControl && !PlayerFoot.touchGround)
			{
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;
				rb.velocity = new Vector2(0, 0);
				fall();
			}
			else if (STOP || SwitchCharacter.switchCharacter && !M)
			{
				Moving = false;
				rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
				anim.SetBool("run", false);
				anim.SetBool("grab", false);
				anim.SetBool("fall", false);
				anim.SetBool("Run_to_Fall", false);
				Death();
			}
			else if (wallJumpCounter > 0 && !M)
			{
				wallJumpCounter -= Time.deltaTime;

				if (moveDirX<-0.1f && !BirdShoot.touchbird && CanDash && Input.GetButtonDown("Dash"))
				{
					StartCoroutine(LDash());
				}
				else if (moveDirX > 0.1f && !BirdShoot.touchbird && CanDash && Input.GetButtonDown("Dash"))
				{
					StartCoroutine(RDash());
				}
				wallJump();
				JumpCondition();
				Death();
			}
			else if (wallJumpCounter <= 0 && !M)
			{
				WallJumpXForce = 10;
				WallJumpYForce = 14;
				wallJumpCounter = 0;
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;

				if (!BirdShoot.isDashing && !isGrabbing)
				{
					Run();
				}
				JumpCondition();
				Death();
				fall();
				dash();
				if (!BirdShoot.birdZ)
				{
					wallJump();
				}
				Effect();
				GroundType();
			}
			else if (M)
			{
				Mm();
			}
		}
		else if (Dead)
		{
			Death();
		}
	}

	void FixedUpdate()
	{
		if (jumpFrace > 0)
		{
			jumpFrace--;
		}

		if (WalljumpFrace > 0)
		{
			WalljumpFrace--;
		}
	}

	void Mm()
	{
		float moveDirH = Input.GetAxis("Horizontal");
		float moveDirV = Input.GetAxis("Vertical");
		rb.velocity = new Vector2(moveDirH * 6, moveDirV * 6);
	}

	void Run()
	{
		rb.velocity = new Vector2(moveDirX * speed * EasyModBouns, rb.velocity.y);

		if (nextFinalStage.lv4)
		{
			if (rb.velocity.x < 0f)
			{
				moveDirX = 0;
				rb.velocity = new Vector2(0 * speed * EasyModBouns, rb.velocity.y); ;
			}
		}

		if (moveDirX > 0.01f )
        {
			transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);			
			playerX = true;
		}
		else if (moveDirX < -0.01f)
		{
			transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
			playerX = false;
		}

		if ((moveDirX > 0.01f|| moveDirX < -0.01f )&& PlayerFoot.touchGround)
		{
			WalkAudioTime += Time.deltaTime;
			if (!inDesert)
			{
				if (!WalkAudioRound && WalkAudioTime < 0.33f)
				{
					WalkAudioRound = true;
					Instantiate(WalkAudio1, transform.position, transform.rotation);
				}
				else if (WalkAudioRound && WalkAudioTime > 0.33f)
				{
					Instantiate(WalkAudio2, transform.position, transform.rotation);
					WalkAudioRound = false;
					Invoke("WAT", 0.33f);
				}
			}
			else if (inDesert)
			{
				if (!WalkAudioRound && WalkAudioTime < 0.33f)
				{
					WalkAudioRound = true;
					Instantiate(SandWalkAudio1, transform.position, transform.rotation);
				}
				else if (WalkAudioRound && WalkAudioTime > 0.33f)
				{
					Instantiate(SandWalkAudio2, transform.position, transform.rotation);
					WalkAudioRound = false;
					Invoke("WAT", 0.33f);
				}
			}
		}

		if (moveDirX != 0　&& PlayerFoot.touchGround)
		{
			anim.SetBool("run", true);
			Moving = true;
		}
		else if(PlayerFoot.touchGround)
		{
			anim.SetBool("run", false);
			Moving = false;
		}
	}

	void WAT()
	{
		WalkAudioTime = 0;
	}

	void GroundType()
	{
		inDesert = Physics2D.OverlapCircle(footPoint.position, 1f, LayerMask.GetMask("Desert"));
	}

	void JumpCondition()
	{
		//touchGround = Physics2D.OverlapCircle(footPoint.position, 0.11f, LayerMask.GetMask("Ground")) || 
		//	Physics2D.OverlapCircle(footPoint.position, 0.11f, LayerMask.GetMask("Platform")) ||
		//	Physics2D.OverlapCircle(footPoint.position, 0.11f, LayerMask.GetMask("Box")) ||
		//	Physics2D.OverlapCircle(footPoint.position, 0.11f, LayerMask.GetMask("Desert"));


		if (JumpCooldown > 0)
		{
			JumpCooldown -= Time.deltaTime;
		}
		else if (JumpCooldown <= 0)
		{
			JumpCooldown = 0;
			canJump = true;
		}

		if (Input.GetButtonDown("Jump") && coyoteTimeCounter>0f && canJump) //&& !isHead)
		{
			StartCoroutine(Jump());
		}
		else if (Input.GetButtonDown("Jump") && !PlayerFoot.touchGround && !BirdShoot.canDash)
		{
			jumpFrace = 5;
		}

		if (jumpFrace > 0 && PlayerFoot.touchGround && canJump)//地板跳躍
		{
			StartCoroutine(Jump());
		}

		if (Input.GetButtonDown("Jump") && isGrabbing && !BirdShoot.isDashing)//蹦跳
		{
			isGrabbing = false;
			BirdShoot.birdZ = false;
			if (LandEffect != null)
			{
				Instantiate(LandEffect, footPoint.position, Quaternion.identity);
			}
			wallJumpCounter = wallJumpTime;
			if (GrabR)
			{
				//Instantiate(JumpAudio, transform.position, transform.rotation);
				rb.velocity = new Vector2(-WallJumpXForce * EasyModBouns, WallJumpYForce * EasyModBouns);
				transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
				playerX = false;
			}
			else if (GrabL)
			{
				//Instantiate(JumpAudio, transform.position, transform.rotation);
				rb.velocity = new Vector2(WallJumpXForce * EasyModBouns, WallJumpYForce * EasyModBouns);
				transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
				playerX = true;
			}			
		}
		else if (BirdShoot.isDashing && Input.GetButtonDown("Jump") && PlayerGrab.canGrab)
		{
			isGrabbing = false;
			if (LandEffect != null)
			{
				Instantiate(LandEffect, footPoint.position, Quaternion.identity);
			}
			wallJumpCounter = 0.17f;
		
			if (playerX)
			{
				StartCoroutine(ULDash());
			}
			else if (!playerX)
			{
				StartCoroutine(URDash());
			}
		}

		if (!PlayerGrab.canGrab && !PlayerFoot.touchGround && Input.GetButtonDown("Jump"))//尚未(即將)蹦跳
		{
			WalljumpFrace = 5;
		}

		if (WalljumpFrace > 0 && isGrabbing && !BirdShoot.isDashing)//蹦跳
		{
			isGrabbing = false;
			//Instantiate(LandEffect, footPoint.position, Quaternion.identity);
			wallJumpCounter = wallJumpTime;

			if (GrabR)
			{
				//Instantiate(LandAudio, transform.position, transform.rotation);
				rb.velocity = new Vector2(-WallJumpXForce * EasyModBouns, WallJumpYForce * EasyModBouns);
				transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
				playerX = false;
			}
			else if (GrabL)
			{
				//Instantiate(LandAudio, transform.position, transform.rotation);
				rb.velocity = new Vector2(WallJumpXForce * EasyModBouns, WallJumpYForce * EasyModBouns);
				transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
				playerX = true;
			}
		}
		else if (BirdShoot.isDashing && WalljumpFrace > 0 && PlayerGrab.canGrab)
		{
			isGrabbing = false;
			Instantiate(LandEffect, footPoint.position, Quaternion.identity);
			wallJumpCounter = 0.17f;
		
			if (playerX)
			{
				StartCoroutine(ULDash());
			}
			else if (!playerX)
			{
				StartCoroutine(URDash());
			}
		}

		if (PlayerFoot.touchGround)
		{
			coyoteTimeCounter = coyoteTime;
		}
		else if(!PlayerFoot.touchGround)
		{
			if (coyoteTimeCounter > 0)
			{
				coyoteTimeCounter -= Time.deltaTime;
			}
			else if (coyoteTimeCounter <= 0)
			{
				coyoteTimeCounter = 0;
			}
		}
	}

	IEnumerator Jump()
	{
		if (!BirdShoot.touchbird && (!BirdShoot.birdZ || !isHead))
		{
			canJump = false;
			JumpCooldown = 0.5f;
			CanDash = true;
			anim.SetBool("jump", true);
			JumpEnd = false;
			if (!BirdShoot.isDashing)
			{
				rb.velocity = Vector2.up * jumpforce * EasyModBouns;
				yield return new WaitForSeconds(0.05f);
				anim.SetBool("jump", false);
			}
			else if (BirdShoot.isDashing)
			{
				rb.velocity = Vector2.up * jumpforce / 1.3f * EasyModBouns;
				yield return new WaitForSeconds(0.05f);
				anim.SetBool("jump", false);
			}
		}
	}

	void fall()
	{
		if (BirdShoot.QQpower > 0 && BirdShoot.birdZ)
		{
			rb.velocity = new Vector2(rb.velocity.x, 5);
		}
		else if(BirdShoot.QQpower <= 0 && BirdShoot.birdZ && rb.velocity.y < -0.1f)
		{
			rb.velocity = new Vector2(rb.velocity.x, 0);
		}

		if (rb.velocity.y < -10f)
		{
			rb.velocity = new Vector2(rb.velocity.x, -10);
		}

		if (BirdShoot.isDashing)
		{
			rb.gravityScale = 0;
		}
		else if (isGrabbing)
		{
			rb.gravityScale = 8;
		}
		else
		{
			rb.gravityScale = 5;
		}

		if (!BirdShoot.birdZ)
		{
			if ((rb.velocity.y < -0.1f || BirdShoot.touchbird) && !PlayerFoot.touchGround)//降落時
			{
				anim.SetBool("Run_to_Fall", true);
				anim.SetBool("fall", true);
				LandTime += Time.deltaTime;
				JumpEnd = true;
			}
			else
			{
				anim.SetBool("Run_to_Fall", false);
				anim.SetBool("fall", false);
			}
		}
		else if (BirdShoot.birdZ)
		{
			if (!PlayerFoot.touchGround)
			{
				anim.SetBool("Run_to_Fall", true);
				anim.SetBool("fall", true);
			}
			else if (PlayerFoot.touchGround)
			{
				anim.SetBool("Run_to_Fall", false);
				anim.SetBool("fall", false);
			}
			else if (rb.velocity.y > 0.1f)
			{
				anim.SetBool("Run_to_Fall", false);
				anim.SetBool("run", false);
				anim.SetBool("fall", false);
			}
		}

		if (!JumpEnd)
		{
			FallTime += Time.deltaTime;
		}
		else if (JumpEnd)
		{
			FallTime = 0;
		}

		if (FallTime>0.5f && PlayerFoot.touchGround)//跳完沒跑墜落動畫的時候
		{
			FallTime = 0;
			anim.SetTrigger("jumpFix");
		}
	}

	void wallJump()
	{
		//if (AutoGrabWall)
		//{
			if (playerX && PlayerGrab.canGrab && !PlayerFoot.touchGround && rb.velocity.y < 8f && moveDirX > 0.6f)//靠在牆面上&&離開地面&&降落時
			{
				isGrabbing = true;
			}
			else if (!playerX && PlayerGrab.canGrab && !PlayerFoot.touchGround && rb.velocity.y < 8f && moveDirX < -0.6f)
			{
				isGrabbing = true;
			}
		//}
		//else if (!AutoGrabWall)
		//{
		//	if (playerX && PlayerGrab.canGrab && !PlayerFoot.touchGround && rb.velocity.y < 8f && Input.GetButton("Slides"))//靠在牆面上&&離開地面&&降落時
		//	{
		//		isGrabbing = true;
		//	}
		//	else if (!playerX && PlayerGrab.canGrab && !PlayerFoot.touchGround && rb.velocity.y < 8f && Input.GetButton("Slides"))
		//	{
		//		isGrabbing = true;
		//	}
		//
		//	if (isGrabbing && Input.GetButtonUp("Slides"))
		//	{
		//		isGrabbing = false;
		//		GrabR = false;
		//		GrabL = false;
		//	}
		//}

		if (PlayerFoot.touchGround || !PlayerGrab.canGrab)
		{
			isGrabbing = false;
			GrabR = false;
			GrabL = false;
		}
		else if (GrabR)
		{
			if (moveDirX < -0.3f || BirdShoot.isDashing)
			{
				PlayerGrab.canGrab = false;
				isGrabbing = false;
				GrabR = false;
				GrabL = false;
			}
		}
		else if (GrabL)
		{
			if (moveDirX > 0.3f || BirdShoot.isDashing)
			{
				PlayerGrab.canGrab = false;
				isGrabbing = false;
				GrabL = false;
				GrabR = false;
			}
		}

		if (playerX && isGrabbing)
		{
			GrabR = true;
		}
		else if (!playerX && isGrabbing)
		{
			GrabL = true;
		}

		if (isGrabbing)
		{
			rb.velocity = Vector2.zero;
			anim.SetBool("grab", true);
		}
		else
		{
			anim.SetBool("grab", false);
			GrabL = false;
			GrabR = false;
		}

		
	}

	void dash()
	{
		if (Dashcooldown > 0)
		{
			Dashcooldown -= Time.deltaTime;
		}
		else
		{
			Dashcooldown = 0;
		}

		if (Dashcooldown <= 0 && PlayerFoot.touchGround)
		{
			CanDash = true;
		}

		if (CanDash)
		{
			PlayerPower = 1;
		}
		else
		{
			PlayerPower = 0;
		}

		if (Input.GetButtonDown("Dash") && !BirdShoot.touchbird && CanDash && !BirdShoot.isDashing) ////&& !up )
		{
			if (!isGrabbing)
			{
				StartCoroutine(Dash());
			}
			else if (isGrabbing && GrabR)
			{
				StartCoroutine(LDash());
			}
			else if (isGrabbing && GrabL)
			{
				StartCoroutine(RDash());
			}
		}
		else if (up && Input.GetButtonDown("Dash") && !BirdShoot.touchbird && CanDash)
		{
			////if (!isGrabbing)
			////{
			////	up = false;
			////	StartCoroutine(UpDash());
			////}
			////else 
			if (isGrabbing && GrabR)
			{
				up = false;
				Instantiate(DashAudio, transform.position, transform.rotation);
				StartCoroutine(ULDash());
			}
			else if (isGrabbing && GrabL)
			{
				up = false;
				Instantiate(DashAudio, transform.position, transform.rotation);
				StartCoroutine(URDash());
			}			
		}

		//if (JumpKeyDash)
		//{
		//	if (coyoteTimeCounter<=0 && !BirdShoot.isDashing && !BirdShoot.touchbird && CanDash)
		//	{
		//		if (!isGrabbing && Input.GetButtonDown("Jump") && !GrabR && !GrabL && !AlwaysUp)
		//		{
		//			if (moveDirY>0.1f && moveDirX > 0.1f)
		//			{
		//				if (!UpFirst)
		//				{
		//					StartCoroutine(RDash());
		//				}
		//				else
		//				{
		//					StartCoroutine(UpDash());
		//				}
		//			}
		//			else if (moveDirY > 0.1f && moveDirX < -0.1f)
		//			{
		//				if (!UpFirst)
		//				{
		//					StartCoroutine(LDash());
		//				}
		//				else
		//				{
		//					StartCoroutine(UpDash());
		//				}
		//			}
		//			else if (moveDirY > 0.1f)
		//			{
		//				StartCoroutine(UpDash());
		//			}
		//			else if (moveDirX > 0.1f)
		//			{
		//				StartCoroutine(RDash());
		//			}
		//			else if (moveDirX < -0.1f)
		//			{
		//				StartCoroutine(LDash());
		//			}
		//			else
		//			{
		//				StartCoroutine(UpDash());
		//			}
		//		}
		//
		//		if (!isGrabbing && Input.GetButtonDown("Jump") && AlwaysUp && !GrabR && !GrabL)
		//		{
		//			StartCoroutine(UpDash());
		//		}
		//	}
		//}

		if (doubleArrow)//連續按鍵
		{
			if (!BirdShoot.touchbird && CanDash && !BirdShoot.isDashing && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (doubleLeftArrowTime <= 0)
				{
					doubleLeftArrowTime = 0.2f;
					doubleRightArrowTime = 0;
					doubleUpArrowTime = 0;
				}
				else if (!isGrabbing && doubleLeftArrowTime > 0.01f && doubleLeftArrowTime < 0.19f)
				{
					StartCoroutine(Dash());
				}
				else if (isGrabbing && doubleLeftArrowTime > 0.01f && doubleLeftArrowTime < 0.19f)
				{
					StartCoroutine(LDash());
				}
			}
			else if (!BirdShoot.touchbird && CanDash && !BirdShoot.isDashing && Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (doubleRightArrowTime <= 0)
				{
					doubleLeftArrowTime = 0;
					doubleRightArrowTime = 0.2f;
					doubleUpArrowTime = 0;
				}
				else if (!isGrabbing && doubleRightArrowTime > 0.01f && doubleRightArrowTime < 0.19f)
				{
					StartCoroutine(Dash());
				}
				else if (isGrabbing && doubleRightArrowTime > 0.01f && doubleRightArrowTime < 0.19f)
				{
					StartCoroutine(RDash());
				}
			}
			else if (!BirdShoot.touchbird && CanDash && !BirdShoot.isDashing && Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (doubleUpArrowTime <= 0)
				{
					doubleLeftArrowTime = 0;
					doubleRightArrowTime = 0;
					doubleUpArrowTime = 0.2f;
				}
				//else if (!isGrabbing && doubleUpArrowTime > 0.01f && doubleUpArrowTime < 0.19f)
				//{
				//	StartCoroutine(UpDash());
				//}
				else if (isGrabbing && GrabR && doubleUpArrowTime > 0.01f && doubleUpArrowTime < 0.19f)
				{
					Instantiate(DashAudio, transform.position, transform.rotation);
					StartCoroutine(ULDash());
				}
				else if (isGrabbing && GrabL && doubleUpArrowTime > 0.01f && doubleUpArrowTime < 0.19f)
				{
					Instantiate(DashAudio, transform.position, transform.rotation);
					StartCoroutine(URDash());
				}
			}
		}		

		if (doubleArrow)//連續按鍵判定
		{
			if (doubleRightArrowTime > 0)
			{
				doubleRightArrowTime -= Time.deltaTime;
			}
			else if (doubleRightArrowTime <= 0f)
			{
				doubleRightArrowTime = 0;
			}

			if (doubleLeftArrowTime > 0)
			{
				doubleLeftArrowTime -= Time.deltaTime;
			}
			else if (doubleLeftArrowTime <= 0f)
			{
				doubleLeftArrowTime = 0;
			}

			if (doubleUpArrowTime > 0)
			{
				doubleUpArrowTime -= Time.deltaTime;
			}
			else if (doubleUpArrowTime <= 0f)
			{
				doubleUpArrowTime = 0;
			}		
		}

	}

	void Effect()
	{
		if (EffectTime > 0)
		{
			EffectTime -= Time.deltaTime;
		}
		else if (EffectTime <= 0 && playerX && Moving && PlayerFoot.touchGround && inDesert)
		{
			EffectTime = 0.33f;
			if (WalkEffect != null)
			{
				Instantiate(WalkEffect, footPoint.position, Quaternion.identity);
			}
		}
		else if (EffectTime <= 0 && !playerX && Moving && PlayerFoot.touchGround && inDesert)
		{
			EffectTime = 0.33f;
			if (WalkEffect != null)
			{
				Instantiate(WalkEffect, footPoint.position, new Quaternion(0, 180, 0, 0));
			}
		}
		else
		{
			EffectTime = 0.4f;
		}


		if (GrabbingEffectTime > 0)
		{
			GrabbingEffectTime -= Time.deltaTime;
		}
		if (isGrabbing && GrabbingEffectTime <=0)
		{
			GrabbingEffectTime = 0.1f;
			if (WalkEffect != null)
			{
				Instantiate(WalkEffect_mini, wallGrabPoint.position, new Quaternion(-60, 90, 0, 0));
			}
		}
	}

	void Death()
	{
		if (Dead)
		{
			BirdShoot.touchbird = false;
			SandSea.ismoving = false;
			if (!deadEffect)
			{
				deadEffect = true;
				Instantiate(BloodStain, footPoint.position, Quaternion.identity);
				Instantiate(BloodEffect, footPoint.position, Quaternion.identity);
				Instantiate(DeadAudio, transform.position, transform.rotation);				
			}
			rb.constraints = RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			playerSR.enabled = false;
			playerCloak.SetActive(false);
			Invoke("Anabiosis", 1);
		}
	}

	void Anabiosis()
	{
		if (Dead)
		{
			Dead = false;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			deadEffect = false;
			if (!AreaCheck.Second && !AreaCheck.Third && !AreaCheck.Half && !AreaCheck.Forth && !AreaCheck.Fifth)
			{
				if (AreaCheck.A)
				{
					if (DeadPosA != null)
					{
						transform.position = DeadPosA.position;
					}
				}
				else if (AreaCheck.B)
				{
					if (DeadPosB != null)
					{
						transform.position = DeadPosB.position;
					}
					else if (DeadPosA != null)
					{
						transform.position = DeadPosA.position;
					}
				}
				else if (AreaCheck.C)
				{
					if (DeadPosC != null)
					{
						transform.position = DeadPosC.position;
					}
					else if (DeadPosB != null)
					{
						transform.position = DeadPosB.position;
					}
					else if (DeadPosA != null)
					{
						transform.position = DeadPosA.position;
					}
				}
				else if (AreaCheck.D)
				{
					if (DeadPosD != null)
					{
						transform.position = DeadPosD.position;
					}
					else if (DeadPosC != null)
					{
						transform.position = DeadPosC.position;
					}
					else if (DeadPosB != null)
					{
						transform.position = DeadPosB.position;
					}
					else if (DeadPosA != null)
					{
						transform.position = DeadPosA.position;
					}
				}
				else if (AreaCheck.E)
				{
					if (DeadPosE != null)
					{
						transform.position = DeadPosE.position;
					}
					else if (DeadPosD != null)
					{
						transform.position = DeadPosD.position;
					}
					else if (DeadPosC != null)
					{
						transform.position = DeadPosC.position;
					}
					else if (DeadPosB != null)
					{
						transform.position = DeadPosB.position;
					}
					else if (DeadPosA != null)
					{
						transform.position = DeadPosA.position;
					}
				}
				else
				{
					if (DeadPosA != null)
					{
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
						transform.position = DeadPosA2.position;
					}
				}
				else if (AreaCheck.B)
				{
					if (DeadPosB2 != null)
					{
						transform.position = DeadPosB2.position;
					}
					else if (DeadPosA2 != null)
					{
						transform.position = DeadPosA2.position;
					}
				}
				else if (AreaCheck.C)
				{
					if (DeadPosC2 != null)
					{
						transform.position = DeadPosC2.position;
					}
					else if (DeadPosB2 != null)
					{
						transform.position = DeadPosB2.position;
					}
					else if (DeadPosA2 != null)
					{
						transform.position = DeadPosA2.position;
					}
				}
				else if (AreaCheck.D)
				{
					if (DeadPosD2 != null)
					{
						transform.position = DeadPosD2.position;
					}
					else if (DeadPosC2 != null)
					{
						transform.position = DeadPosC2.position;
					}
					else if (DeadPosB2 != null)
					{
						transform.position = DeadPosB2.position;
					}
					else if (DeadPosA2 != null)
					{
						transform.position = DeadPosA2.position;
					}
				}
				else if (AreaCheck.E)
				{
					if (DeadPosE2 != null)
					{
						transform.position = DeadPosE2.position;
					}
					else if (DeadPosD2 != null)
					{
						transform.position = DeadPosD2.position;
					}
					else if (DeadPosC2 != null)
					{
						transform.position = DeadPosC2.position;
					}
					else if (DeadPosB2 != null)
					{
						transform.position = DeadPosB2.position;
					}
					else if (DeadPosA2 != null)
					{
						transform.position = DeadPosA2.position;
					}
				}
			}
			else if (AreaCheck.Third)
			{
				if (AreaCheck.A)
				{
					if (DeadPosA3 != null)
					{
						transform.position = DeadPosA3.position;
					}
				}
				else if (AreaCheck.B)
				{
					if (DeadPosB3 != null)
					{
						transform.position = DeadPosB3.position;
					}
					else if (DeadPosA3 != null)
					{
						transform.position = DeadPosA3.position;
					}
				}
				else if (AreaCheck.C)
				{
					if (DeadPosC3 != null)
					{
						transform.position = DeadPosC3.position;
					}
					else if (DeadPosB3 != null)
					{
						transform.position = DeadPosB3.position;
					}
					else if (DeadPosA3 != null)
					{
						transform.position = DeadPosA3.position;
					}
				}
				else if (AreaCheck.D)
				{
					if (DeadPosD3 != null)
					{
						transform.position = DeadPosD3.position;
					}
					else if (DeadPosC3 != null)
					{
						transform.position = DeadPosC3.position;
					}
					else if (DeadPosB3 != null)
					{
						transform.position = DeadPosB3.position;
					}
					else if (DeadPosA3 != null)
					{
						transform.position = DeadPosA3.position;
					}
				}
				else if (AreaCheck.E)
				{
					if (DeadPosE3 != null)
					{
						transform.position = DeadPosE3.position;
					}
					else if (DeadPosD3 != null)
					{
						transform.position = DeadPosD3.position;
					}
					else if (DeadPosC3 != null)
					{
						transform.position = DeadPosC3.position;
					}
					else if (DeadPosB3 != null)
					{
						transform.position = DeadPosB3.position;
					}
					else if (DeadPosA3 != null)
					{
						transform.position = DeadPosA3.position;
					}
				}
			}
			else if (AreaCheck.Forth)
			{
				if (AreaCheck.A)
				{
					if (DeadPosA4 != null)
					{
						transform.position = DeadPosA4.position;
					}
				}
				else if (AreaCheck.B)
				{
					if (DeadPosB4 != null)
					{
						transform.position = DeadPosB4.position;
					}
					else if (DeadPosA4 != null)
					{
						transform.position = DeadPosA4.position;
					}
				}
				else if (AreaCheck.C)
				{
					if (DeadPosC4 != null)
					{
						transform.position = DeadPosC4.position;
					}
					else if (DeadPosB4 != null)
					{
						transform.position = DeadPosB4.position;
					}
					else if (DeadPosA4 != null)
					{
						transform.position = DeadPosA4.position;
					}
				}
				else if (AreaCheck.D)
				{
					if (DeadPosD4 != null)
					{
						transform.position = DeadPosD4.position;
					}
					else if (DeadPosC4 != null)
					{
						transform.position = DeadPosC4.position;
					}
					else if (DeadPosB4 != null)
					{
						transform.position = DeadPosB4.position;
					}
					else if (DeadPosA4 != null)
					{
						transform.position = DeadPosA4.position;
					}
				}
				else if (AreaCheck.E)
				{
					if (DeadPosE4 != null)
					{
						transform.position = DeadPosE4.position;
					}
					else if (DeadPosD4 != null)
					{
						transform.position = DeadPosD4.position;
					}
					else if (DeadPosC4 != null)
					{
						transform.position = DeadPosC4.position;
					}
					else if (DeadPosB4 != null)
					{
						transform.position = DeadPosB4.position;
					}
					else if (DeadPosA4 != null)
					{
						transform.position = DeadPosA4.position;
					}
				}
			}
			else if (AreaCheck.Fifth)
			{
				if (AreaCheck.B)
				{
					if (DeadPosB5 != null)
					{
						transform.position = DeadPosB5.position;
					}
					else if (DeadPosA5 != null)
					{
						transform.position = DeadPosA5.position;
					}
				}
			}

			playerSR.enabled = true;
			playerCloak.SetActive(true);
			STOP = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if ((!SwitchCharacter.switchCharacter || SwitchCharacter.two_player) && !BirdShoot.touchbird)
		{
			if (other.gameObject.tag == "QQarea")
			{
				Instantiate(QQAudio, transform.position, transform.rotation);
				BirdShoot.touchbird = true;
			}
		}

		if (other.gameObject.tag == "Box")
		{
			if (LandEffect != null)
			{
				Instantiate(LandAudio, transform.position, transform.rotation);
				//Instantiate(LandEffect, footPoint.position, Quaternion.identity);
			}
			this.transform.parent = other.gameObject.transform;
		}

		if (other.gameObject.tag == "Ground")
		{
			if (!inDesert)
			{
				Instantiate(LandAudio, transform.position, transform.rotation);
				if (LandEffect != null)
				{
					
					Instantiate(LandEffect, footPoint.position, Quaternion.identity);
				}
			}
			else if (inDesert)
			{
				if (LandEffect != null)
				{
					Instantiate(SandLandAudio, transform.position, transform.rotation);
					Instantiate(LandEffect, footPoint.position, Quaternion.identity);
				}
			}
		}

		if (other.gameObject.tag == "Desert")
		{
			Instantiate(SandLandAudio, transform.position, transform.rotation);
			Instantiate(LandEffect, footPoint.position, Quaternion.identity);
		}

		if (other.gameObject.tag == "Platform")
		{
			Instantiate(LandAudio, transform.position, transform.rotation);
			Instantiate(LandEffect, footPoint.position, Quaternion.identity);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Box")
		{
			this.transform.parent = null;
		}
	}

	private IEnumerator Dash()
	{	
		Instantiate(DashAudio, transform.position, transform.rotation);
		Dashcooldown = 0.3f;
		CanDash = false;
		BirdShoot.isDashing = true;
		float originalGravity = rb.gravityScale;
		rb.gravityScale = 0f;
		rb.velocity = new Vector2(transform.localScale.x * 80 * EasyModBouns, 0);
		tr.emitting = true;
		yield return new WaitForSeconds(0.15f);
		tr.emitting = false;
		rb.gravityScale = originalGravity;
		BirdShoot.isDashing = false;
	}

	private IEnumerator LDash()
	{
		Instantiate(DashAudio, transform.position, transform.rotation);
		Dashcooldown = 0.3f;
		CanDash = false;
		BirdShoot.isDashing = true;
		float originalGravity = rb.gravityScale;
		rb.gravityScale = 0f;
		rb.velocity = new Vector2(-20 * EasyModBouns, 0);
		tr.emitting = true;
		yield return new WaitForSeconds(0.15f);
		tr.emitting = false;
		rb.gravityScale = originalGravity;
		BirdShoot.isDashing = false;
	}

	private IEnumerator RDash()
	{
		Instantiate(DashAudio, transform.position, transform.rotation);
		Dashcooldown = 0.3f;
		CanDash = false;
		BirdShoot.isDashing = true;
		float originalGravity = rb.gravityScale;
		rb.gravityScale = 0f;
		rb.velocity = new Vector2(20 * EasyModBouns, 0);
		tr.emitting = true;
		yield return new WaitForSeconds(0.15f);
		tr.emitting = false;
		rb.gravityScale = originalGravity;
		BirdShoot.isDashing = false;
	}

	////private IEnumerator UpDash()
	////{
	////	Instantiate(DashAudio, transform.position, transform.rotation);
	////	Dashcooldown = 0.3f;
	////	CanDash = false;
	////	BirdShoot.isDashing = true;
	////	float originalGravity = rb.gravityScale;
	////	rb.gravityScale = 0f;
	////	rb.velocity = new Vector2(0, transform.localScale.y * 47 * EasyModBouns);
	////	tr.emitting = true;
	////	yield return new WaitForSeconds(0.15f);
	////	tr.emitting = false;
	////	rb.gravityScale = originalGravity;
	////	BirdShoot.isDashing = false;
	////}
	////
	private IEnumerator ULDash()
	{
		Dashcooldown = 0.3f;
		CanDash = false;
		BirdShoot.isDashing = true;
		float originalGravity = rb.gravityScale;
		rb.gravityScale = 0f;
		rb.velocity = new Vector2(-15 * EasyModBouns, 15 * EasyModBouns);
		tr.emitting = true;
		yield return new WaitForSeconds(0.15f);
		tr.emitting = false;
		rb.gravityScale = originalGravity;
		BirdShoot.isDashing = false;
	}
	
	private IEnumerator URDash()
	{
		Dashcooldown = 0.3f;
		CanDash = false;
		BirdShoot.isDashing = true;
		float originalGravity = rb.gravityScale;
		rb.gravityScale = 0f;
		rb.velocity = new Vector2(15 * EasyModBouns, 15 * EasyModBouns);
		tr.emitting = true;
		yield return new WaitForSeconds(0.15f);
		tr.emitting = false;
		rb.gravityScale = originalGravity;
		BirdShoot.isDashing = false;
	}
}

