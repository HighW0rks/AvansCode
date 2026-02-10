
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text label; 

    public string naam = "Student";
    public int a = 3;
    public int b = 7;

    void Start()
    {
        label.text = $"Welkom {naam}! Som: {a} + {b} = {a + b}";
    }

    public void UpdateLabel(string newText)
    {
        label.text = newText;
    }
}
