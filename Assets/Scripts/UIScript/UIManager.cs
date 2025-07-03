using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject UICanvas;
    GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        UICanvas = GameObject.Find("UICanvas");
        npc = GameObject.Find("NPC");
        UICanvas.transform.position = npc.transform.position + npc.transform.right * -1.0f;
        UICanvas.transform.eulerAngles = npc.transform.eulerAngles * 180.0f;
        UICanvas.transform.parent = npc.transform;
        UICanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if(OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        //{
        //    UICanvas.SetActive(true);
        //}
        //if(OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        //{
        //    UICanvas.SetActive(false);
        //}
    }
}
