using Assets;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public GameObject loginScreen;
    public GameObject worldScreen;
    public GameObject mainScreen;
    public GameObject worldEditScreen;
    public Image backGround;

    public TMPro.TMP_InputField inputUserName;
    public TMPro.TMP_InputField inputPassword;
    public TMPro.TMP_Text errorText;
    public TMPro.TMP_Dropdown Dropdown;

    public Environment2d selectedWorld;

    public int sizeIncrease = 4;

    public System.Collections.Generic.List<Environment2d> environment = new System.Collections.Generic.List<Environment2d>
    {
        new () { Id = 1, Name = "wereld 1" },
        new () { Id = 2, Name = "wereld 2" },
    };


    public void Start()
    {
        // Set background size using sizeDelta, not rect.width/height (rect is a struct, not a variable)
        var rectTransform = backGround.rectTransform;
        rectTransform.sizeDelta = new Vector2(Screen.width * sizeIncrease, Screen.height * sizeIncrease);
        rectTransform.anchoredPosition = new Vector2(-Screen.width * 1.5f, -Screen.height * 1.5f); // Center the background
        HideAllScreens();
        loginScreen.SetActive(true);
    }
    public void OnLogin()
    {
        Debug.Log($"Attempting login for {inputUserName.text}");
        //if (inputUserName.text == "admin" && inputPassword.text == "password")
        //{
        HideAllScreens();

        StartCoroutine(AnimateBackground());

        foreach (var env in environment)
        {
            Dropdown.options.Add(new()
                {
                text = env.Name
                }
            );
        }
        mainScreen.SetActive(true);
        //}
        //else
        //{
        //    ChangeErrorMessage("Invalid username or password.");
        //}
    }
    
    public void EditWorld()
    {
        HideAllScreens();
        worldEditScreen.SetActive(true);

        int environmentIndex = Dropdown.value;
        selectedWorld = environment[environmentIndex];


    }
    private System.Collections.IEnumerator AnimateBackground()
    {
        var rectTransform = backGround.rectTransform;
        var startSize = rectTransform.sizeDelta;
        var startPos = rectTransform.anchoredPosition;
        var targetSize = new Vector2(Screen.width, Screen.height);
        var targetPos = Vector2.zero;
        float duration = 0.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            t = t * t * (3f - 2f * t); // Smoothstep
            rectTransform.sizeDelta = Vector2.Lerp(startSize, targetSize, t);
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);
            yield return null;
        }

        rectTransform.sizeDelta = targetSize;
        rectTransform.anchoredPosition = targetPos;
    }

    public void HideAllScreens()
    {
        loginScreen.SetActive(false);
        worldScreen.SetActive(false);
        mainScreen.SetActive(false);
        worldEditScreen.SetActive(false);
    }

    public void ChangeErrorMessage(string message)
    {
        errorText.text = message;
    }
}
