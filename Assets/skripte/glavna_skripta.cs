using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;


public class glavna_skripta : MonoBehaviour
{
    private GameObject no_move_zona, rampe;
    public GameObject PP, rampe_prefab, pr_prefab, kugla, platforma;
    /// <summary> boje rampe random
    public int[] rampa_colors = new int[5];
    public int boja_kugle;
    /// </summary>
    public float udaljenost, brzina_kretanja, brzina_okretanja;
    public bool pocetak, u_rampi, game_over, izbrisi_platforme = false;
    public GameObject[] rampe_array = new GameObject[3];
    public int score, array_broj = 0, broj_platformi = 0;
    public bool restart;
    public int broj_provjere, spawn_broj, destroy_broj;
    private bool previseL, previseD;
    public float ugaoPP, ugaoK, euler_ugao;
    private float dodatna_visina;
    public float brzina_padanja, brzina_dizanja;
    public Material[] rampa_material = new Material[5];
    public Renderer rend_kugla;
    private Color[] boje_kod = new Color[5];
    public Vector3[] platforme = new Vector3[10];
    //public GameObject[] platforme_obj = new GameObject[2];
    public spawn_podlogu sp;
    public GameObject[] names;

    public float hs_axiss;
    public bool up_press;
    private float vrijeme_start;

    private int trenutni_score;
    public Canvas menu_canvas, upravljanje_canvas, fade_canvas, fasteffect_canvas, score_canvas, upitnik_canvas;
    public Image fade_image;
    public Camera main_camera;
    private bool namjesti_kameru_bool, kugla_se_krece, samo_jednom_gameover;
    public float pozicija_ulaza_u_rampu, screen_score;
    public int perfektno;
    private Color zeljena_boja;
    private bool zeljena_boja_bool;

    public AudioSource izvor_1;
    public AudioSource izvor_2;
    public AudioClip fasteffect_sound;
    public AudioClip ulaz_u_rampu_sound;
    public AudioClip gameover_sound;
    public AudioClip playgame_sound;
    public AudioClip background_music;
    public AudioClip up_sound;



    void Start()
    {
        //PlayerPrefs.SetInt("last_score", 0);
        //PlayerPrefs.SetInt("best_score", 0);

        fade_canvas.enabled = transform;
        //print(Screen.currentResolution);
        sp = platforma.GetComponent<spawn_podlogu>();
        game_over = true;
        //kugla = GameObject.Find("kugla_prefab");
        no_move_zona = GameObject.Find("no_move_zona");
        rampe = GameObject.Find("rampe");
        PP = GameObject.Find("PP");
        kugla.transform.eulerAngles = new Vector3(0, 0, 0);
        //Physics.gravity = new Vector3(0, brzina_padanja, 0);
        //rend_kugla = kugla.GetComponent<Renderer>();

        {
            boje_kod[0] = new Color(250 / 255f, 44 / 255f, 44 / 255f);
            boje_kod[1] = new Color(192 / 255f, 3 / 255f, 255 / 255f);
            boje_kod[2] = new Color(255 / 255f, 179 / 255f, 2 / 255f);
            boje_kod[3] = new Color(32 / 255f, 2 / 255f, 255 / 255f);
            boje_kod[4] = new Color(45 / 255f, 255 / 255f, 3 / 255f);
        }
        StartCoroutine(restart_game());
    }

