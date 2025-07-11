using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewScript : MonoBehaviour
{
    RayCastManager_R RayCastManager_R;
    ScrollRect scrollRect;
    float ScrollVector = 0;
    float ScrollSpeed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        RayCastManager_R = GameObject.Find("RayCastManager_R").GetComponent<RayCastManager_R>();
        RayCastManager_R.CC.AddListener(ScrollViewRight);
        scrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScrollViewRight(RaycastHit _hit, bool _isTrigger)
    {
        
        if (!_hit.collider.gameObject.CompareTag("ScrollView")) return;
        if(_hit.collider.gameObject.name != this.gameObject.name) return;
        
        if (_isTrigger == true) ScrollVector = 1.0f;
        else if (_isTrigger == false) ScrollVector = -1.0f;
        scrollRect.verticalNormalizedPosition += ScrollVector * ScrollSpeed;
        scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition);
    }
}
