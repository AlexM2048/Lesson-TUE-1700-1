using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public static event Action PickUpEvent;

    private void OnDestroy()
    {
        PickUpEvent?.Invoke();
    }
}