    private void Update()
    {
        if (game_over) { udaljenost = 0; }
        if (pozicija_ulaza_u_rampu > 0 && pozicija_ulaza_u_rampu < 2.5 && !game_over && kugla_se_krece && u_rampi) { fasteffect_canvas.enabled = true; } else { fasteffect_canvas.enabled = false; }
        Physics.gravity = new Vector3(0, brzina_padanja * -1, 0);
        if (ugaoK < 0) euler_ugao = (360f + ugaoK);
        if (ugaoK > 0) euler_ugao = ugaoK;
        //Debug.Log(hs_axiss);
        if (kugla_se_krece)
        {

            if (!pocetak && !previseD && hs_axiss > 0) { kugla.transform.eulerAngles += new Vector3(0, brzina_okretanja * hs_axiss * 1000 * Time.deltaTime, 0); }
            if (!pocetak && !previseL && hs_axiss < 0) { kugla.transform.eulerAngles += new Vector3(0, brzina_okretanja * hs_axiss * 1000 * Time.deltaTime, 0); }

            if (!pocetak && !previseD && Input.GetAxis("Horizontal") > 0) { kugla.transform.eulerAngles += new Vector3(0, brzina_okretanja * Input.GetAxis("Horizontal") * 1000 * Time.deltaTime, 0); }
            if (!pocetak && !previseL && Input.GetAxis("Horizontal") < 0) { kugla.transform.eulerAngles += new Vector3(0, brzina_okretanja * Input.GetAxis("Horizontal") * 1000 * Time.deltaTime, 0); }

            if (Input.GetAxis("Horizontal") == 0) { ugaoK += brzina_okretanja * hs_axiss * 1000 * Time.deltaTime; }
            if (hs_axiss == 0) { ugaoK += brzina_okretanja * Input.GetAxis("Horizontal") * 1000 * Time.deltaTime; }
            if (ugaoK > (ugaoPP + 50f)) { ugaoK = ugaoPP + 50f; previseD = true; kugla.transform.eulerAngles = new Vector3(0, euler_ugao, 0); previseD = true; } else previseD = false;
            if (ugaoK < (ugaoPP - 50f)) { ugaoK = ugaoPP - 50f; previseL = true; kugla.transform.eulerAngles = new Vector3(0, euler_ugao, 0); previseL = true; } else previseL = false;

        }

        


        if (Input.GetKeyDown(KeyCode.R) && !kugla_se_krece && !game_over)
        {
            //StartCoroutine(restart_game());
            repeat_button();
        }



        

        if (CrossPlatformInputManager.GetAxis("Vertical") > 0.5f) { up_press = true; }
        if (CrossPlatformInputManager.GetAxis("Vertical") < 0.5f) { up_press = false; }


        //Debug.Log(CrossPlatformInputManager.GetAxis("Vertical"));

        if (namjesti_kameru_bool == true)
        {
            main_camera.transform.localPosition = Vector3.Lerp(main_camera.transform.localPosition, new Vector3(0, 6, -5), Time.deltaTime * 5);
            main_camera.transform.localEulerAngles = Vector3.Lerp(main_camera.transform.localEulerAngles, new Vector3(40, 0, 0), Time.deltaTime * 5);

        }
        
        if (game_over && samo_jednom_gameover)
        {
            samo_jednom_gameover = false;
            StartCoroutine(restart_game());
        }

    }

    private void FixedUpdate()
    {
        //GAMEOVER DEKLARISANJE
        {
            if (udaljenost > 70 && (Time.time - vrijeme_start) > 1f && kugla_se_krece) { game_over = true; Debug.Log("VELIKA UDALJENOST"); StartCoroutine(restart_game()); }
            //if (kugla.transform.position.y < 0.3f) { game_over = true; Debug.Log("NISKO"); }
            //if (udaljenost > 60 && !u_rampi && kugla.transform.position.y < 3.31f) { game_over = true; }

            //if ((vrijeme_start - Time.time) < 0.5) { game_over = false; }

        }
        //
        // SCORE

        if (kugla_se_krece && !game_over)
        {
            screen_score += (brzina_kretanja / 6000f);
            screen_score += (brzina_kretanja / 10000f) * perfektno;
        }
        

        // ZELJENA BOJA

        if (zeljena_boja_bool) { promijeni_boju(zeljena_boja); }
        if (zeljena_boja == kugla.GetComponent<Renderer>().material.color) { zeljena_boja_bool = false; }

        //

        if (kugla.transform.position.y < 20 && !game_over && up_press)
        {
            kugla.GetComponent<Rigidbody>().AddForce(0, brzina_dizanja, 0);
        }

        udaljenost = Vector3.Distance(kugla.transform.position, PP.transform.position);
        // && kugla.transform.position.y > 1.7f
        //if (udaljenost < 60 && udaljenost > 0f)
        if (!game_over)
        {
            dodatna_visina = (60 - udaljenost) * (0.7f / 60);
            //if (u_rampi && pocetak) { kugla.transform.Translate(new Vector3(0, 0, brzina_kretanja) * Time.deltaTime * 3); }
            //else { kugla.transform.Translate(new Vector3(0, 0, brzina_kretanja) * Time.deltaTime); }

            if (kugla_se_krece) { kugla.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, brzina_kretanja + ((((brzina_kretanja / 2) * 0.7f) / 9) * perfektno))); }
            //brzina_padanja = 20 + ((60 / 9) * perfektno);
            //brzina_dizanja = 40 + ((120 / 9) * perfektno);
            brzina_padanja = 20 + ((46.66f / 9) * perfektno);
            brzina_dizanja = 40 + ((93.33f / 9) * perfektno);


