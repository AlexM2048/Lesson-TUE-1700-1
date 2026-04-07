using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    // Чтобы колизии отрабытывали необходимо:
    // 1. Оба объекта должны иметь Collider'ы
    // 2. Хотя бы один из объектов должени иметь Rigidbody (not Kinematic)


    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter сработал!");
    }

    private void OnTriggerStay(Collider other)
    {
        print("OnTriggerStay сработал!");
    }

    private void OnTriggerExit(Collider other)
    {
        print("OnTriggerExit сработал!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter сработал!"); ;
    }

    private void OnCollisionStay(Collision collision)
    {
        print("OnCollisionStay сработал!");
    }

    private void OnCollisionExit(Collision collision)
    {
        print("OnCollisionExit сработал!");
    }
}
