using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spawn_podlogu : MonoBehaviour {
    private GameObject glavni_obj;
    private glavna_skripta gs;
    public GameObject platforma;
    private Vector3 naprijed, nazad, lijevo, desno, pozicija_kugle;
    private int obj_destroy;
    public bool izbrisi_platforme = false;

    void Start () {
        glavni_obj = GameObject.Find("glavni_obj");
        gs = glavni_obj.GetComponent<glavna_skripta>();

        {
            naprijed = (transform.position + new Vector3(0, 0, 400));
            nazad = transform.position + new Vector3(0, 0, -400);
            desno = transform.position + new Vector3(400, 0, 0);
            lijevo = transform.position + new Vector3(-400, 0, 0);
        }

    }
	
	
	void Update () {
        pozicija_kugle = gs.kugla.transform.position;
        int blizina_reagovanja = 500;
        if ((Vector3.Distance(pozicija_kugle, naprijed) < blizina_reagovanja) && provjera_ispravnosti(naprijed)) { Instantiate(platforma, naprijed , platforma.transform.rotation); gs.platforme[array_broj_fun()] = naprijed; gs.broj_platformi++; }
        if ((Vector3.Distance(pozicija_kugle, nazad) < blizina_reagovanja) && provjera_ispravnosti(nazad)) { Instantiate(platforma, nazad , platforma.transform.rotation); gs.platforme[array_broj_fun()] = nazad; gs.broj_platformi++; }
        if ((Vector3.Distance(pozicija_kugle, lijevo) < blizina_reagovanja) && provjera_ispravnosti(lijevo)) { Instantiate(platforma, lijevo , platforma.transform.rotation); gs.platforme[array_broj_fun()] = lijevo; gs.broj_platformi++; }
        if ((Vector3.Distance(pozicija_kugle, desno) < blizina_reagovanja) && provjera_ispravnosti(desno)) { Instantiate(platforma, desno , platforma.transform.rotation); gs.platforme[array_broj_fun()] = desno; gs.broj_platformi++; }
        if (Vector3.Distance(pozicija_kugle, transform.position) > 500) {
            for (int n = 0; n < 10; n++)
            {
                if (transform.position == gs.platforme[n]) { gs.platforme[n] = new Vector3(-1, -1, -1); }
            }
            Destroy(gameObject);
        }
        //Debug.Log(Vector3.Distance(pozicija_kugle, desno));
        //if (izbrisi_platforme == true) { Destroy(gameObject); }
    }

    bool provjera_ispravnosti(Vector3 pozicija)
    {
        //Debug.Log(pozicija + "  " + gs.platforme[0]);
        bool rezultat = true;
        if (pozicija == gs.platforme[0]) { rezultat = false; }
        if (pozicija == gs.platforme[1]) { rezultat = false; }
        if (pozicija == gs.platforme[2]) { rezultat = false; }
        if (pozicija == gs.platforme[3]) { rezultat = false; }
        if (pozicija == gs.platforme[4]) { rezultat = false; }
        if (pozicija == gs.platforme[5]) { rezultat = false; }
        if (pozicija == gs.platforme[6]) { rezultat = false; }
        if (pozicija == gs.platforme[7]) { rezultat = false; }
        if (pozicija == gs.platforme[8]) { rezultat = false; }
        if (pozicija == gs.platforme[9]) { rezultat = false; }
        return rezultat;
    }

    int array_broj_fun()
    { 
        gs.array_broj++;
        if (gs.array_broj == 10) gs.array_broj = 0;

        return gs.array_broj;
    }

    int spremi_platformu()
    {
        if (gs.array_broj % 2 == 0) { return 0; }
        else { return 1; }
    }



}
