using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand_Move : MonoBehaviour
{
    GameObject right_hand;
    // Start is called before the first frame update
    void Start()
    {
        right_hand = GameObject.Find("RightHandAnchor");
        transform.position = right_hand.transform.position;
        transform.parent = right_hand.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
