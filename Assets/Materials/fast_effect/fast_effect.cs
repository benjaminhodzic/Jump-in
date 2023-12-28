using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class fast_effect : MonoBehaviour
{
    public RawImage rawimage;
    public VideoPlayer videoplayer;
    public AudioSource audiosource;
    
    void Start()
    {
        StartCoroutine(pusti_video());
    }

    
    void Update()
    {
        
    }

    IEnumerator pusti_video()
    {
        videoplayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while(!videoplayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawimage.texture = videoplayer.texture;
        videoplayer.Play();
        audiosource.Play();
    }
}
