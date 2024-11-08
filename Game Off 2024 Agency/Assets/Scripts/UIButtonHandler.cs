using UnityEngine;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    public ButtonType buttonType;
    public GameObject targetWindow; // The window to open for the OpenWindow button type
    public enum ButtonType
{
    Close,
    Submit,
    OpenWindow, // New button type for opening a specific window
    Info,
    // Other button types...
}


    private void Start()
    {
        // Assuming there's a button component on this GameObject
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        switch (buttonType)
        {
            case ButtonType.Close:
                UIManager.Instance.CloseCurrentWindow();
                break;
            case ButtonType.Submit:
                // Your Submit logic here
                break;
            case ButtonType.OpenWindow:
                OpenSpecificWindow();
                break;
            case ButtonType.Info:
                UIManager.Instance.OpenInfoWindow(targetWindow);
                break;
            // Other cases...
        }
    }

    private void OpenSpecificWindow()
    {
        if (targetWindow != null)
        {
            UIManager.Instance.OpenWindow(targetWindow);
        }
        else
        {
            Debug.LogWarning("No target window assigned for OpenWindow button type.");
        }
    }
}