            if (u_rampi && pozicija_ulaza_u_rampu < 2.5f && pozicija_ulaza_u_rampu > 0) { kugla.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, (brzina_kretanja/2))); }
            if ((Time.time - vrijeme_start) < 2.4f) { kugla.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, (brzina_dizanja / 20), (brzina_kretanja / 4))); }
            //Debug.Log(kugla.GetComponent<Rigidbody>().velocity.z);
            //if (kugla.GetComponent<Rigidbody>().velocity.z < -20f) { Debug.Log("PREMALA BRZINA"); game_over = true; }
            kugla.GetComponent<Rigidbody>().velocity = new Vector3(0, kugla.GetComponent<Rigidbody>().velocity.y, 0);
            if (udaljenost < 30 && udaljenost > 0f)
            {
                //kugla.transform.position = new Vector3(kugla.transform.position.x, (1.7f + dodatna_visina + (25f / 30) * udaljenost), kugla.transform.position.z);
                //kugla.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
            if (udaljenost < 60 && udaljenost > 30f)
            {

                //kugla.transform.position = new Vector3(kugla.transform.position.x, 1.7f + dodatna_visina + (25f / 30) * (30 - (udaljenost - 30)), kugla.transform.position.z);
                //kugla.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }
        //kugla.GetComponent<Rigidbody>().velocity = new Vector3(0, kugla.GetComponent<Rigidbody>().velocity.y, kugla.GetComponent<Rigidbody>().velocity.z);
        if (Input.GetKey(KeyCode.U) && kugla.transform.position.y < 20 && !game_over)
        {
            kugla.GetComponent<Rigidbody>().AddForce(0, brzina_dizanja, 0);
        }

        if ((Time.time - vrijeme_start) < 0.5) { kugla.GetComponent<Rigidbody>().AddRelativeForce(0, 20, 0); }


    }

    

    public void spawn()
    {
        if (score == 2) spawn_broj = 2;
        if (score > 2)
        {
            spawn_broj++;
            if (spawn_broj == 3) spawn_broj = 0;
        }

        if (score > 1)
        {
            destroy_broj++;
            if (destroy_broj == 3) destroy_broj = 0;
            Destroy(rampe_array[destroy_broj]);
        }
    }
    

    /*public int spawn_broj (int s) {
        if (s == 0 || broj_provjere == 3) broj_provjere = 0;
        if (s > 2)
        {
            broj_provjere++;
            return (broj_provjere-1);
        }
        else return -1;
    }
    */

    public void chose_color()
    {
        boja_kugle = Random.Range(0, 5);
        promijeni_boju(boje_kod[boja_kugle]);
        //kugla.GetComponent<Renderer>().material.color = boje_kod[boja_kugle];
        //rampa_colors[rampa_boje_kugle] = boja_kugle;
        rampa_colors[0] = Random.Range(0, 5); rampa_colors[1] = rampa_colors[0]; rampa_colors[2] = rampa_colors[0]; rampa_colors[3] = rampa_colors[0]; rampa_colors[4] = rampa_colors[0];
        while (rampa_colors[0] == rampa_colors[1]) { rampa_colors[1] = Random.Range(0, 5); }
        while (rampa_colors[0] == rampa_colors[2] || rampa_colors[1] == rampa_colors[2]) { rampa_colors[2] = Random.Range(0, 5); }
        while (rampa_colors[0] == rampa_colors[3] || rampa_colors[1] == rampa_colors[3] || rampa_colors[2] == rampa_colors[3]) { rampa_colors[3] = Random.Range(0, 5); }
        while (rampa_colors[0] == rampa_colors[4] || rampa_colors[1] == rampa_colors[4] || rampa_colors[2] == rampa_colors[4] || rampa_colors[3] == rampa_colors[4]) { rampa_colors[4] = Random.Range(0, 5); }
        
        //rampa_colors[0] = Random.Range(0, 5);
        //Debug.Log(rampa_colors[0]);
    }

    private IEnumerator restart_game()
    {
        kugla_se_krece = false;
        yield return new WaitForSeconds(1f);
        fade_canvas.enabled = true;
        fade_in();
        yield return new WaitForSeconds(0.6f);
        restart_game_instant();
    }

    void restart_game_instant()
    {
        perfektno = 0;
        PlayerPrefs.SetInt("last_score", Mathf.RoundToInt(screen_score));
        if (Mathf.RoundToInt(screen_score) > PlayerPrefs.GetInt("best_score", 0)) { PlayerPrefs.SetInt("best_score", Mathf.RoundToInt(screen_score)); }
        screen_score = 0;
        pozicija_ulaza_u_rampu = -1;
        upravljanje_canvas.enabled = false;
        score_canvas.enabled = false;
        kugla_se_krece = false;
        broj_platformi += 10;
        names = GameObject.FindGameObjectsWithTag("platforma");

        foreach (GameObject item in names)
        {
            Destroy(item);
        }

        for (int g = 0; g < platforme.Length; g++)
        {
            platforme[g] = new Vector3(-1,-1,-1);
        }
        array_broj = 0;
        
        

        chose_color();
        //game_over = false;
        destroy_broj = -1;
        spawn_broj = 2;
        Destroy(rampe_array[0]);
        Destroy(rampe_array[1]);
        Destroy(rampe_array[2]);

        kugla.transform.position = new Vector3(0, 30, -4.7f);
        //rampe_array[0] = Instantiate(pr_prefab, pr_prefab.transform.position, pr_prefab.transform.rotation);
        rampe_array[1] = Instantiate(rampe_prefab, rampe_prefab.transform.position, rampe_prefab.transform.rotation);
        
        PP.transform.position = new Vector3(0, 2, 0.15f);
        kugla.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        kugla.transform.eulerAngles = new Vector3(0, 0.01f, 0);
        
        PP.transform.position = new Vector3(0, 2, 0.15f);
        ugaoPP = 0;
        ugaoK = 0;
        u_rampi = false;
        pocetak = false; //
        Instantiate(platforma);
        platforme[0] = new Vector3(0f, 0f, 0f);
        broj_platformi++;
        main_camera.transform.localPosition = new Vector3(0f, 6f, 1.8f);
        main_camera.transform.localEulerAngles = new Vector3(90, 0, 0);
        kugla.GetComponent<Rigidbody>().useGravity = false;
        kugla.GetComponent<Rigidbody>().isKinematic = true;
        menu_canvas.enabled = true;
        samo_jednom_gameover = true;
        game_over = false;
        fade_out();
    }

    private IEnumerator pokreni_sve()
    {
        game_over = false;
        vrijeme_start = Time.time;
        menu_canvas.enabled = false;
        yield return new WaitForSeconds(0.8f);
        upravljanje_canvas.enabled = true;
        score_canvas.enabled = true;
        vrijeme_start = Time.time;
        namjesti_kameru_bool = false;
        main_camera.transform.localPosition = new Vector3(0f, 6f, -5f);
        main_camera.transform.localEulerAngles = new Vector3(40f, 0f, 0f);
        kugla_se_krece = true;
        kugla.GetComponent<Rigidbody>().useGravity = true;
        kugla.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void button_L()
    {

    }
    public void button_D()
    {
        
    }
    
    public void button_R()
    {
        repeat_button();
    }

    public void repeat_button()
    {
        namjesti_kameru();
        izvor_1.clip = playgame_sound;
        izvor_1.Play();
        StartCoroutine(pokreni_sve());


    }

    private void namjesti_kameru()
    {
        namjesti_kameru_bool = true;
    }

    private void fade_in()
    {
        fade_canvas.enabled = true;
        fade_image.CrossFadeAlpha(1, 0.5f, false);
    }
    private void fade_out()
    {
        StartCoroutine(fadeout_ie());
        StartCoroutine(iskljuci_fade_canvas());
    }
    private IEnumerator fadeout_ie()
    {
        yield return new WaitForSeconds(0.1f);
        fade_image.CrossFadeAlpha(0, 0.6f, false);
    }
    private IEnumerator iskljuci_fade_canvas()
    {
        yield return new WaitForSeconds(0.5f);
        fade_canvas.enabled = false;
    }

    public void upitnik_button()
    {
        upitnik_canvas.enabled = true;
    }
    public void x_button()
    {
        upitnik_canvas.enabled = false;
    }
    public void settings_button()
    {

    }

    private void promijeni_boju(Color boja_promjene)
    {
        zeljena_boja_bool = true;
        zeljena_boja = boja_promjene;
        //Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        //float brzina_promjene_boje_kugle = 0.2f - (0.1f - ((0.05f/9) * perfektno));
        float brzina_promjene_boje_kugle = 0.2f - (0.1f - ((0.1f / 9) * perfektno));
        kugla.GetComponent<Renderer>().material.color = Color.Lerp(kugla.GetComponent<Renderer>().material.color, boja_promjene, brzina_promjene_boje_kugle);

    }

}
