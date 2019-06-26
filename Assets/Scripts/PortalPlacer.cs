using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.UI;
using System;
public class PortalPlacer : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    private GameObject spawedPortal;

    private ARRaycastManager arOrigin;
    private Pose placementPose;
    //List<ARRaycastHit> raycast_hits = new List<ARRaycastHit>();
    private bool isPortalPlaced = false;
    private bool placementPoseIsValid = false;

    public Text text;

    private void Awake()
    {
        arOrigin = GetComponent<ARRaycastManager>();
    }

    void Start()
    {
        // arOrigin = FindObjectOfType<ARRaycastManager>();
        text.text = "Scan Around The Floor...";
    }

    void Update()
    {/*
        if (!isPortalPlaced)
        {
            placementIndicator.SetActive(true);
           // placementIndicator.transform.SetPositionAndRotation(placementPose)
        }else
        {
            placementIndicator.SetActive(false);
        }
        */

        if (Input.touchCount > 0)
        {
            print("Initialized...");
            Touch touch = Input.GetTouch(0);

            //var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
            print("touched");
            List<ARRaycastHit> raycast_hits = new List<ARRaycastHit>();
            if (arOrigin.Raycast(touch.position, raycast_hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes) && isPortalPlaced == false)
            { 
                print("touch position " + touch.position);
                Pose pose = raycast_hits[0].pose;
                if(spawedPortal == null)
                {
                    spawedPortal = Instantiate(objectToPlace, pose.position, Quaternion.Euler(0, 0, 0));
                    var rotationOfPortal = spawedPortal.transform.rotation.eulerAngles;
                    spawedPortal.transform.eulerAngles = new Vector3(rotationOfPortal.x, Camera.main.transform.rotation.eulerAngles.y, rotationOfPortal.z);
                    isPortalPlaced = true;
                    text.text = "";
                }
                else
                {

                    spawedPortal.transform.position = pose.position;
                    var rotationOfPortal = spawedPortal.transform.rotation.eulerAngles;
                    spawedPortal.transform.eulerAngles = new Vector3(rotationOfPortal.x, Camera.main.transform.rotation.eulerAngles.y, rotationOfPortal.z);
                }
            }
        }


        UpdatePlacementPose();
        UpdatePlacementIndicator();
      /*  if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
           // portalHasPlaced = true;
            PlaceObject();
        }*/
  }
    /*
    private void PlaceObject()
    {
        //Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
        if (spawedPortal == null)
        {
            spawedPortal = Instantiate(objectToPlace, placementPose.position, Quaternion.Euler(0, 0, 0));
            var rotationOfPortal = spawedPortal.transform.rotation.eulerAngles;
            spawedPortal.transform.eulerAngles = new Vector3(rotationOfPortal.x, Camera.main.transform.rotation.eulerAngles.y, rotationOfPortal.z);
            isPortalPlaced = true;
        }
    }*/

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid && isPortalPlaced == false)
        {
            text.text = "Great! Tap the screen when you\nplaced the arrow in the box";
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arOrigin.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}