
using UnityEngine;

public class PanelToggler : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
       panel.SetActive(false); 
    }

    public void TogglePanel()
    {
        bool shouldShow = panel.activeSelf;
        panel.SetActive(!shouldShow);
    }
}
