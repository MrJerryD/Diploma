using UnityEngine;

public class TankFire : MonoBehaviour
{
    public Transform firePoint; // Точка выстрела
    public GameObject projectilePrefab;

    public float shootForce = 10f;
    public float recoilForce = 5f; // Сила отдачи танка

    public ParticleSystem muzzleSmoke; // Ссылка на Particle System дыма

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Получаем позицию и поворот точки выстрела
            Vector3 firePosition = firePoint.position;
            Quaternion fireRotation = firePoint.rotation;

            // Создаем новый экземпляр снаряда из префаба
            GameObject projectile = Instantiate(projectilePrefab, firePosition, fireRotation);

            // Получаем Rigidbody снаряда
            Rigidbody projectileRb = projectile.GetComponentInChildren<Rigidbody>();

            // Применяем силу вперед для движения снаряда
            projectileRb.AddForce(firePoint.forward * shootForce, ForceMode.Impulse);

            // Применяем силу назад для отдачи танка
            Rigidbody tankRb = GetComponent<Rigidbody>();
            tankRb.AddForce(-transform.forward * recoilForce, ForceMode.Impulse);

            // Воспроизведение эффекта дыма
            if (muzzleSmoke != null)
            {
                muzzleSmoke.Play();
            }
        }
    }
}
