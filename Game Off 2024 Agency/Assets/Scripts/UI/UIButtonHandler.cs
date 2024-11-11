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
        switch (buttonType)
        {
            case ButtonType.Close:
                UIManager.Instance.CloseCurrentWindow(); // Close the current window
                break;

            case ButtonType.OpenWindow:
                if (targetWindow != null)
                {
                    UIManager.Instance.OpenWindow(targetWindow); // Open a specific window
                }
                break;

            case ButtonType.Info:
                if (infoWindow != null)
                {
                    UIManager.Instance.OpenInfoWindow(infoWindow); // Open the info window
                }
                break;

            case ButtonType.CloseInfo:
                UIManager.Instance.CloseInfoWindow(); // Close the info window
                break;
        }
    }
}
