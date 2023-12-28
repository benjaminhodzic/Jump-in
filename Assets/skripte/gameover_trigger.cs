using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover_trigger : MonoBehaviour
{
    private GameObject glavni_obj;
    private glavna_skripta gs;
    private bool samo_jednom = true;

    void Start()
    {
        glavni_obj = GameObject.Find("glavni_obj");
        gs = glavni_obj.GetComponent<glavna_skripta>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "kugla" && samo_jednom)
        {
            gs.izvor_1.clip = gs.gameover_sound;
            if (!gs.game_over) gs.izvor_1.Play();
            gs.game_over = true;
            Debug.Log("GAMEOVER_TRIGGERRRR");
            samo_jednom = false;
        }
    }
}
