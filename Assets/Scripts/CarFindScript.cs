using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFindScript : MonoBehaviour
{
    TestScript TestScript;
    
    // Start is called before the first frame update
    void Start()
    {
        TestScript = GameObject.Find("").GetComponent<TestScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
