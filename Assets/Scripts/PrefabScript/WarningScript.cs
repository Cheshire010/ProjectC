using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningScript : MonoBehaviour
{
    BoxCollider Box;
    public GameObject Light;
    // Start is called before the first frame update
    void Start()
    {
        Box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        Light.GetComponent<Image>().material.color = Color.red;
    }
    private void OnTriggerExit(Collider other)
    {
        Light.GetComponent<Image>().material.color = Color.white;
    }
}
