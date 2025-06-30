using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarOption_Script : MonoBehaviour
{
    RayCastManager_R RayCastManager_R;
    // Start is called before the first frame update
    void Start()
    {
        RayCastManager_R = GameObject.Find("RayCastManager_R").GetComponent<RayCastManager_R>();
        RayCastManager_R.BB.AddListener(ShowUI3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowUI3(RaycastHit _hit, bool _isTrigger)
    {
        Debug.Log(_hit.collider.gameObject.name);
        Debug.Log(this.gameObject.name);
        if (_hit.collider.gameObject.name != this.gameObject.name)
            return;
        
        GameObject CarDoor = transform.Find("OptionCanvas").gameObject;
        Debug.Log(CarDoor.gameObject.name);
        if (CarDoor.activeSelf == true)
            CarDoor.SetActive(false);
        else
            CarDoor.SetActive(true);
    }
}
