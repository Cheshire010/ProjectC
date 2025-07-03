using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Car : MonoBehaviour
{
    public GameObject Spawnlocation;
    public GameObject[] Cars;
    // Start is called before the first frame update
    public void SpawnCar()
    {
        Vector3 spawnPos = Spawnlocation.transform.position + Vector3.up * 0.5f;
        GameObject newCar = Instantiate(Cars[Car_Static.LoadCarValue], spawnPos, Quaternion.identity);
        newCar.AddComponent<CarAutoRotate>();
    }
}
