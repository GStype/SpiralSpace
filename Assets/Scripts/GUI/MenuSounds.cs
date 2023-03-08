using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSounds : MonoBehaviour
{
    //make menu buttons play sounds upon clicking them

    

    public GameObject audioFx;
    public AudioClip clickFx;
    Button button;
    private AudioSource fx;

    private void Awake()
        {
            
            fx = audioFx.GetComponent<AudioSource>();
            //fx.clip = clickFx;
            
            button = GetComponent<Button>();
            Debug.Log(button.gameObject.name);
        }
    

    public void ClickSound()
    {
        
        if(button.gameObject.activeSelf)
        //fx.Play();
        fx.PlayOneShot(clickFx);
    }
}
