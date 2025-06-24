using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 myVec = Vector3.zero;
    float speed = 2.0f;
    float rotatespeed = 900.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        myVec = new Vector3(input.x, 0, input.y);
        transform.Translate(myVec * speed * Time.deltaTime);

        Vector2 turninput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        Debug.Log("돌아가용");
        float turnAmount = turninput.x * rotatespeed * Time.deltaTime;
        transform.Rotate(0, turnAmount, 0);
    }
}
