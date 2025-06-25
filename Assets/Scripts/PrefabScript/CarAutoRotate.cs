using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAutoRotate : MonoBehaviour
{
    float rotatespeed = 10.0f;
    bool isrotating = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isrotating)
        {
            transform.Rotate(Vector3.up *  rotatespeed * Time.deltaTime);
        }
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
                isrotating = false;
        }
    }
}
