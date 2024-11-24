using UnityEngine;

public class AgentFileActivator : MonoBehaviour
{
    [Header("References")]
    public GameObject agentFileUI; // Add this property for external assignment
    private AgentPanel agentPanel; // Reference to the AgentPanel script
    private AgentSO agentSO;       // The AgentSO for this specific agent

    private void Awake()
    {
        // Find the AgentPanel on the agentFileUI if assigned
        if (agentFileUI != null)
        {
            agentPanel = agentFileUI.GetComponent<AgentPanel>();
            if (agentPanel == null)
            {
                Debug.LogError("AgentPanel is missing in the assigned AgentFileUI GameObject.");
            }
        }
        else
        {
            Debug.LogError("AgentFile GameObject is not assigned in the AgentFileActivator.");
        }
    }

    /// <summary>
    /// Initializes the activator with the associated AgentSO.
    /// </summary>
    public void Initialize(AgentSO agent)
    {
        agentSO = agent;
    }

    /// <summary>
    /// Opens the AgentFile UI and updates it with the agent's data.
    /// </summary>
    public void ShowAgentFile()
    {
        if (agentFileUI != null && agentPanel != null && agentSO != null)
        {
            agentFileUI.SetActive(true); // Activate the AgentFile UI
            agentPanel.Initialize(agentSO); // Update the AgentFile UI with the agent's data
            Debug.Log($"AgentFile opened for agent: {agentSO.agentName}");
        }
        else
        {
            Debug.LogError("Missing references in AgentFileActivator! Ensure all fields are properly assigned.");
        }
    }

    /// <summary>
    /// Closes the AgentFile UI.
    /// </summary>
    public void CloseAgentFile()
    {
        if (agentFileUI != null)
        {
            agentFileUI.SetActive(false);
        }
    }
}
