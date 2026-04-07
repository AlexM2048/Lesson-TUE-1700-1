using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponConfig config;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private AudioSource audioSource;

    private float _timer;
    private float _currentProjcetileAmount;

    private bool _isReloading = false;
    private float _reloadTimer;

    private void Start()
    {
        _currentProjcetileAmount = config.maxProjectileAmount;
    }

    private void Update()
    {
        HandleReload();
        HandleTimer();

        // Если клавиша R нажата и мы не перезаряжаемся
        if (Input.GetKeyDown(KeyCode.R) && !_isReloading)
        {
            Reload();
        }

        if (ShootButtonPressed())
        {
            // Если патронов больше нкля
            if (_currentProjcetileAmount > 0)
            {
                if (_timer <= 0)
                {
                    // Стреляем
                    Shoot();
                }
            }
            // Если автоперезарядка и сейчас не перезарежаемcя
            else if (config.autoReload && !_isReloading)
            {
                // Перезарежаемся
                Reload();
            }
        }         
    } 
    
    // Можем ли мы стрелять?
    private bool ShootButtonPressed()
    {
        // Если оружие автоматическое
        if (config.automatic)
        {
            // Возрашаем зажатие ЛКМ
            return Input.GetMouseButton(0);
        }
        // Если оружие не автоматическое
        else
        {
            // Возращаем нажатие ЛКМ
            return Input.GetMouseButtonDown(0);
        }
    }

    private void HandleTimer()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        var projectile = Instantiate(config.prefab);

        projectile.transform.SetPositionAndRotation(
            spawnPoint.position, 
            spawnPoint.rotation * projectile.offset
        );
        projectile.SetDirection(spawnPoint.forward);

        _timer = config.timeBetweenShoots;
        _currentProjcetileAmount--;

        audioSource.PlayOneShot(config.shootSound);
    }

    private void Reload()
    {
        _isReloading = true;
        _reloadTimer = config.reloadTime;

        audioSource.PlayOneShot(config.reloadSound);
    }

    private void HandleReload()
    {
        // Если перезаркжаемя
        if (_isReloading)
        {
            // Если таймер перезарядки больше нуля
            if (_reloadTimer > 0)
            {
                // Обновляем наш таймер
                _reloadTimer -= Time.deltaTime;
            }
            // Иначе перезарядка окончена
            else
            {
                _isReloading = false;
                _reloadTimer = 0;

                _currentProjcetileAmount = config.maxProjectileAmount;

                audioSource.PlayOneShot(config.reloadSound);
            }
        }
    }
}
