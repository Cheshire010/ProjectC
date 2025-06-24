using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCarManager : MonoBehaviour
{
    public Load_Car carSpawn;
   public void SetCar_Santafe()
    {
        Car_Static.LoadCarValue = 0;
        carSpawn.SpawnCar();
    }
}
