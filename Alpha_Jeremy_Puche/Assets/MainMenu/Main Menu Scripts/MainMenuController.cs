using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    Animator anim;

    public AudioSource m_Audio;
    public string newGameSceneName;
    public int quickSaveSlotID;

    [Header("Options Panel")]
    public GameObject MainOptionsPanel;
    public GameObject StartGameOptionsPanel;
    public GameObject LevelSelectPanel;
    public static int m_PlayerCount;
    public static int m_Rounds ;

    public GameObject GamePanel;
    public GameObject ControlsPanel;
    public GameObject GfxPanel;
    public GameObject LoadGamePanel;
    //public GameObject EmptySprite;
    // public GameObject SurviveSprite;
    // public GameObject BuildSprite;
    public GameObject EventSystem_Main;
    public GameObject EventSystem_Start;
    public GameObject EventSystem_Back;
    public GameObject EventSystem_Pause;

    public GameObject menuPause;



    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();

        //new key
        PlayerPrefs.SetInt("quickSaveSlot", quickSaveSlotID);
    }

    #region Open Different panels

    public void resumeGame()
    {
        menuPause.SetActive(false);
        EventSystem_Pause.SetActive(true);
        EventSystem_Main.SetActive(false);
        Time.timeScale = 1f;
    }
    public void openOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(true);
        StartGameOptionsPanel.SetActive(false);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();


        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    }

    public void openStartGameOptions()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);
        StartGameOptionsPanel.SetActive(true);
        EventSystem_Main.SetActive(false);
        EventSystem_Start.SetActive(true);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();
        
        //GameManager.Instance.OnePlayer();
        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    }
    public void openLevelSelect()
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);
        StartGameOptionsPanel.SetActive(false);
        LevelSelectPanel.SetActive(true);
        EventSystem_Main.SetActive(false);
        EventSystem_Start.SetActive(true);

        //play anim for opening main options panel
        anim.Play("OptTweenAnim_on");
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();
       
        //GameManager.Instance.OnePlayer();
        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");
    }


    
    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

    public void openOptions_Game()
    {
        //enable respective panel
        GamePanel.SetActive(true);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(false);
        LoadGamePanel.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }
    public void openOptions_Controls()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(true);
        GfxPanel.SetActive(false);
        LoadGamePanel.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }
    public void openOptions_Gfx()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(true);
        LoadGamePanel.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }

    public void openContinue_Load()
    {
        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(false);
        LoadGamePanel.SetActive(true);
        EventSystem_Back.SetActive(true);
        EventSystem_Start.SetActive(false);
        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }

    public void newGame2v2()
    {
        m_PlayerCount = 2;
        openLevelSelect();
       
    }
    public void newGame3v3()
    {
        m_PlayerCount = 3;
        openLevelSelect();

    }
    public void newGame4v4()
    {
        m_PlayerCount = 4;
        openLevelSelect();
       
    }
    public void Bo1()
    {
        m_Rounds = 1;
        if (!string.IsNullOrEmpty("scene"))
            SceneManager.LoadScene("scene");
        else
            Debug.Log("Please write a scene name in the 'newGameSceneName' field of the Main Menu Script and don't forget to " +
                "add that scene in the Build Settings!");
    }
    public void Bo2()
    {
        m_Rounds = 2;
        if (!string.IsNullOrEmpty("scene"))
            SceneManager.LoadScene("scene");
        else
            Debug.Log("Please write a scene name in the 'newGameSceneName' field of the Main Menu Script and don't forget to " +
                "add that scene in the Build Settings!");
    }
    public void Bo4()
    {
        m_Rounds = 4;
        if (!string.IsNullOrEmpty("scene"))
            SceneManager.LoadScene("scene");
        else
            Debug.Log("Please write a scene name in the 'newGameSceneName' field of the Main Menu Script and don't forget to " +
                "add that scene in the Build Settings!");
    }
    #endregion

    #region Back Buttons

    public void back_options()
    {
        //simply play anim for CLOSING main options panel
        anim.Play("buttonTweenAnims_off");
        EventSystem_Main.SetActive(true);
        EventSystem_Start.SetActive(false);
        //disable BLUR
        // Camera.main.GetComponent<Animator>().Play("BlurOff");

        //play click sfx
        playClickSound();
    }

    public void back_options_panels()
    {
        //simply play anim for CLOSING main options panel
        anim.Play("OptTweenAnim_off");
        EventSystem_Back.SetActive(false);
        EventSystem_Start.SetActive(true);
        //play click sfx
        playClickSound();

    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Sounds
    public void playHoverClip()
    {
       
    }

    void playClickSound()
    {
      //m_Audio.Play();
    }


    #endregion
}
