using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prati_PP : MonoBehaviour {

    private GameObject PP;
    private GameObject glavni_obj;
    private glavna_skripta gs;


    void Start () {
        glavni_obj = GameObject.Find("glavni_obj");
        PP = GameObject.Find("PP");
        gs = glavni_obj.GetComponent<glavna_skripta>();
    }
	
	
	void Update () {
        //UnityEngine.Mathf.Round(unrounded);
        //transform.position = new Vector3(PP.transform.position.x, 0, (PP.transform.position.z + 20));
        transform.position = new Vector3(UnityEngine.Mathf.Round(PP.transform.position.x), 0, UnityEngine.Mathf.Round(PP.transform.position.z));
    }
}
