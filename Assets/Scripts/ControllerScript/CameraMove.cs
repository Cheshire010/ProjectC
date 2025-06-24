using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject player;
    Vector3 myPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        myPos = player.transform.position;
        myPos.y += 1.0f;
        myPos.z += 0.5f;
        transform.position = myPos;
    }
}
