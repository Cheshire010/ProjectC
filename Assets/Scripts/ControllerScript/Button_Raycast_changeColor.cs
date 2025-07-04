using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button_Raycast_changeColor : MonoBehaviour
{
    RayCastManager_R RaycastManager_R;
    Image myImage;
    GameObject Rhand;

    // Start is called before the first frame update
    void Start()
    {
        RaycastManager_R = GameObject.Find("RayCastManager_R").GetComponent<RayCastManager_R>();
        myImage = GetComponent<Image>();
        RaycastManager_R.AA.AddListener(change_Color);
        RaycastManager_R.BB.AddListener(OnClickMethod);
    }

    public void change_Color(string _value)
    {
        if (_value == gameObject.name)
        {
            myImage.color = Color.red;
            //GetComponent<UnityEngine.UI.Outline>().enabled = true;
        }
        else
        {
            myImage.color = Color.white;
            //GetComponent<UnityEngine.UI.Outline>().enabled = false;
        }
    }
    public void OnClickMethod(RaycastHit _hit, bool _isTrigger)
    {
        if (_hit.collider.gameObject.name != this.gameObject.name)
            return;

        GetComponent<Button>().onClick.Invoke();
    }
}
