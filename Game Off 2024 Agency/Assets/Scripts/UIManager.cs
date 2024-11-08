using UnityEngine;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private GameObject currentWindow;
    private Dictionary<string, GameObject> windowDict = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Open or switch to a new window, closing any existing window first
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

        // Store it in the dictionary by its name, for reference if needed
        if (!windowDict.ContainsKey(newWindow.name))
        {
            windowDict[newWindow.name] = newWindow;
        }
    }

    // Open an "Info" window, bypassing the stack so it stays temporary
    public void OpenInfoWindow(GameObject infoWindow)
    {
        // Close any current window temporarily
        if (currentWindow != null)
        {
            currentWindow.SetActive(false);
        }

        // Show the info window
        infoWindow.SetActive(true);

        // This does not set `currentWindow` since we want it to be temporary
    }

    // Close the current window and restore the previous main one
    public void CloseCurrentWindow()
    {
        if (currentWindow != null)
        {
            currentWindow.SetActive(false);
            currentWindow = null;
        }
    }

    // Reopen the main HUD window if necessary
    public void BackToHUD()
    {
        if (currentWindow != null)
        {
            currentWindow.SetActive(false);
            currentWindow = null;
        }
        // If you have a specific HUD GameObject, set it active here:
        // e.g., hudWindow.SetActive(true);
    }
}
