using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RayCastManager_R : MonoBehaviour
{

    LineRenderer myLR;
    GameObject right_hand;
    Ray ray;
    RaycastHit hit;
    public UnityEvent<string> AA;
    public UnityEvent<RaycastHit,bool> BB;
    string AA_string;
    // Start is called before the first frame update
    void Start()
    {
        myLR = GetComponent<LineRenderer>();
        right_hand = GameObject.Find("RightHandAnchor");
        transform.position = right_hand.transform.position;
        transform.eulerAngles = right_hand.transform.eulerAngles;
        transform.parent = right_hand.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = right_hand.transform.position;
        ray.direction = right_hand.transform.forward;
        myLR.SetPosition(0, ray.origin);
        myLR.SetPosition(1, ray.origin + ray.direction * 50);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.collider)
            {
                myLR.SetPosition(1, hit.point);
                AA.Invoke(hit.collider.gameObject.name);
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    Debug.Log("¥≠∑»¿Ω");
                    BB.Invoke(hit,true);
                }
            }
        }
        else
        {
            AA.Invoke(null);
            myLR.SetPosition(1, ray.origin + ray.direction * 10);
        }
    }
        }
