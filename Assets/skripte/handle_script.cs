using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle_script : MonoBehaviour
{
    private Vector3 pocetna_pozicija, poz_1, poz1, trenutna_pozicija;
    public float hs_axis = 10;
    private GameObject glavni_obj;
    private glavna_skripta gs;

    void Start()
    {
        glavni_obj = GameObject.Find("glavni_obj");
        gs = glavni_obj.GetComponent<glavna_skripta>();

        pocetna_pozicija = gameObject.GetComponent<RectTransform>().localPosition;
        poz1 = pocetna_pozicija + new Vector3(115, 0, 0);
        poz_1 = pocetna_pozicija - new Vector3(115, 0, 0);
    }

    
    void Update()
    {
        trenutna_pozicija = gameObject.GetComponent<RectTransform>().localPosition;
        gs.hs_axiss = trenutna_pozicija.x * (1f / 117f);
        //Debug.Log(hs_axis);
    }
}
