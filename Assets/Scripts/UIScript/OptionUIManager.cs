using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUIManager : MonoBehaviour
{
    RayCastManager_R RayCastManager_R;
    public GameObject OptionUI;
    // Start is called before the first frame update
    void Start()
    {
        RayCastManager_R = GameObject.Find("RayCastManager_R").GetComponent<RayCastManager_R>();
        OptionUI = GameObject.Find("SetOptionCanvas");
        OptionUI.SetActive(false);
        RayCastManager_R.BB.AddListener(OptionSet);
    }
    public void OptionSet(RaycastHit _hit, bool _value)
    {
        Debug.Log(_hit.collider.gameObject.name);
        Debug.Log(_hit.collider.gameObject.tag);
        Debug.Log(this.gameObject.name);
        Debug.Log(this.gameObject.tag);
        if (!_hit.collider.gameObject.CompareTag(this.gameObject.tag)) return;
        if (_hit.collider.gameObject.name != this.gameObject.name) return;
        Debug.Log("dd");
        OptionUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
