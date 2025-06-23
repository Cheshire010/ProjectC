using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetCarManager : MonoBehaviour
{
   public void SetCar_Santafe()
    {
        Car_Static.LoadCarValue = 0;
        SceneManager.LoadScene("SetOptionScene");
    }
}
