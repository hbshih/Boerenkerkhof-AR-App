using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowCollider : MonoBehaviour
{

    public GameObject arrowObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            GameObject obj = Instantiate(arrowObject, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.name + " collide with me.");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("print:  " + other.transform.position);
        //if(transform.position.z > other.transform.position.z)
        //{
            var newArrowLocation = transform.position + new Vector3(0.0f, 0.0f, 5.0f);
            print("new location : " + newArrowLocation);
            Instantiate(arrowObject, newArrowLocation, Quaternion.identity);
        //}
    }

}
