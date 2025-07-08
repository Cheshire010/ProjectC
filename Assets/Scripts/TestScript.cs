using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    RayCastManager_R RayCastManager_R;
    GameObject ParkingCar;
    // Start is called before the first frame update
    void Start()
    {
        ParkingCar = GameObject.Find("Santafe_Final_1");
        RayCastManager_R = GameObject.Find("RayCastManager_R").GetComponent<RayCastManager_R>();
        RayCastManager_R.AA.AddListener(Park_Car);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Park_Car(string _value)
    {
        
        if(_value == gameObject.name)
        {
            if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                ParkingCar.transform.Translate(Vector3.forward * 1 *  Time.deltaTime);
            }
        }
    }
}
