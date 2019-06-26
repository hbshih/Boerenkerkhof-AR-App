using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioTrigger_Afterlife : MonoBehaviour
{
    public AudioSource tickSource;
    public Text text;

    void Start()
    {
        tickSource = GetComponent<AudioSource>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collide)
    {
        if (collide.name != "AR Camera")
        {
            return;
        }
        tickSource.Play();
        print("Enter");
        text.text = "You've completed the journey...\nYou may close the app \nand follow the signs now...";
    }

    private void OnTriggerExit(Collider collide)
    {
        if (collide.name != "AR Camera")
        {
            return;
        }
        tickSource.Stop();
        print("Exit");
    }




}
