using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spritetexture_anim : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        gameObject.GetComponent<RawImage>().texture = gameObject.GetComponent<SpriteRenderer>().sprite.texture;


    }
}
