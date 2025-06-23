using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject Canvas;
    GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        Camera = GameObject.Find("CenterEyeAnchor");
        Canvas.transform.position = Camera.transform.position + Camera.transform.forward * 10.0f;
        Canvas.transform.eulerAngles = Camera.transform.eulerAngles;
        Canvas.transform.parent = Camera.transform;
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            Canvas.SetActive(true);
        }
        if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            Canvas.SetActive(false);
        }
    }
}
