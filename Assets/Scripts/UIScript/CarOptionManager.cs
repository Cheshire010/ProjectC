using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarOptionManager : MonoBehaviour
{
    GameObject CarCanvas;
    public GameObject Option;
    // Start is called before the first frame update
    void Start()
    {
        CarCanvas = GameObject.Find("CarCanvas");
        CarCanvas.transform.position = Option.transform.position;
        Vector3 baseEular = Option.transform.eulerAngles;
        CarCanvas.transform.eulerAngles = new Vector3(baseEular.x + 90.0f, baseEular.y, baseEular.z);
        CarCanvas.transform.parent = Option.transform;
        CarCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if (CarCanvas != null)
            {
                CarCanvas.SetActive(true);
            }
        }
    }
}
