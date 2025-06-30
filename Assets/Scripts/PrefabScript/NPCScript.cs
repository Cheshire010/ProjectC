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
    //bool isPointed = false;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        myCap = GetComponent<CapsuleCollider>();
        RayCastManager_R =  GameObject.Find("RayCastManager_R").GetComponent<RayCastManager_R>();
        RayCastManager_R.BB.AddListener(ShowUI);
        RayCastManager_R.BB.AddListener(ShowUI2);
    }
    void Update()
    {
        //if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        //{
        //    if(UICanvas != null)
        //    {
        //        UICanvas.SetActive(true);
        //    }
        //    if(TextCanvas != null)
        //    {
        //        TextCanvas.SetActive(true);
        //    }
        //}
    }

    public void ShowUI(RaycastHit _hit, bool _isTrigger)
    {
        Debug.Log("πﬁæ“¿Ω");
        if (_hit.collider.gameObject.name != this.gameObject.name)
            return;


        GameObject GG = transform.Find("UICanvas").gameObject;
        if (GG.activeSelf == true)
            GG.SetActive(false);
        else
            GG.SetActive(true);
    }
    public void ShowUI2(RaycastHit _hit, bool _isTrigger)
    {
        if(_hit.collider.gameObject.name != this.gameObject.name)
            return;

        GameObject Go = transform.Find("TextCanvas").gameObject;
        if(Go.activeSelf == true)
            Go.SetActive(false) ;
        else
            Go.SetActive(true);
    }
}
