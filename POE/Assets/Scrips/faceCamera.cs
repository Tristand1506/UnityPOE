using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceCamera : MonoBehaviour
{
    Camera cam;


    // Update is called once per frame
    void Update()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        transform.rotation = cam.transform.rotation;
    }
}
