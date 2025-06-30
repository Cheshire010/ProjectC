using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Car_Final : MonoBehaviour
{
    public GameObject Spawnlocation;
    public GameObject[] Cars;
    // Start is called before the first frame update
    private void Start()
    {
        GameObject go = Instantiate(Cars[Car_Static.LoadCarValue], Spawnlocation.transform.position, Quaternion.identity);
    }
    
}
