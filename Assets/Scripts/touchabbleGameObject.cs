using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchabbleGameObject : MonoBehaviour
{
    public Material[] material;
    Renderer rend;

    private Material mat;
    public AudioSource tickSource;
    private AudioSource[] allAudioSources;
    private bool playing = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        mat = GetComponent<Renderer>().material;
        tickSource = GetComponent<AudioSource>();

        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach(AudioSource aud in allAudioSources)
        {
            print(aud.name);
        }

        //playButton = Resources.Load("Play", typeof(Material)) as Material;
        //stopButton = Resources.Load("Pause", typeof(Material)) as Material;
    }
    /*
    private void OnMouseDown()
    {
        if (!playing)
        {
            foreach (AudioSource aud in allAudioSources)
            {
                if (aud.name != "Floor")
                {
                    aud.Pause();
                }
            }
            rend.sharedMaterial = material[1];
            tickSource.Play();
            playing = true;
            print("Should play");
        }
        else
        {
            foreach (AudioSource aud in allAudioSources)
            {
                if (aud.name == "Portal Detector")
                {
                    aud.UnPause();
                }
            }
            rend.sharedMaterial = material[0];
           // mat = playButton;
            tickSource.Pause();
            playing = false;
        }
    }
    */
    void onTouchDown()
    {
        if (!playing)
        {
            foreach (AudioSource aud in allAudioSources)
            {
                if (aud.name != "Floor")
                {
                    aud.Pause();
                }
            }
            rend.sharedMaterial = material[1];
            mat = material[1];
            tickSource.Play();
            playing = true;
            print("Should play");
        }
        else
        {
            foreach (AudioSource aud in allAudioSources)
            {
                if (aud.name == "Portal Detector")
                {
                    aud.UnPause();
                }
            }
            mat = material[0];
            rend.sharedMaterial = material[0];
            tickSource.Pause();
            playing = false;
            print("Shouldn't play");
        }
    }
    /*
void onTouchUp()
    {
  //      mat.color = defaultColor;
        print("OnTouchUP");
//        tickSource.Pause();
    }
    */


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
