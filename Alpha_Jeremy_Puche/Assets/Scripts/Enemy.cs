using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float m_Speed = 2f;
    public int Hp = 3;
    public Rigidbody m_Rigidbody;
    public float radius = 5.0F;
    public float power = 100.0F;
    public float rotSpeed = 50f;
    private bool death = false;
    private float time = 00f;

    public void ReceiveDmg()
    {
        Hp -= 1;
        Vector3 explosionPos = transform.position;

        if (m_Rigidbody != null && Hp <= 0)
        {
            power = 500f;
            death = true;
            
        }
        m_Rigidbody.AddExplosionForce(power, explosionPos, radius, 3.0F);
    }
    
    

   
    void FixedUpdate()

    {
        if (death)
        {
            time += Time.deltaTime;
            if (time >= 4)
            {
                Destroy(gameObject);
            }

        }

        //Deplacement del'enemie avec fleche du haut, bas, droite et gauche
        if (Input.GetKey(KeyCode.UpArrow))
        {
        
            transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * m_Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Rotate(Vector3.up, -rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
        }

    }
    
}
