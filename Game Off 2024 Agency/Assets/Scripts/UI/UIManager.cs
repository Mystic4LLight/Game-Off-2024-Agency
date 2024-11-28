using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject[] windows; // All windows in the UI
    private GameObject currentWindow; // The currently active window
    private GameObject infoWindow; // Reference for the info window (this is separate from other windows)

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Open a specific window, closing any currently open window first
    public void OpenWindow(GameObject newWindow)
    {
        // Check if the window is already open
        if (currentWindow == newWindow)
        {
            return; // No need to reopen the same window
        }

        // Close the current window if it's open
        if (currentWindow != null)
        {
            currentWindow.SetActive(false);
        }

        // Activate the new window
        currentWindow = newWindow;
        currentWindow.SetActive(true);
        GameLogger.Log($"Opened window: {newWindow.name}");
    }

    // Open an "Info" window, bypassing the stack so it stays temporary
    public void OpenInfoWindow(GameObject infoWindow)
    {
        this.infoWindow = infoWindow;
        infoWindow.SetActive(true); // Open the info window
        GameLogger.Log("Info Window Opened!");
    }

    // Close the info window without affecting the main window
    public void CloseInfoWindow()
    {
        if (infoWindow != null)
        {
            infoWindow.SetActive(false);
            infoWindow = null; // Clear the reference once it's closed
            GameLogger.Log("Info Window Closed!");
        }
    }

    // Close the current window and restore the previous main one
    public void CloseCurrentWindow()
    {
        if (currentWindow != null)
        {
            currentWindow.SetActive(false);
            currentWindow = null;
            GameLogger.Log("Main Window Closed!");
        }
    }
}
