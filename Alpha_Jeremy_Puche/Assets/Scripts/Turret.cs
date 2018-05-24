using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{

    public GameObject Camera;
    public GameObject Base;
  
    public Vector3 m_Rotation = new Vector3();
    
  

    private void Update()
    {
        
        Quaternion m_Rotation = Quaternion.Euler(Camera.transform.eulerAngles.x + 13, Camera.transform.eulerAngles.y, 0); 
        transform.rotation = m_Rotation;
       

    }
   

}
