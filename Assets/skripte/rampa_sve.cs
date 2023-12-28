using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rampa_sve : MonoBehaviour {
    private GameObject glavni_obj, kugla;
    private glavna_skripta gs;
    private bool ulaz;

    void Start()
    {
        ulaz = false;
        kugla = GameObject.Find("kugla_prefab");
        glavni_obj = GameObject.Find("glavni_obj");
        gs = glavni_obj.GetComponent<glavna_skripta>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //gs.PP.transform.position += new Vector3(0, 0, 0.05f);
        if (other.gameObject.tag == "kugla")
        {
            gs.fasteffect_canvas.enabled = true;
            gs.pozicija_ulaza_u_rampu = (Vector3.Distance(gs.PP.transform.position, gs.kugla.transform.position) - 60.75f);
            if (gs.pozicija_ulaza_u_rampu < 2.5f && gs.pozicija_ulaza_u_rampu > 0)
            {
                if (gs.perfektno < 9) { gs.perfektno++; }
                if (!gs.game_over)
                {
                    gs.izvor_1.clip = gs.fasteffect_sound;
                    gs.izvor_1.Play();
                    gs.izvor_2.clip = gs.ulaz_u_rampu_sound;
                    gs.izvor_2.Play();
                }
            }
            else { gs.perfektno = 0; }
            //kugla.GetComponent<Rigidbody>().AddForce(new Vector3(0, -500, 500));
            //kugla.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, -1500, 1000));
            ulaz = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "kugla")
        {
            if (!gs.game_over && gs.u_rampi) { gs.izvor_1.Stop(); }
            gs.pozicija_ulaza_u_rampu = -1;
            gs.fasteffect_canvas.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "kugla")
        {
            gs.kugla.GetComponent<Rigidbody>().AddRelativeForce(0, 20, 0);
        }
    }

    private void Update()
    {
       if (Vector3.Distance(transform.parent.position, gs.kugla.transform.position) > 100) Destroy(transform.parent.gameObject);
    }


}
