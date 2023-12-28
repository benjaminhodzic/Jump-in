using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prati_kuglu : MonoBehaviour {
    private GameObject kugla;

    private void Start()
    {
        kugla = GameObject.Find("kugla_prefab");
    }

    void Update () {
        transform.position = kugla.transform.position;
	}
}
