using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat_Script : MonoBehaviour
{
    GameObject CenterEye;
    // Start is called before the first frame update
    void Start()
    {
        CenterEye = GameObject.Find("CenterEyeAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(CenterEye.transform);
    }
}
