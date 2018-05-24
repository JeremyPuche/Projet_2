using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Rigidbody m_Rigidbody;
    private Vector3 m_InitialRotation;

    public float m_Speed = 500f;
    public float m_Distance = 00;

    public int m_PlayerIndex;
    private bool m_Collided = false;



    private void FixedUpdate()
    {
        //Timeur pour détruire les balles a lexterieur de la zone de jeu
        m_Distance += Time.fixedDeltaTime;
        if (m_Distance >= 7f)
        {
            Destroy(gameObject);
        }
        //Déplacement des balles une fois tirer
        m_Rigidbody.velocity = transform.up * m_Speed * Time.fixedDeltaTime;

    }
    private void OnTriggerEnter(Collider aCol)
    {



        if (aCol.gameObject.tag == "Player1" && !m_Collided)
        {


            m_Collided = true;
            aCol.gameObject.GetComponentInParent<PlayerController>().ReceiveDmg(m_PlayerIndex);

            Destroy(gameObject);

        }
        if (aCol.gameObject.tag == "Player2" && !m_Collided)
        {


            m_Collided = true;
            aCol.gameObject.GetComponentInParent<PlayerController>().ReceiveDmg(m_PlayerIndex);

            Destroy(gameObject);

        }
        if (aCol.gameObject.tag == "Player3" && !m_Collided)
        {


            m_Collided = true;
            aCol.gameObject.GetComponentInParent<PlayerController>().ReceiveDmg(m_PlayerIndex);

            Destroy(gameObject);

        }
        if (aCol.gameObject.tag == "Player4" && !m_Collided)
        {


            m_Collided = true;
            aCol.gameObject.GetComponentInParent<PlayerController>().ReceiveDmg(m_PlayerIndex);

            Destroy(gameObject);

        }

        if (aCol.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        Debug.Log(aCol.gameObject.name);

    }
    private void OnCollisionEnter(Collision aCol)
    {


    }


}
