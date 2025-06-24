using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCScript : MonoBehaviour
{
    RayCastManager_R RayCastManager_R;
    Rigidbody myRigid;
    CapsuleCollider myCap;
    public GameObject UICanvas;
    public GameObject TextCanvas;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        myCap = GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            if(UICanvas != null)
            {
                UICanvas.SetActive(true);
            }
            if(TextCanvas != null)
            {
                TextCanvas.SetActive(true);
            }
        }
    }
}
