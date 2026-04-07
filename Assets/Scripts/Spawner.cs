using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float timeToSpawn = 3f;

    private float _timer;

    private void Update()
    {
        if (_timer <= 0)
        {
            _timer = timeToSpawn;
            Spawn();
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }

    private void Spawn()
    {
        var instance = Instantiate(prefab);

        var x = Random.Range(-radius, radius);
        var z = Random.Range(-radius, radius);

        instance.transform.position = new Vector3(x, 0, z) + transform.position;
    }
}
