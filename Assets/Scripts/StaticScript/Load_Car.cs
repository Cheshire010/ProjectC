using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Car : MonoBehaviour
{
    public GameObject Spawnlocation;
    public GameObject[] Cars;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Cars[Car_Static.LoadCarValue], Spawnlocation.transform.position, Quaternion.identity);
    }
}
