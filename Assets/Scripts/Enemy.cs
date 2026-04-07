using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health health;

    private void OnEnable()
    {
        health.DeathEvent += OnDeath;
    }

    private void OnDisable()
    {
        health.DeathEvent -= OnDeath;
    }

    private void OnDeath()
    {
        print("Я погиб(");

        transform.rotation = Quaternion.Euler(90, 0, 0);

        Invoke(nameof(DestroySelf), 3);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
