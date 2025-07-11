using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public GameObject[] Halo;
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;

    public GameObject ParkingCar;

    public float wheelRotateSpeed = 10f;

    private Vector3 lastPosition;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        if (ParkingCar == null)
            ParkingCar = GameObject.Find("JYJ_Santafe_Final_1(Clone)");
        lastPosition = ParkingCar != null ? ParkingCar.transform.position : Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (ParkingCar == null) return;

        Vector3 currentPosition = ParkingCar.transform.position;
        isMoving = (currentPosition != lastPosition);

        Vector3 moveDir = currentPosition - lastPosition;
        lastPosition = currentPosition;

        foreach (var halo in Halo)
            if (halo != null) halo.SetActive(isMoving);

        if (isMoving)
        {
            Vector3 forward = ParkingCar.transform.forward;
            float dot = Vector3.Dot(forward, moveDir.normalized);

            Vector3 rotateDir = (dot >= 0) ? Vector3.left : Vector3.right;

            foreach (var wheel in leftWheels)
                if (wheel != null)
                    wheel.transform.Rotate(rotateDir * wheelRotateSpeed * Time.deltaTime);

            foreach (var wheel in rightWheels)
                if (wheel != null)
                    wheel.transform.Rotate(-rotateDir * wheelRotateSpeed * Time.deltaTime);
        }
    }

}
