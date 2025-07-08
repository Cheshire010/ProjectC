using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Raycast_outline : MonoBehaviour
{
    RayCastManager_R RayCastManager_R;
    // Start is called before the first frame update
    void Start()
    {
        RayCastManager_R = GameObject.Find("RayCastManager_R").GetComponent<RayCastManager_R>();
        RayCastManager_R.AA.AddListener(On_Outline);
    }

    void On_Outline(string _value)
    {
        if (_value == gameObject.name)
        {
            GetComponent<Outline_>().enabled = true;
        }
        else
        {
            GetComponent<Outline_>().enabled=false;
        }
    }
}
