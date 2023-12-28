using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    private GameObject kugla, glavni_obj;
    public float brzina_kamere;
    private glavna_skripta gs;
    private float mnozitelj;

    private void Start()
    {
        brzina_kamere = 100;
        kugla = GameObject.Find("kugla_prefab");
        glavni_obj = GameObject.Find("glavni_obj");
        gs = glavni_obj.GetComponent<glavna_skripta>();
    }

    private void Update()
    {
        //if (gameObject.tag == "camera_parent")
        {
            transform.position = Vector3.Lerp(transform.position, kugla.transform.position, Time.deltaTime * brzina_kamere);
            //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, kugla.transform.eulerAngles, Time.deltaTime * brzina_kamere);
            transform.rotation = kugla.transform.rotation;
            
        }
        //if (gameObject.tag == "camera_child")
        {
            /*KORISTIO ZA PODESAVANJE Y OSE KAMERE 
            if (gs.udaljenost > 0 && gs.udaljenost < 10)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(transform.GetChild(0).transform.localPosition.x, (5f + ((4f/10f) * gs.udaljenost)), transform.GetChild(0).transform.localPosition.z); 
            }
            if (gs.udaljenost > 10 && gs.udaljenost < 30)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(transform.GetChild(0).transform.localPosition.x, 9f, transform.GetChild(0).transform.localPosition.z);
            }
            if (gs.udaljenost < 60 && gs.udaljenost > 30)
            {
                transform.GetChild(0).transform.localPosition = new Vector3(transform.GetChild(0).transform.localPosition.x, 9f - ((4f/30f) * (gs.udaljenost - 30f)), transform.GetChild(0).transform.localPosition.z);
            }
            */
        }


        {


        }






    }

}
