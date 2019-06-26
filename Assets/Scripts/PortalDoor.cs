using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class PortalDoor : MonoBehaviour
{
    // Start is called before the first frame update

    public Material[] PGMat;
    public AudioSource tickSource;

    void Start()
    {
        tickSource = GetComponent<AudioSource>();
        foreach (Material mat in PGMat)
        {
            mat.SetInt("stest", (int)CompareFunction.Equal);
        }
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
            print("Enter");
        }
        else
        {
            tickSource.Pause();
            print("Exit");
        }

    }


    /* private void OnTriggerStay(Collider collide)
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
