using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public UIManager ui; 
        
    
    public void OnActionButtonClicked()
    {
       
        ui.UpdateLabel("Button geklikt! Tekst is aangepast 🎉");
    }
}
