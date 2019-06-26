using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;



public class PlaneController : MonoBehaviour
{
    /*
    ARPlaneManager m_ARPlaneManager;

    List<ARPlane> existingPlanes = new List<ARPlane>();

    public Text buttonText;


    private void Awake()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TogglePlaneDetectionAndVisibility()
    {
        m_ARPlaneManager.enabled = !m_ARPlaneManager.enabled;
        if (m_ARPlaneManager.enabled)
        {
            SetAllPlanesActiveOrDeactive(true);
            buttonText.text = "Disable Plane Detection and Hide Existing";
        }
        else
        {
            SetAllPlanesActiveOrDeactive(false);
            buttonText.text = "Enable Plane Detection and Show Existing";

        }



    }


    void SetAllPlanesActiveOrDeactive(bool value)
    { 

        foreach (var plane in m_ARPlaneManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }

    }
    */
}
