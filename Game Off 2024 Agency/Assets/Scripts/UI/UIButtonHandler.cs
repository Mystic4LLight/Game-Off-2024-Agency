using UnityEngine;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    public ButtonType buttonType;
    public GameObject targetWindow; // The window to open (main window, world window, etc.)
    public GameObject infoWindow; // The info window to open if the button is for info

    public enum ButtonType
    {
        Close,         // Close the current window
        OpenWindow,    // Open a specific window (like the main game or any other)
        Info,          // Open an info window
        CloseInfo      // Close the info window
    }

    private void Start()
    {
        // Adding listener to button
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
{
    GameLogger.Log($"Button clicked: {buttonType}");
    
    switch (buttonType)
    {
        case ButtonType.Close:
            GameLogger.Log("Attempting to close current window.");
            UIManager.Instance.CloseCurrentWindow();
            break;

        case ButtonType.OpenWindow:
            if (targetWindow != null)
            {
                GameLogger.Log($"Attempting to open window: {targetWindow.name}");
                UIManager.Instance.OpenWindow(targetWindow);
            }
            break;

        case ButtonType.Info:
            if (infoWindow != null)
            {
                GameLogger.Log($"Attempting to open info window: {infoWindow.name}");
                UIManager.Instance.OpenInfoWindow(infoWindow);
            }
            break;

        case ButtonType.CloseInfo:
            GameLogger.Log("Attempting to close info window.");
            UIManager.Instance.CloseInfoWindow();
            break;
    }
}

}
