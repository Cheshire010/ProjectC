using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastManager_R : MonoBehaviour
{
    LineRenderer myLR;
    GameObject right_hand;
    Ray ray;
    RaycastHit hit;
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

        if(Physics.Raycast(ray, out hit,Mathf.Infinity))
        {
            if(hit.collider.gameObject.CompareTag("Button"))
            {
                myLR.SetPosition(1, hit.point);
                if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    Button Button_Component = hit.collider.gameObject.GetComponent<Button>();
                    Button_Component.onClick.Invoke();
                }
            }
        }
        else
        {
            myLR.SetPosition(1,ray.origin+ray.direction * 10);
        }
    }
}
