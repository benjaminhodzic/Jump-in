using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private GameObject glavni_obj;
    private glavna_skripta gs;
    private Text score_text;
    private int fin_score;
    
    void Start()
    {
        glavni_obj = GameObject.Find("glavni_obj");
        gs = glavni_obj.GetComponent<glavna_skripta>();
        score_text = gameObject.GetComponent<Text>();
    }

    
    void FixedUpdate()
    {
        if (gameObject.tag == "score")
        {
            fin_score = Mathf.RoundToInt(gs.screen_score);
            score_text.text = fin_score.ToString();
        }
        if (gameObject.tag == "xspeed")
        {
            if (gs.perfektno > 0) { score_text.text = "X" + (gs.perfektno +1 ).ToString(); }
            else { score_text.text = ""; }
        }
        if (gameObject.tag == "last_score_preview")
        {
            score_text.text = PlayerPrefs.GetInt("last_score", 0).ToString();
        }
        if (gameObject.tag == "best_score_preview")
        {
            score_text.text = PlayerPrefs.GetInt("best_score", 0).ToString();
        }
    }
}
