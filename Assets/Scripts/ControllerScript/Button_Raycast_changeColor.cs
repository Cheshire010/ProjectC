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
    Coroutine Vibe;
    bool isVibe = false;
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

            if(Vibe == null && isVibe == false)
                Vibe = StartCoroutine(VibrationRight(0.01f));
        }
        else
        {
            myImage.color = Color.white;
            isVibe = false;
            Vibe = null;
        }
    }
    public void OnClickMethod(RaycastHit _hit, bool _isTrigger)
    {
        if (_hit.collider.gameObject.name != this.gameObject.name)
            return;

        GetComponent<Button>().onClick.Invoke();
    }

    IEnumerator VibrationRight(float _time)
    {
        OVRInput.SetControllerVibration(1, 0.01f, OVRInput.Controller.RTouch);
        yield return new WaitForSeconds(_time);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        Vibe = null;
        isVibe = true;
    }
}
