//==============================================================================================
/// File Name	: FadeController
/// Summary		: フェード管理
/// 
/// Author      : Takumi Yanase (柳瀬 拓臣)
//==============================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//==============================================================================================
[RequireComponent(typeof(Image))]

public class FadeController : MonoBehaviour
{
    //------------------------------------------------------------------------------------------
    // member variable
    //------------------------------------------------------------------------------------------
    float fadeSpeed = 0.02f;        
    float red, green, blue, alfa;   

    public bool isFadeOut = false;  
    public bool isFadeIn = false;   

    Image fadeImage;

    //------------------------------------------------------------------------------------------
    // Awake
    //------------------------------------------------------------------------------------------
    public void Awake()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    //------------------------------------------------------------------------------------------
    // Update
    //------------------------------------------------------------------------------------------
    public void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }

        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    //------------------------------------------------------------------------------------------
    // StartFadeIn
    //------------------------------------------------------------------------------------------
    void StartFadeIn()
    {
        alfa -= fadeSpeed;               
        SetAlpha();                      
        if (alfa <= 0)
        {                    　　　　　　
            isFadeIn = false;
            fadeImage.enabled = false;   
        }
    }

    //------------------------------------------------------------------------------------------
    // StartFadeOut
    //------------------------------------------------------------------------------------------
    void StartFadeOut()
    {
        fadeImage.enabled = true;        
        alfa += fadeSpeed;
        SetAlpha();                      
        if (alfa >= 1)                   
        {                              
            isFadeOut = false;
        }
    }

    //------------------------------------------------------------------------------------------
    // SetAlpha
    //------------------------------------------------------------------------------------------
    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}