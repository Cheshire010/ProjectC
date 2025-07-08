using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Car : MonoBehaviour
{
    public GameObject Spawnlocation;
    public GameObject[] Cars;
    GameObject SpawnCarObject;

    //bool carSpawned = false;
    // Start is called before the first frame update
    public void SpawnCar()
    {
        //if (carSpawned) return;
        if(SpawnCarObject == null)
        {
            Vector3 spawnPos = Spawnlocation.transform.position + Vector3.up * 0.5f;
             SpawnCarObject = Instantiate(Cars[Car_Static.LoadCarValue], spawnPos, Quaternion.identity);
            SpawnCarObject.AddComponent<CarAutoRotate>();
        }
        if (SpawnCarObject != null)
        {
            if (Cars[Car_Static.LoadCarValue].name == SpawnCarObject.name) return;
            else if (Cars[Car_Static.LoadCarValue].name != SpawnCarObject.name)
            {
                Destroy(SpawnCarObject);
                Vector3 spawnPos = Spawnlocation.transform.position + Vector3.up * 0.5f;
                SpawnCarObject = Instantiate(Cars[Car_Static.LoadCarValue], spawnPos, Quaternion.identity);
                SpawnCarObject.AddComponent<CarAutoRotate>();
            }
        }

    }
}
