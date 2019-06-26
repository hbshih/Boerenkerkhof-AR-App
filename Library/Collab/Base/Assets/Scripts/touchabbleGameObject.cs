using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchabbleGameObject : MonoBehaviour
{
    public Material[] material;
    Renderer rend;

    private Material mat;
    public AudioSource tickSource;

    private bool playing = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        //mat = GetComponent<Renderer>().material;
        tickSource = GetComponent<AudioSource>();

        //playButton = Resources.Load("Play", typeof(Material)) as Material;
        //stopButton = Resources.Load("Pause", typeof(Material)) as Material;
    }

    private void OnMouseDown()
    {
        if (!playing)
        {
            rend.sharedMaterial = material[1];
            tickSource.Play();
            playing = true;
            print("Should play");
        }
        else
        {
            rend.sharedMaterial = material[0];
           // mat = playButton;
            tickSource.Pause();
            playing = false;
        }
    }

    void onTouchDown()
    {
        if(!playing)
        {
           // mat = stopButton;
            tickSource.Play();
            playing = true;
        }else
        {
            //mat = playButton;
            tickSource.Pause();
            playing = false;
        }
    }

  /*  
   * void onTouchUp()
    {
        mat.color = defaultColor;
        print("OnTouchUP");
        tickSource.Pause();
    }

    void onTouchStay()
    {
        mat.color = selectedColor;
        print("OnTouchStay");
    }

    void onTouchExit()
    {
        mat.color = defaultColor;
        print("OnTouchExit");
    }*/
}
