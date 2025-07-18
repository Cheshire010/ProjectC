using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 myVec = Vector3.zero;
    float speed = 2.0f;
    float turnangle = 45f;
    float inputThreshold = 0.8f;
    bool hasTurned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        myVec = new Vector3(input.x, 0, input.y);
        transform.Translate(myVec * speed * Time.deltaTime);

        Vector2 turninput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        
        if(!hasTurned)
        {
            if (turninput.x >  inputThreshold)
            {
                transform.Rotate(0, turnangle, 0);
                hasTurned = true;
            }
            else if(turninput.x < -inputThreshold)
            {
                transform.Rotate(0, -turnangle, 0);
                hasTurned = true;
            }
        }
        if (Mathf.Abs(turninput.x) < 0.2f)
        {
            hasTurned = false;
        }
    }
}
