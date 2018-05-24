using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Colliders : MonoBehaviour
{

    private bool activateTimer;
    private float sec = 00;
    [SerializeField]
    public TextMeshProUGUI Timer;
    private void Update()
    {
        //Timer pour détruire le joueur quand il quite la zone de jeu 
        if (activateTimer)
        {
            sec -= Time.deltaTime;
            if (sec <= 0)
            {
                Timer.text = " ";
                Destroy(gameObject);
            }
            Timer.text = "Return to combat zone:\t " + sec.ToString("00");

        }
        //Si celui-ci reviens dans la zone le compte a rebours n'est pas completer
        else
        {
            Timer.text = " ";
            sec = 5;
        }

    }
    private void OnCollisionEnter(Collision aCol)
    {
        if (aCol.gameObject.layer == LayerMask.NameToLayer( "Fences"))
        {

            Debug.Log("oui maitre");
            aCol.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider aCol)
    {
        if (aCol.gameObject.tag == "Fences")
        {

            Debug.Log("oui maitre");
            aCol.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        //Collision qui démare le compteur
        if (aCol.gameObject.tag == "playableZone")
        {
            Debug.Log("zone");
            activateTimer = true;
            sec = 5;

        }

    }
    private void OnTriggerExit(Collider aCol)
    {
        //Collision qui annule le compte a rebours
        if (aCol.gameObject.tag == "playableZone")
        {
            activateTimer = false;
        }
    }
}
