using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3 (0,0,-20.0f)*Time.deltaTime*1, Space.World);

        if(transform.position.z < -100.0f)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
