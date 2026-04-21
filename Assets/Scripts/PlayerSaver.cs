using Unity.VisualScripting;
using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    const string PlayerPositionKey = "PlayerPosition";

    [SerializeField] private Transform player;

    private void Awake()
    {       
        if (PlayerPrefs.HasKey(PlayerPositionKey))
        {
            var json = PlayerPrefs.GetString(PlayerPositionKey);
            player.position = JsonUtility.FromJson<Vector3>(json);
        }
    }

    private void OnApplicationQuit()
    { 
        var position = player.position;
        var json = JsonUtility.ToJson(position);

        PlayerPrefs.SetString(PlayerPositionKey, json);
    }
}
