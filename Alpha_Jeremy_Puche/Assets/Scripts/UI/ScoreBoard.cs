using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{

    public TextMeshProUGUI K_P1;
    public TextMeshProUGUI K_P2;
    public TextMeshProUGUI K_P3;
    public TextMeshProUGUI K_P4;
    public TextMeshProUGUI D_P1;
    public TextMeshProUGUI D_P2;
    public TextMeshProUGUI D_P3;
    public TextMeshProUGUI D_P4;
    public TextMeshProUGUI W_P1;
    public TextMeshProUGUI W_P2;
    public TextMeshProUGUI W_P3;
    public TextMeshProUGUI W_P4;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    private void Update()
    {
        K_P1.text = P1.GetComponent<PlayerController>().m_PlayerKill.ToString();
        K_P2.text = P2.GetComponent<PlayerController>().m_PlayerKill.ToString();
        K_P3.text = P3.GetComponent<PlayerController>().m_PlayerKill.ToString();
        K_P4.text = P4.GetComponent<PlayerController>().m_PlayerKill.ToString();
        D_P1.text = P1.GetComponent<PlayerController>().m_PlayerDeath.ToString();
        D_P2.text = P2.GetComponent<PlayerController>().m_PlayerDeath.ToString();
        D_P3.text = P3.GetComponent<PlayerController>().m_PlayerDeath.ToString();
        D_P4.text = P4.GetComponent<PlayerController>().m_PlayerDeath.ToString();
        W_P1.text = GameManager.Instance.m_player1win.ToString();
        W_P2.text = GameManager.Instance.m_player2win.ToString();
        W_P3.text = GameManager.Instance.m_player3win.ToString();
        W_P4.text = GameManager.Instance.m_player4win.ToString();

    }
}

