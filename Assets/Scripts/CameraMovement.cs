using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveCam = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate (0,0,moveCam);   
    }
}
