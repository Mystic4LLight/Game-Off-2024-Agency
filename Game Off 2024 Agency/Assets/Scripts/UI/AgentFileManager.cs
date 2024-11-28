using UnityEngine;

public class AgentFileManager : MonoBehaviour
{
    public static AgentFileManager Instance;

    [SerializeField] public AgentUI agentUI; // Reference to the entire AgentUI prefab

    private AgentUI activeAgentUI; // Reference to the currently open AgentUI
    public GameObject hud; // Reference to HUD
    public Camera mainCamera; // Reference to main camera
    public GameObject[] roomButtons; // Array of all room buttons to disable

    public void Initialize(AgentSO agentSO)
    {
        if (agentUI != null)
        {
            agentUI.agentSO = agentSO;
        }
        else
        {
            GameLogger.LogError("AgentUI reference is missing in AgentFileActivator.");
        }
    }

    private void Awake()
    {
        // Singleton pattern to ensure only one instance
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void OpenAgentFile(AgentUI agentUI)
    {
        // Close the currently active AgentUI if it exists
        if (activeAgentUI != null)
        {
            activeAgentUI.SetViewMode(true); // Switch back to card view
        }

        // Set the new active AgentUI
        activeAgentUI = agentUI;
        activeAgentUI.SetViewMode(false); // Switch to detailed view

        // Center the AgentUI on the screen
        CenterAgentUI(activeAgentUI);

        // Disable HUD, camera movement, and room buttons
        if (hud != null) hud.SetActive(false);
        if (mainCamera != null) mainCamera.GetComponent<CameraController2D>().enabled = false; // Assuming you have a script like CameraController managing movement
        foreach (GameObject button in roomButtons)
        {
            button.SetActive(false);
        }
    }

    public void CloseAgentFile()
    {
        // Close the active agent file and revert settings
        if (activeAgentUI != null)
        {
            activeAgentUI.SetViewMode(true); // Switch back to card view
            activeAgentUI = null;

            // Re-enable HUD, camera movement, and room buttons
            if (hud != null) hud.SetActive(true);
            if (mainCamera != null) mainCamera.GetComponent<CameraController2D>().enabled = true;
            foreach (GameObject button in roomButtons)
            {
                button.SetActive(true);
            }
        }
    }

    public bool HasOpenAgentFile()
    {
        return activeAgentUI != null;
    }

    private void CenterAgentUI(AgentUI agentUI)
    {
        // Set the position of the AgentUI to the center of the screen
        RectTransform rectTransform = agentUI.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}
