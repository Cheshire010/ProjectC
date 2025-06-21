using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_hand : MonoBehaviour
{
    GameObject left_hand;
    // Start is called before the first frame update
    void Start()
    {
        left_hand = GameObject.Find("LeftHandAnchor");
        transform.position = left_hand.transform.position;
        transform.parent = left_hand.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
