using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameStop : MonoBehaviour
{
    public Text timerText;
    public static float timer;

    [Header("選單介面")]
    public GameObject Decorate;
    public GameObject BackGround;
    public GameObject MenuButton;
    public GameObject GameSetMenu;
    public GameObject OneP;
    public GameObject TwoP;
    public GameObject nextPage;
    public GameObject backPage;
    public Transform QQ;
    public Transform Player;

    //public GameObject InstructionsText;
    public static bool _GameStop;
    private bool Menu;
    private bool GameSetShow;
    private bool HowToPlayy;
    private bool HTPN;

    [Header("遊戲設定Toggle")]
    public Toggle AutoGrab;
    public Toggle DoubleInput;
    //public Toggle JumpDash;
    public Dropdown WhichFirst;
    public Toggle ScenePartical;
    public Toggle FriendMod;

    private const string AUTO_GRAB_KEY = "AutoGrab";
    private const string DOUBLE_INPUT_KEY = "DoubleInput";
    //private const string JUMP_DASH_KEY = "JumpDash";
    private const string SCENE_PARTICLE_KEY = "SceneParticle";
    private const string FRIENDLY_MOD_KEY = "FriendMod";
    [Header("Toggle文字")]
    public GameObject AutoGrabText;
    public GameObject DoubleInputText;
    //public GameObject JumpDashText;
    //public GameObject JumpDashText2;
    public Text WhichFirstTextTitle;
    public Text WhichFirstText;
    [Header("特效")]
    public Slider volumeSlider;
    public GameObject ScenePartical1;
    public GameObject ScenePartical2;
    private GameObject[] LightPartical;

    public static float volume = 0.5f;
    private Color gray;
    private Color white;
    public Animator SManim;
    //private bool ITShow;
    // Start is called before the first frame update
    void Awake()
    {
        //DontDestroyOnLoad(timerText);
    }

    void Start()
    {
        AutoGrab.isOn = true;
        DoubleInput.isOn = true;
        //JumpDash.isOn = true;
        ScenePartical.isOn = true;
        FriendMod.isOn = true;
        WhichFirst.ClearOptions();
        WhichFirst.AddOptions(new List<string> { "絕對向上", "上鍵優先", "左、右鍵優先" });

        // 設定Dropdown的初始值
        WhichFirst.value = PlayerPrefs.GetInt("DropdownValue", 0);

        // 設定Dropdown的事件
        WhichFirst.onValueChanged.AddListener(OnDropdownValueChanged);

        white = new Color(1, 1, 1, 1);
        gray = new Color(0.7f, 0.7f, 0.7f, 1);
        volumeSlider.value = volume;
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        AudioListener.volume = volume * 5;

        LightPartical = GameObject.FindGameObjectsWithTag("WallLight");
        _GameStop = false;
        //ITShow = false;

        // 載入儲存的 toggle 狀態
        //JumpDash.isOn = PlayerPrefs.GetInt(JUMP_DASH_KEY, 0) == 1;
        AutoGrab.isOn = PlayerPrefs.GetInt(AUTO_GRAB_KEY, 0) == 1;
        DoubleInput.isOn = PlayerPrefs.GetInt(DOUBLE_INPUT_KEY, 0) == 1;
        ScenePartical.isOn = PlayerPrefs.GetInt(SCENE_PARTICLE_KEY, 0) == 1;
        FriendMod.isOn = PlayerPrefs.GetInt(FRIENDLY_MOD_KEY, 0) == 1;

        // 註冊事件監聽器，監聽 toggle 狀態變化
        //JumpDash.onValueChanged.AddListener(OnJumpDashToggleChanged);
        AutoGrab.onValueChanged.AddListener(OnAutoGrabToggleChanged);
        DoubleInput.onValueChanged.AddListener(OnDoubleInputToggleChanged);
        ScenePartical.onValueChanged.AddListener(OnSceneParticleToggleChanged);
        FriendMod.onValueChanged.AddListener(OnFriendModToggleChanged);
    }

    // Update is called once per frame
    void Update()
    {
        timerr();
        GameOption();

        if (Input.GetButtonDown("Cancel"))
        {
            if (!_GameStop)
            {
                _GameStop = true;
                Menu = true;
            }
            else if (_GameStop && !GameSetShow)
            {
                _GameStop = false;
            }
            else if (_GameStop && GameSetShow)
            {
                Menu = true;
                GameSetShow = false;
            }
        }

        if (_GameStop)
        {
            SManim.SetBool("openB", true);
            Decorate.SetActive(true);
            BackGround.SetActive(true);
            Time.timeScale = 0;
            if (Menu)
            {
                MenuButton.SetActive(true);
            }
        }
        else
        {
            SManim.SetBool("openB", false);
            Decorate.SetActive(false);
            BackGround.SetActive(false);
            MenuButton.SetActive(false);
            Menu = false;
            GameSetShow = false;
            HowToPlayy = false;
            Time.timeScale = 1;
        }

        if (Menu)
        {
            OneP.SetActive(false);
            TwoP.SetActive(false);
            nextPage.SetActive(false);
            backPage.SetActive(false);
            GameSetShow = false;
            HowToPlayy = false;
            MenuButton.SetActive(true);
            GameSetMenu.SetActive(false);
            SManim.SetBool("openGS", false);
            SManim.SetBool("openB", true);
            OneP.SetActive(false);
            TwoP.SetActive(false);
            nextPage.SetActive(false);
            backPage.SetActive(false);
        }

        if (GameSetShow)
        {
            Menu = false;
            MenuButton.SetActive(false);
            GameSetMenu.SetActive(true);
            SManim.SetBool("openGS", true);
            SManim.SetBool("openB", false);
        }

        if (HowToPlayy)
        {
            Menu = false;
            Decorate.SetActive(false);
            MenuButton.SetActive(false);
            if (!HTPN)
            {
                OneP.SetActive(true);
                TwoP.SetActive(false);
                nextPage.SetActive(true);
                backPage.SetActive(false);
            }
            else
            {
                OneP.SetActive(false);
                TwoP.SetActive(true);
                nextPage.SetActive(false);
                backPage.SetActive(true);
            }
        }
        else
        {
            OneP.SetActive(false);
            TwoP.SetActive(false);
            nextPage.SetActive(false);
            backPage.SetActive(false);
        }

        //if (ITshow)
        //{
        //    MenuButton.SetActive(false);
        //    InstructionsText.SetActive(true);
        //}
    }

    public void EscButton()
    {
        if (!_GameStop)
        {
            _GameStop = true;
            Menu = true;
        }
        else if (_GameStop && !GameSetShow && !HowToPlayy)
        {
            _GameStop = false;
        }
        else if (_GameStop && GameSetShow && !HowToPlayy)
        {
            Menu = true;
            GameSetShow = false;
        }
        else if (_GameStop && !GameSetShow && HowToPlayy)
        {
            Menu = true;
            HowToPlayy = false;
        }
    }

    private void timerr()
    {
        if (NewMainScene.nextLevel && !END.isEND)
        {
            if (timer >= 0)
            {
                timer += Time.deltaTime;
                DisplayTime(timer);
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Continue()
    {
        _GameStop = false;
    }

    public void Restart()
    {
        PlayerControl.Dead = true;
        if (QQ != null && Player != null)
        {
            QQ.position = Player.position;
        }
        BirdShoot.touchbird = false;
        _GameStop = false;
    }

    public void GameSet()
    {
        GameSetShow = true;
        Menu = false;
    }

    public void HowToPlay()
    {
        HowToPlayy = true;
        Menu = false;
    }

    public void NextPage()
    {
        HTPN = true;
    }

    public void BackPage()
    {
        HTPN = false;
    }

    //public void Instructions()
    //{
    //    ITShow = true;
    //}

    public void Exit()
    {
        Application.Quit();
    }

    void OnVolumeSliderChanged(float value)
    {
        volume = value; // 將AudioListener的volume屬性設為Slider的值
        AudioListener.volume = value*5;
        //PlayerPrefs.Save();
    }

    //private void OnSceneChange()
    //{
    //    PlayerPrefs.SetFloat("volume", volume);
    //}

    //private void OnNewSceneLoaded()
    //{
    //    volume = PlayerPrefs.GetFloat("volume", 1f);
    //    AudioListener.volume = volume;
    //    volumeSlider.value = volume;
    //}

    private void OnAutoGrabToggleChanged(bool isOn)
    {
        // 儲存 toggle 狀態
        PlayerPrefs.SetInt(AUTO_GRAB_KEY, isOn ? 1 : 0);
    }

    private void OnDoubleInputToggleChanged(bool isOn)
    {
        // 儲存 toggle 狀態
        PlayerPrefs.SetInt(DOUBLE_INPUT_KEY, isOn ? 1 : 0);
    }

    //private void OnJumpDashToggleChanged(bool isOn)
    //{
    //    // 儲存 toggle 狀態
    //    PlayerPrefs.SetInt(JUMP_DASH_KEY, isOn ? 1 : 0);
    //}

    private void OnSceneParticleToggleChanged(bool isOn)
    {
        // 儲存 toggle 狀態
        PlayerPrefs.SetInt(SCENE_PARTICLE_KEY, isOn ? 1 : 0);
    }

    private void OnFriendModToggleChanged(bool isOn)
    {
        // 儲存 toggle 狀態
        PlayerPrefs.SetInt(FRIENDLY_MOD_KEY, isOn ? 1 : 0);
    }

    void GameOption()
    {
        //if (AutoGrab.isOn)
        //{
        //    PlayerControl.AutoGrabWall = true;
        //    AutoGrabText.SetActive(false);
        //}
        //else
        //{
        //    PlayerControl.AutoGrabWall = false;
        //    AutoGrabText.SetActive(true);
        //}

        if (DoubleInput.isOn)
        {
            PlayerControl.doubleArrow = true;
            DoubleInputText.SetActive(true);
        }
        else
        {
            PlayerControl.doubleArrow = false;
            DoubleInputText.SetActive(false);
        }

        //if (JumpDash.isOn)
        //{
        //    PlayerControl.JumpKeyDash = true;
        //    JumpDashText.SetActive(true);
        //    JumpDashText2.SetActive(true);
        //    WhichFirst.interactable = true;
        //    WhichFirstTextTitle.color = white;
        //    WhichFirstText.color = white;
        //    //if (WhichFirst.isOn)
        //    //{
        //    //    PlayerControl.UpFirst = true;
        //    //    WhichFirstText.text = "例: 上+右鍵一起按，優先執行 上 衝刺";
        //    //}
        //    //else
        //    //{
        //    //    PlayerControl.UpFirst = false;
        //    //    WhichFirstText.text = "例: 上+右鍵一起按，優先執行 右 衝刺";
        //    //}
        //}
        //else
        //{
        //    PlayerControl.JumpKeyDash = false;
        //    JumpDashText.SetActive(false);
        //    JumpDashText2.SetActive(false);
        //    WhichFirst.interactable = false;
        //    WhichFirstTextTitle.color = gray;
        //    WhichFirstText.color = gray;
        //}

        if (ScenePartical.isOn)
        {
            if (ScenePartical1 != null)
            {
                ScenePartical1.SetActive(true);
            }
            if (ScenePartical2 != null)
            {
                ScenePartical2.SetActive(true);
            }
            if (LightPartical != null)
            {
                for (int i = 0; i < LightPartical.Length; i++)
                {
                    LightPartical[i].SetActive(true);
                }
            }
        }
        else
        {
            if (ScenePartical1 != null)
            {
                ScenePartical1.SetActive(false);
            }
            if (ScenePartical2 != null)
            {
                ScenePartical2.SetActive(false);
            }
            if (LightPartical != null)
            {
                for (int i = 0; i < LightPartical.Length; i++)
                {
                    LightPartical[i].SetActive(false);
                }
            }
        }

        if (FriendMod.isOn)
        {
            PlayerControl.EasyMod = true;
        }
        else
        {
            PlayerControl.EasyMod = false;
        }
    }

    public void OnDropdownValueChanged(int value)
    {
        // 儲存Dropdown的值
        PlayerPrefs.SetInt("DropdownValue", value);
        PlayerPrefs.Save();

        // 根據不同的值執行不同的操作
        switch (value)
        {
            case 0:
                WhichFirstText.text = "例: 按住上+右or右，第二段跳躍向 上 衝刺";
                PlayerControl.AlwaysUp = true;
                break;
            case 1:
                WhichFirstText.text = "例: 按住上+右，第二段跳躍向 上 衝刺";
                PlayerControl.AlwaysUp = false;
                PlayerControl.UpFirst = true;
                break;
            case 2:
                WhichFirstText.text = "例: 按住上+右，第二段跳躍向 右 衝刺";
                PlayerControl.AlwaysUp = false;
                PlayerControl.UpFirst = false;
                break;
        }
    }
}
