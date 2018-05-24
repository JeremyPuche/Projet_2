using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{


    public Vector3 m_InitialPosition;
    public Transform m_BulletSpawnPoint;
    

    [Range(1, 4)]
    public int m_PlayerIndex;
    public int m_PlayerKill;
    public int m_PlayerDeath;
    public int m_Hp = 3;

    public bool m_CanShoot;
    public bool m_Death = false;

    [SerializeField]
    private float m_CurrentSpeed;
    public float m_Speed = 2f;
    public float m_RotSpeed = 50f;
    public float m_Acceleration = 3f;
    public float m_Decceleration = 3f;
    public float m_Power = 100.0F;
    public float m_UiHpScale = 0f;
    public float m_Radius = 5.0F;
    private float m_Shoot = 00;
    private float m_Time = 0f;

    public Slider m_Slider;
    public Image Healt;

    public GameObject scoreBoard;
    public GameObject muzzleFlash;
    public GameObject m_Bullet;
    public GameObject explosion;
    public GameObject Cam;
    public GameObject Death;
    public GameObject initialFollow;
    public GameObject initialLookAt;

    private float m_InputZ = 0;

    public static PlayerController Instance
    {
        get; private set;
    }
    private void Awake()
    {
        Instance = this;
        m_UiHpScale += 0.976f;
    }


    public void ReceiveDmg(int fromPlayer)
    {

        m_Hp -= 1;
        Vector3 explosionPos = transform.position;
        m_UiHpScale -= 0.33f;
        Healt.transform.localScale = new Vector3(m_UiHpScale, 0.8193191f, 0.8958579f);
        if (Healt.transform.localScale.x <= 0f)
        {
            Healt.transform.localScale = new Vector3(0f, 0.8193191f, 0.8958579f);
        }
        if (m_Hp <= 0)
        {
            GameObject fromPlayers;
            fromPlayers = GameObject.Find("Base" + fromPlayer.ToString());
            PlayerController fromPlayerScript = fromPlayers.GetComponent<PlayerController>();
            if (fromPlayerScript != null)
            {
                fromPlayerScript.m_PlayerKill += 1;
            }

            m_Power = 450f;
            m_Death = true;
            explosion.GetComponent<ParticleSystem>().Play();

        }

        gameObject.GetComponent<Rigidbody>().AddExplosionForce(m_Power, explosionPos, m_Radius, 6.0F);
        m_Power = 100f;
    }

    void Start()
    {

        m_InitialPosition = transform.position;
    }
    private void FixedUpdate()
    {
        if (Input.GetAxis("LeftJ_Vertical" + m_PlayerIndex) != 0 || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {

            transform.Translate(Vector3.forward * m_CurrentSpeed * Time.deltaTime);
        }




        if (Input.GetKey(KeyCode.A) || Input.GetAxis("LeftJ_Horizontal" + m_PlayerIndex) > 0)
        {

            transform.Rotate(Vector3.up, -m_RotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("LeftJ_Horizontal" + m_PlayerIndex) < 0)
        {

            transform.Rotate(Vector3.up, m_RotSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetButtonDown("Select_Buton" + m_PlayerIndex.ToString()))
        {
            scoreBoard.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab) || Input.GetButtonUp("Select_Buton" + m_PlayerIndex.ToString()))
        {
            scoreBoard.SetActive(false);
        }
    }




    private void Update()
    {

        m_InputZ = Input.GetAxis("LeftJ_Vertical" + m_PlayerIndex);
        if (CheckInputAxis() == 1)
        {

            //Ici ont incrémente la vitess selon l'acceleration;
            if (m_CurrentSpeed < m_Speed)
            {
                m_CurrentSpeed += m_Speed * (m_Acceleration * Time.deltaTime);
            }
        }
        if (CheckInputAxis() == -1)
        {

            //Ici ont incrémente la vitess selon l'acceleration;
            if (m_CurrentSpeed > -m_Speed)
            {
                m_CurrentSpeed -= m_Speed * (m_Acceleration * Time.deltaTime);
            }
        }
        if (CheckInputAxis() == 0)
        {

            if (m_CurrentSpeed > 0.2f)
            {
                m_CurrentSpeed -= m_Speed * (m_Decceleration * Time.deltaTime);
            }
            else if (m_CurrentSpeed < -0.2f)
            {
                m_CurrentSpeed += m_Speed * (m_Decceleration * Time.deltaTime);
            }
            else
            {
                m_CurrentSpeed = 0f;
            }

        }

        if (m_Death)
        {

            m_Time += Time.deltaTime;
            if (m_Time >= 1.5f)
            {
                m_PlayerDeath += 1;
                Death.SetActive(true);
                Cam.GetComponent<Cinemachine.CinemachineFreeLook>().Follow = Death.transform;
                Cam.GetComponent<Cinemachine.CinemachineFreeLook>().LookAt = Death.transform;
                transform.Find("Turret").gameObject.SetActive(false);
                gameObject.SetActive(false);
                GameManager.Instance.Death();
                m_Death = false;
                m_Time = 0;
                m_Hp = 3;
                Cam.GetComponent<Cinemachine.CinemachineFreeLook>().Follow = initialFollow.transform;
                Cam.GetComponent<Cinemachine.CinemachineFreeLook>().LookAt = initialLookAt.transform;
                m_UiHpScale += 0.976f;
                Healt.transform.localScale = new Vector3(m_UiHpScale, 0.8193191f, 0.8958579f);

            }

        }
        //Limit de tire par minute ou action de recharger


        if (!m_CanShoot)
            m_Shoot += Time.deltaTime;

        if (m_Shoot >= 2)
        {
            muzzleFlash.SetActive(false);
            m_CanShoot = true;
            m_Shoot = 0f;
        }

        if (m_CanShoot)
        {
            //Tirer
            if (Input.GetMouseButton(0) || Input.GetButtonDown("RightJ_Trigger" + m_PlayerIndex))
            {

                m_CanShoot = false;
                muzzleFlash.SetActive(true);
                GameObject projectile = Instantiate(m_Bullet, m_BulletSpawnPoint.position, m_BulletSpawnPoint.rotation);
                Projectile script = projectile.GetComponent<Projectile>();
                if (script != null)
                {
                    script.m_PlayerIndex = m_PlayerIndex;
                }


            }

        }
        else if (m_CanShoot == false)
        {
            m_Slider.value = m_Shoot;
        }




        transform.Translate(Vector3.forward * m_CurrentSpeed * Time.deltaTime);

    }

    private int CheckInputAxis()
    {
        if (m_InputZ < 0 || Input.GetKey(KeyCode.S))
        {
            return -1;
        }
        else if (m_InputZ > 0 || Input.GetKey(KeyCode.W))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }


}
