using UnityEngine;

public class RotationZ : MonoBehaviour
{
    public float rotationSpeed = 80f;
    public float returnSpeed = 100f;

    private float currentZ = 0f;
    private const float fixedX = -160f;

    void Update()
    {
        float horizontalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;

        if (Mathf.Abs(horizontalInput) > 0.01f)
        {
            currentZ += horizontalInput * rotationSpeed * Time.deltaTime;
        }
        else
        {
            currentZ = Mathf.MoveTowardsAngle(currentZ, 0f, returnSpeed * Time.deltaTime);
        }

        // X축은 항상 -160°, Z축만 누적
        transform.rotation = Quaternion.Euler(fixedX, 0f, currentZ);
    }

    public float GetCurrentZ()
    {
        return currentZ;
    }
}
