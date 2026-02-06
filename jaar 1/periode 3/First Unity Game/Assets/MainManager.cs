using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject worldSelectScreen;
    public void OnPlayButtonClicked()
    {
        gameObject.SetActive(false);
        worldSelectScreen.SetActive(true);
    }
}
