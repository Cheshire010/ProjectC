using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] Camera_Loaction;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Camera_Loaction[Car_Static.LoadCarValue].transform.position;
    }
}
