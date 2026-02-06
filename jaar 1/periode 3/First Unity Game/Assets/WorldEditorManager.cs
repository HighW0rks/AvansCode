using TMPro;
using UnityEngine;

public class WorldEditorManager : MonoBehaviour
{
    public ScreenManager screenmanager;
    public TMP_Text selectedWorldLabel;

    void Start()
    {
        if (screenmanager.selectedWorld != null)
        {
            selectedWorldLabel.text = screenmanager.selectedWorld.Name;

        }
        else
        {
            Debug.LogWarning("No world selected");
        }
    }
}