using UnityEngine;

public class MoveTankTorret : MonoBehaviour
{
    public Transform turretTransform;

    public float rotationSpeed = 5f;
    public float maxRotationUp = 70f; // подьем вверх
    public float maxRotationDown = 10f; // подьем вниз

    public float maxRotationLeft = 30f; // вращение влево
    public float maxRotationRight = 30f; // вращение вправо

    private float turretRotationUpDown = 0f; // нынешнее
    private float turretRotationLeftRight = 0f; // нынешнее

    private void Update()
    {
        float mouseInputX = Input.GetAxis("Mouse Y");
        turretRotationUpDown += -mouseInputX * rotationSpeed;
        turretRotationUpDown = Mathf.Clamp(turretRotationUpDown, -maxRotationUp, maxRotationDown);

        float mouseInputZ = Input.GetAxis("Mouse X");
        turretRotationLeftRight += mouseInputZ * rotationSpeed;
        turretRotationLeftRight = Mathf.Clamp(turretRotationLeftRight, -maxRotationRight, maxRotationLeft);

        // Применяем вращение вокруг осей Y и X
        Quaternion newRotation = Quaternion.Euler(turretRotationUpDown, 0f, turretRotationLeftRight);
        turretTransform.localRotation = newRotation;
    }
}
