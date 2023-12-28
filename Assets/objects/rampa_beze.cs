using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rampa_beze : MonoBehaviour {

    public Material crvena;
    Renderer rend;


    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = crvena;
	}
	
	
	void Update () {
		
	}
}
