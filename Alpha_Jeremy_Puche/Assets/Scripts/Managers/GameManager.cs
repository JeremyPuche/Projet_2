using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    private int numberOfRounds = 0;
    public int m_player1win = 0;
    public int m_player3win = 0;
    public int m_player4win = 0;
    public int m_player2win = 0;
    public int m_player1Death = 0;
    public int m_player2Death = 0;
    public int m_player3Death = 0;
    public int m_player4Death = 0;
    public Transform m_SpawnPoint1;
    public Transform m_SpawnPoint2;
    public Transform m_SpawnPoint3;
    public Transform m_SpawnPoint4;
    public GameObject m_Player1;
    public GameObject m_Player2;
    public GameObject m_Player3;
    public GameObject m_Player4;
    public GameObject m_Player1Cam;
    public GameObject m_Player2Cam;
    public GameObject m_Player3Cam;
    public GameObject m_Player4Cam;
    private Transform m_P1InitialPositionT;
    private Transform m_P2InitialPositionT;
    private Transform m_P3InitialPositionT;
    private Transform m_P4InitialPositionT;
    private Transform m_P1InitialPositionB;
    private Transform m_P2InitialPositionB;
    private Transform m_P3InitialPositionB;
    private Transform m_P4InitialPositionB;

    public int playerNumber = 3;

    public static GameManager Instance
    {
        get; private set;
    }
    private void Awake()
    {
        m_Player1.SetActive(false);
        m_Player2.SetActive(false);
        m_Player3.SetActive(false);
        m_Player4.SetActive(false);
        playerNumber = MainMenuController.m_PlayerCount;
        numberOfRounds = MainMenuController.m_Rounds;
        Instance = this;
    }


    private void Start()
    {

        m_P1InitialPositionT = m_Player1.transform.Find("Turret").transform;
        m_P2InitialPositionT = m_Player2.transform.Find("Turret").transform;
        m_P3InitialPositionT = m_Player3.transform.Find("Turret").transform;
        m_P4InitialPositionT = m_Player4.transform.Find("Turret").transform;

        m_P1InitialPositionB = m_Player1.transform;
        m_P2InitialPositionB = m_Player2.transform;
        m_P3InitialPositionB = m_Player3.transform;
        m_P4InitialPositionB = m_Player4.transform;


        SetPlayerAmount();
    }

    public void SetPlayerAmount()
    {



        if (playerNumber == 2)
        {
            m_Player1.gameObject.SetActive(true);
            m_Player2.gameObject.SetActive(true);
            m_Player1.transform.Find("Turret").gameObject.SetActive(true);
            m_Player2.transform.Find("Turret").gameObject.SetActive(true);

            m_Player1.transform.Find("Turret").transform.position = m_P1InitialPositionT.position;
            m_Player2.transform.Find("Turret").transform.position = m_P2InitialPositionT.position;



            m_Player1.transform.Find("Turret").transform.rotation = m_P1InitialPositionT.rotation;
            m_Player2.transform.Find("Turret").transform.rotation = m_P2InitialPositionT.rotation;



            m_Player1.transform.position = m_P1InitialPositionB.position;
            m_Player2.transform.position = m_P2InitialPositionB.position;



            m_Player1.transform.rotation = m_P1InitialPositionB.rotation;
            m_Player2.transform.rotation = m_P2InitialPositionB.rotation;



            m_Player1Cam.SetActive(true);
            m_Player2Cam.SetActive(true);

            m_Player1.SetActive(true);
            m_Player1.transform.position = m_SpawnPoint1.transform.position;
            m_Player1.transform.eulerAngles = m_SpawnPoint1.transform.eulerAngles;
            m_Player2.SetActive(true);
            m_Player2.transform.position = m_SpawnPoint2.transform.position;
            m_Player2.transform.eulerAngles = m_SpawnPoint2.transform.eulerAngles;

            Rect camRect1 = m_Player1Cam.GetComponent<Camera>().rect;
            camRect1 = new Rect(0f, 0.5f, 1f, 1f);
            m_Player1Cam.GetComponent<Camera>().rect = camRect1;

            Rect camRect2 = m_Player1Cam.GetComponent<Camera>().rect;
            camRect2 = new Rect(0f, 0f, 1f, 0.5f);
            m_Player2Cam.GetComponent<Camera>().rect = camRect2;

        }
        if (playerNumber == 3)
        {
            m_Player1.gameObject.SetActive(true);
            m_Player2.gameObject.SetActive(true);
            m_Player3.gameObject.SetActive(true);
            m_Player1.transform.Find("Turret").gameObject.SetActive(true);
            m_Player2.transform.Find("Turret").gameObject.SetActive(true);
            m_Player3.transform.Find("Turret").gameObject.SetActive(true);

            m_Player1.transform.Find("Turret").transform.position = m_P1InitialPositionT.position;
            m_Player2.transform.Find("Turret").transform.position = m_P2InitialPositionT.position;
            m_Player3.transform.Find("Turret").transform.position = m_P3InitialPositionT.position;

            m_Player1.transform.Find("Turret").transform.rotation = m_P1InitialPositionT.rotation;
            m_Player2.transform.Find("Turret").transform.rotation = m_P2InitialPositionT.rotation;
            m_Player3.transform.Find("Turret").transform.rotation = m_P3InitialPositionT.rotation;


            m_Player1.transform.position = m_P1InitialPositionB.position;
            m_Player2.transform.position = m_P2InitialPositionB.position;
            m_Player3.transform.position = m_P3InitialPositionB.position;


            m_Player1.transform.rotation = m_P1InitialPositionB.rotation;
            m_Player2.transform.rotation = m_P2InitialPositionB.rotation;
            m_Player3.transform.rotation = m_P3InitialPositionB.rotation;


            m_Player1Cam.SetActive(true);
            m_Player2Cam.SetActive(true);
            m_Player3Cam.SetActive(true);
            m_Player1.SetActive(true);
            m_Player1.transform.position = m_SpawnPoint1.transform.position;
            m_Player1.transform.eulerAngles = m_SpawnPoint1.transform.eulerAngles;
            m_Player2.SetActive(true);
            m_Player2.transform.position = m_SpawnPoint2.transform.position;
            m_Player2.transform.eulerAngles = m_SpawnPoint2.transform.eulerAngles;
            m_Player3.SetActive(true);
            m_Player3.transform.position = m_SpawnPoint3.transform.position;
            m_Player3.transform.eulerAngles = m_SpawnPoint3.transform.eulerAngles;


            Rect camRect1 = m_Player1Cam.GetComponent<Camera>().rect;
            camRect1 = new Rect(0f, 0.5f, 1f, 1f);
            m_Player1Cam.GetComponent<Camera>().rect = camRect1;

            Rect camRect2 = m_Player2Cam.GetComponent<Camera>().rect;
            camRect2 = new Rect(0f, 0f, 0.5f, 0.5f);
            m_Player2Cam.GetComponent<Camera>().rect = camRect2;

            Rect camRect3 = m_Player3Cam.GetComponent<Camera>().rect;
            camRect3 = new Rect(0.5f, 0f, 0.5f, 0.5f);
            m_Player3Cam.GetComponent<Camera>().rect = camRect3;
        }
        if (playerNumber == 4)
        {
            m_Player1.gameObject.SetActive(true);
            m_Player2.gameObject.SetActive(true);
            m_Player3.gameObject.SetActive(true);
            m_Player4.gameObject.SetActive(true);
            m_Player1.transform.Find("Turret").gameObject.SetActive(true);
            m_Player2.transform.Find("Turret").gameObject.SetActive(true);
            m_Player3.transform.Find("Turret").gameObject.SetActive(true);
            m_Player4.transform.Find("Turret").gameObject.SetActive(true);

            m_Player1.transform.Find("Turret").transform.position = m_P1InitialPositionT.position;
            m_Player2.transform.Find("Turret").transform.position = m_P2InitialPositionT.position;
            m_Player3.transform.Find("Turret").transform.position = m_P3InitialPositionT.position;
            m_Player4.transform.Find("Turret").transform.position = m_P4InitialPositionT.position;

            m_Player1.transform.Find("Turret").transform.rotation = m_P1InitialPositionT.rotation;
            m_Player2.transform.Find("Turret").transform.rotation = m_P2InitialPositionT.rotation;
            m_Player3.transform.Find("Turret").transform.rotation = m_P3InitialPositionT.rotation;
            m_Player4.transform.Find("Turret").transform.rotation = m_P4InitialPositionT.rotation;

            m_Player1.transform.position = m_P1InitialPositionB.position;
            m_Player2.transform.position = m_P2InitialPositionB.position;
            m_Player3.transform.position = m_P3InitialPositionB.position;
            m_Player4.transform.position = m_P4InitialPositionB.position;

            m_Player1.transform.rotation = m_P1InitialPositionB.rotation;
            m_Player2.transform.rotation = m_P2InitialPositionB.rotation;
            m_Player3.transform.rotation = m_P3InitialPositionB.rotation;
            m_Player4.transform.rotation = m_P4InitialPositionB.rotation;

            m_Player1Cam.SetActive(true);
            m_Player2Cam.SetActive(true);
            m_Player3Cam.SetActive(true);
            m_Player4Cam.SetActive(true);
            m_Player1.SetActive(true);
            m_Player1.transform.position = m_SpawnPoint1.transform.position;
            m_Player1.transform.eulerAngles = m_SpawnPoint1.transform.eulerAngles;
            m_Player2.SetActive(true);
            m_Player2.transform.position = m_SpawnPoint2.transform.position;
            m_Player2.transform.eulerAngles = m_SpawnPoint2.transform.eulerAngles;
            m_Player3.SetActive(true);
            m_Player3.transform.position = m_SpawnPoint3.transform.position;
            m_Player3.transform.eulerAngles = m_SpawnPoint3.transform.eulerAngles;
            m_Player4.SetActive(true);
            m_Player4.transform.position = m_SpawnPoint4.transform.position;
            m_Player4.transform.eulerAngles = m_SpawnPoint4.transform.eulerAngles;

            Rect camRect1 = m_Player1Cam.GetComponent<Camera>().rect;
            camRect1 = new Rect(0f, 0.5f, 0.5f, 0.5f);
            m_Player1Cam.GetComponent<Camera>().rect = camRect1;

            Rect camRect2 = m_Player2Cam.GetComponent<Camera>().rect;
            camRect2 = new Rect(0f, 0f, 0.5f, 0.5f);
            m_Player2Cam.GetComponent<Camera>().rect = camRect2;

            Rect camRect3 = m_Player3Cam.GetComponent<Camera>().rect;
            camRect3 = new Rect(0.5f, 0f, 0.5f, 0.5f);
            m_Player3Cam.GetComponent<Camera>().rect = camRect3;

            Rect camRect4 = m_Player4Cam.GetComponent<Camera>().rect;
            camRect4 = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            m_Player4Cam.GetComponent<Camera>().rect = camRect4;
        }
    }
    public void mainMenus()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);

    }
    public void Death()
    {
        if (!m_Player1.gameObject.activeInHierarchy)
        {
            playerDeath();

            m_player1Death += 1;

        }

        if (!m_Player2.gameObject.activeInHierarchy)
        {
            playerDeath();
            m_player2Death += 1;

        }
        if (!m_Player3.gameObject.activeInHierarchy)
        {
            playerDeath();
            m_player3Death += 1;

        }
        if (!m_Player4.gameObject.activeInHierarchy)
        {
            playerDeath();
            m_player4Death += 1;

        }
    }
    public void playerDeath()
    {

        if ( m_Player1.gameObject.activeInHierarchy &&
            !m_Player2.gameObject.activeInHierarchy &&
            !m_Player3.gameObject.activeInHierarchy &&
            !m_Player4.gameObject.activeInHierarchy)
        {
            m_player1win += 1;
            Debug.Log(numberOfRounds);
            SetPlayerAmount();
            if (m_player1win == numberOfRounds)
            {
                P1.SetActive(true);

                m_Player2Cam.SetActive(false);
                m_Player3Cam.SetActive(false);
                m_Player4Cam.SetActive(false);

                Rect camRect1 = m_Player1Cam.GetComponent<Camera>().rect;
                camRect1 = new Rect(0f, 0f, 1f, 1f);
                m_Player1Cam.GetComponent<Camera>().rect = camRect1;
                Time.timeScale = 0f;
            }

        }
        if (!m_Player1.gameObject.activeInHierarchy &&
             m_Player2.gameObject.activeInHierarchy &&
            !m_Player3.gameObject.activeInHierarchy &&
            !m_Player4.gameObject.activeInHierarchy)
        {
            m_player2win += 1;
            Debug.Log(m_player2win);
            Debug.Log(numberOfRounds);
            SetPlayerAmount();
            if (m_player2win == numberOfRounds)
            {
                P2.SetActive(true);

                m_Player1Cam.SetActive(false);
                m_Player3Cam.SetActive(false);
                m_Player4Cam.SetActive(false);

                Rect camRect1 = m_Player2Cam.GetComponent<Camera>().rect;
                camRect1 = new Rect(0f, 0f, 1f, 1f);
                m_Player2Cam.GetComponent<Camera>().rect = camRect1;
                Time.timeScale = 0f;
            }

        }
        if (!m_Player1.gameObject.activeInHierarchy &&
            !m_Player2.gameObject.activeInHierarchy &&
             m_Player3.gameObject.activeInHierarchy &&
            !m_Player4.gameObject.activeInHierarchy)
        {
            m_player3win += 1;
            SetPlayerAmount();
            if (m_player3win == numberOfRounds)
            {
                P3.SetActive(true);

                m_Player1Cam.SetActive(false);
                m_Player2Cam.SetActive(false);
                m_Player4Cam.SetActive(false);

                Rect camRect1 = m_Player3Cam.GetComponent<Camera>().rect;
                camRect1 = new Rect(0f, 0f, 1f, 1f);
                m_Player3Cam.GetComponent<Camera>().rect = camRect1;
                Time.timeScale = 0f;

            }

        }
        if (!m_Player1.gameObject.activeInHierarchy &&
            !m_Player2.gameObject.activeInHierarchy &&
            !m_Player3.gameObject.activeInHierarchy &&
             m_Player4.gameObject.activeInHierarchy)
        {
            m_player4win += 1;
            SetPlayerAmount();
            if (m_player4win == numberOfRounds)
            {
                P4.SetActive(true);

                m_Player1Cam.SetActive(false);
                m_Player2Cam.SetActive(false);
                m_Player3Cam.SetActive(false);

                Rect camRect1 = m_Player4Cam.GetComponent<Camera>().rect;
                camRect1 = new Rect(0f, 0f, 1f, 1f);
                m_Player4Cam.GetComponent<Camera>().rect = camRect1;
                Time.timeScale = 0f;

            }

        }

    }

}
