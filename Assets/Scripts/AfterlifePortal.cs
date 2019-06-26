using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class AfterlifePortal : MonoBehaviour
{
    // Start is called before the first frame update

    public Material[] PGMat;
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
        if (transform.position.z > collide.transform.position.z)
        {
            tickSource.Play();
            text.text = "You've completed the journey...\nYou may close the app \nand follow the signs now...";
        }
        else
        {
            tickSource.Pause();
        }

    }
    /*
    private void OnTriggerStay(Collider collide)
    {

        if (collide.name != "AR Camera")
        {
            return;
        }
        if (transform.position.z > collide.transform.position.z)
        {
            print("Should turn equal");
            foreach (Material mat in PGMat)
            {
                mat.SetInt("stest", (int)CompareFunction.Equal);
            }
        }
        else
        {
            print("Should turn not equal");
            foreach (Material mat in PGMat)
            {
                mat.SetInt("stest", (int)CompareFunction.NotEqual);
            }
        }

    }*/
}
