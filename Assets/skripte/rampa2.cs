using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rampa2 : MonoBehaviour{
    private GameObject glavni_obj, kugla;
    private glavna_skripta gs;
    private bool samo_jednom = true;
    private int number;
    private Renderer rend;
    public int moja_boja;

    void Start()
    {
        kugla = GameObject.Find("kugla_prefab");
        glavni_obj = GameObject.Find("glavni_obj");
        gs = glavni_obj.GetComponent<glavna_skripta>();

        rend = transform.GetChild(0).GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = gs.rampa_material[gs.rampa_colors[1]];
        moja_boja = gs.rampa_colors[1];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kugla" && samo_jednom && !gs.game_over)
        {
            if (moja_boja != gs.boja_kugle) { gs.game_over = true; }
            if (!gs.game_over) { gs.chose_color(); }
            gs.u_rampi = true;
            gs.PP.transform.position = new Vector3(transform.GetChild(1).position.x, 2, transform.GetChild(1).position.z);
            gs.PP.transform.eulerAngles = transform.GetChild(1).eulerAngles;
            gs.score++;
            gs.spawn();
            //number = gs.spawn_broj(gs.score);
            gs.rampe_array[gs.spawn_broj] = Instantiate(gs.rampe_prefab, new Vector3(transform.GetChild(1).position.x, 0, transform.GetChild(1).position.z), transform.GetChild(1).rotation);
            samo_jednom = false;
            gs.ugaoPP = gs.ugaoPP - 15;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "kugla") gs.u_rampi = false;
    }


}