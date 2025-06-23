using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastManager_L : MonoBehaviour
{
    LineRenderer myLR;
    GameObject left_hand;
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        myLR = GetComponent<LineRenderer>();
        left_hand = GameObject.Find("LeftHandAnchor");
        transform.position = left_hand.transform.position;
        transform.eulerAngles = left_hand.transform.eulerAngles;
        transform.parent = left_hand.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = left_hand.transform.position;
        ray.direction = left_hand.transform.forward;
        myLR.SetPosition(0, ray.origin);
        myLR.SetPosition(1, ray.origin + ray.direction * 50);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("Button"))
            {
                myLR.SetPosition(1, hit.point);
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
                {
                    Button Button_Component = hit.collider.gameObject.GetComponent<Button>();
                    Button_Component.onClick.Invoke();
                }
            }
        }
        else
        {
            myLR.SetPosition(1, ray.origin + ray.direction * 10);
        }
    }
}
