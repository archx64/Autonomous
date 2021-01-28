using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;

    private float distance = 15.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private readonly float Sensitivity = 5f;

    private void Update()
    {
        currentX += Input.GetAxis("Mouse Y") * -Sensitivity;
        currentY += Input.GetAxis("Mouse X") * Sensitivity;
        currentX = Mathf.Clamp(currentX, 10, 90);

        distance -= Input.GetKey(KeyCode.I) ? 0.1f : 0f;
        distance += Input.GetKey(KeyCode.U) ? 0.1f : 0f;
        distance = Mathf.Clamp(distance, 2.5f, 100);
    }

    private void LateUpdate()
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
        transform.position = target.position + rotation * direction;
        transform.LookAt(target.position);
    }
}
