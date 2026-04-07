using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth = 100;

    // Публичное событие типа Action<float, float>,
    // которое будет вызываться при изменении здоровья 
    public event Action<float, float> HealthChangedEvent;

    // Публичное событие типа Action,
    // которое будет вызываться при смерти
    public event Action DeathEvent;

    public void Damage(float damageAmount)
    {
        if (damageAmount < 0)
        {
            return;
        }

        currentHealth -= damageAmount;

        // Если здоровье меньше нуля, то мы погибли
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DeathEvent?.Invoke();
        }

        HealthChangedEvent?.Invoke(currentHealth, maxHealth);
    }

    public void Heal(float healAmount)
    {
        if (healAmount < 0)
        {
            return;
        }

        currentHealth += healAmount;

        // Если здоровье больше максимального, то мы приравниваем к максимальному
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        HealthChangedEvent?.Invoke(currentHealth, maxHealth);
    }
}
