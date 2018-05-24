using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStart : MonoBehaviour {

    public GameObject turret;
	
	void Update () {
        transform.position = turret.transform.position;
        transform.eulerAngles = turret.transform.eulerAngles;
	}
}
