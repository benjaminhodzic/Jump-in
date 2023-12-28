using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocetak : MonoBehaviour {

    private GameObject glavni_obj;
    private glavna_skripta gs;


    void Start () {
        glavni_obj = GameObject.Find("glavni_obj");
        gs = glavni_obj.GetComponent<glavna_skripta>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gs.pocetak = true;
    }

    private void OnTriggerExit(Collider other)
    {
        gs.pocetak = false;
    }


}
