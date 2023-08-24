using UnityEngine;

public class MoveTank : MonoBehaviour
{
    public float speed = 20f;
    public float acceleration = 5f; // 
    public float deceleration = 10f;
    public float rotationSpeed = 100f;
    public float tiltAngle = 30f; // угол уклона

    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        //Применяем ускорение или торможение на основе ввода игрока
        if (moveVertical != 0)
        {
            float targetSpeed; // не сокращая (скорость)
            if (moveVertical > 0)
            {
                targetSpeed = speed;
            }
            else
            {
                targetSpeed = -speed;
            }
            float force = moveVertical > 0 ? acceleration : deceleration; // в сокращении (движение)

            if (Mathf.Abs(rig.velocity.magnitude) < Mathf.Abs(targetSpeed))
            {
                rig.AddRelativeForce(Vector3.forward * force * moveVertical);
            }
        }

        // поднимаем танк при старте или езде назад
        float tiltAmount = moveVertical * tiltAngle / speed;
        Vector3 eulerRotation = new Vector3(-tiltAmount, 0, 0);
        transform.localEulerAngles = eulerRotation;
    }
}
