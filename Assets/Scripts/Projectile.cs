using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxLiveTime = 5f;

    public Quaternion offset = Quaternion.Euler(0, 180, 0);

    private float _liveTime;
    private Vector3 _direction;

    // Устанавливаем направления движения снаряда
    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    // Двигаем наш снаряд
    private void Move()
    {
        transform.position += _direction * speed;
    }

    private void Raycast()
    {
        Debug.DrawRay(transform.position, _direction * speed, Color.red);
        if (Physics.Raycast(transform.position, _direction, out var hitInfo, speed))
        {
            if (hitInfo.collider.TryGetComponent(out Health health))
            {
                health.Damage(5);
            }

            Destroy(gameObject);
        }
    }

    private void HandleLiveTime()
    {
        _liveTime += Time.deltaTime;

        if (_liveTime >= maxLiveTime)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        HandleLiveTime();
    }

    // FixedUpdate вызывается 50 раз в секунду с равными интервалами
    private void FixedUpdate()
    {
        Move();
        Raycast();
    }
}
