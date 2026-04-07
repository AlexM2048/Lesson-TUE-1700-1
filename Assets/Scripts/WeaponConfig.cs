using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "ScriptableObjects/WeaponConfig", order = 1)]
public class WeaponConfig : ScriptableObject
{
    [Header("Shoot")]
    public Projectile prefab;
    public float timeBetweenShoots = 1f;
    public int maxProjectileAmount = 10;
    public bool automatic = true;

    [Header("Reload")]
    public float reloadTime = 5f;
    public bool autoReload = true; 

    [Header("Sound")]
    public AudioClip shootSound;
    public AudioClip reloadSound;
}
