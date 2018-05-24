using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBars : MonoBehaviour
{


    [SerializeField]
    private List<GameObject> HpBar;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject m_Player_Enemy;
    private Vector3 lookPosition;
    private float m_CurrentHp;

    private void Start()
    {


    }

    void FixedUpdate()
    {
        m_CurrentHp = Player.GetComponent<PlayerController>().m_Hp;
        for (int i = 0; i < HpBar.Count; i++)
        {
            if (m_Player_Enemy != null)
            {
                lookPosition.x = m_Player_Enemy.transform.position.x;
                lookPosition.y = transform.position.y;
                lookPosition.z = m_Player_Enemy.transform.position.z;
                HpBar[i].transform.LookAt(lookPosition);
                HpBar[i].SetActive(false);
                if (i == m_CurrentHp)
                {
                    HpBar[i].SetActive(true);
                }

            }


        }


    }
}
