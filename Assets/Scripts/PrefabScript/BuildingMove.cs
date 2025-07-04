using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate( - Vector3.forward * Time.deltaTime * 20, Space.World);

        if (transform.position.z < -100.0f)
        {
            transform.position = transform.position + new Vector3(0, 0, 240);
        }
    }
}
