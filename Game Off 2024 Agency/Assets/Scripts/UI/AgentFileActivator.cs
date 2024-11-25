using UnityEngine;

public class AgentFileActivator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public GameObject agentFileUI; // UI to display agent file
    public AgentPanel agentPanel; // Panel that handles agent UI
    public AgentSO agentSO; // The agent to display

    private void Awake()
    {
        // Ensure the agent panel is assigned
        if (agentFileUI != null)
        {
            agentPanel = agentFileUI.GetComponent<AgentPanel>();
            if (agentPanel == null)
            {
                Debug.LogError("AgentPanel component is missing on the assigned AgentFileUI GameObject.");
            }
        }
        else
        {
            Debug.LogError("AgentFileUI GameObject is not assigned.");
        }
    }

    /// <summary>
    /// Assigns an agent to the activator.
    /// </summary>
    public void Initialize(AgentSO newAgent)
    {
        agentSO = newAgent;
    }

    /// <summary>
    /// Opens the Agent File UI and initializes it with the agent's data.
    /// </summary>
    public void ShowAgentFile()
    {
        if (agentFileUI != null && agentPanel != null && agentSO != null)
        {
            agentFileUI.SetActive(true);
            agentPanel.Initialize(agentSO); // Pass the Agent to the panel
            Debug.Log($"Agent File opened for agent: {agentSO.agentName}");
        }
        else
        {
            Debug.LogError("Missing references in AgentFileActivator. Ensure all fields are properly assigned.");
        }
    }

    /// <summary>
    /// Closes the Agent File UI.
    /// </summary>
    public void CloseAgentFile()
    {
        if (agentFileUI != null)
        {
            agentFileUI.SetActive(false);
        }
    }
}
