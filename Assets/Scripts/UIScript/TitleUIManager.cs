using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    GameObject TitleCanvas;
    GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        TitleCanvas = GameObject.Find("TitleCanvas");
        Camera = GameObject.Find("OVRCameraRig");
        TitleCanvas.transform.position = Camera.transform.position + Camera.transform.forward * 5.0f;
        TitleCanvas.transform.eulerAngles = Camera.transform.eulerAngles;
        TitleCanvas.transform.parent = Camera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
