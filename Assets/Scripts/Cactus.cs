using UnityEngine;

public class Cactus : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Physics.BoxCast(
            transform.position, 
            transform.localScale / 2, 
            Vector3.zero, 
            out var hitInfo)
        )
        {
            if (hitInfo.collider.TryGetComponent(out Health health))
            {
                health.Damage(1);
            }
        }
    }
}
