using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 size;

    private void FixedUpdate()
    {
        if (Physics.BoxCast(
            transform.position + offset, 
            size / 2, 
            Vector3.up, 
            out var hitInfo)
        )
        {
            if (hitInfo.collider.TryGetComponent(out Health health))
            {
                health.Damage(1);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + offset, size);
    }
}
