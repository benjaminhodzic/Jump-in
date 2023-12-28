using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce_collider : MonoBehaviour {
    private GameObject kugla;

    private void Start()
    {
        kugla = GameObject.Find("kugla_prefab");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kugla")
        {
            //kugla.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, -100, 0));
        }
    }
}
