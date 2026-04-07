using TMPro;
using UnityEngine;

public class PickUpUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private int counter = 0;

    private void Start()
    {
        text.text = "Поднято предметов: 0";

        PickUp.PickUpEvent += AddOneMore;
    }

    public void AddOneMore()
    {
        counter++;
        text.text = $"Поднято предметов: {counter}";
    }
}
