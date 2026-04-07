using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image image;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        health.HealthChangedEvent += OnHealthChanged;
    }

    private void OnDisable()
    {
        health.HealthChangedEvent -= OnHealthChanged;
    }

    private void Update()
    {
        transform.LookAt(mainCamera.transform.position);
    }

    // Здесь мы будем обновлять UI, который отображает здоровье врага
    private void OnHealthChanged(float currentHealth, float maxHealth)
    {
        image.fillAmount = currentHealth / maxHealth;
    }
}
