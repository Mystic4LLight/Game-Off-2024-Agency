using UnityEngine;

public class AgentFileActivator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public AgentUI agentUI; // Reference to the entire AgentUI prefab

    // Initialization method for setting the AgentSO
    public void Initialize(AgentSO agentSO)
    {
        if (agentUI != null)
        {
            agentUI.agentSO = agentSO; // Assign the AgentSO to the AgentUI prefab
        }
        else
        {
            GameLogger.LogError("AgentUI reference is missing in AgentFileActivator.");
        }
    }

    /// <summary>
    /// Opens the Agent File UI by notifying the AgentFileManager.
    /// </summary>
    public void ShowAgentFile()
    {
        if (agentUI != null && AgentFileManager.Instance != null)
        {
            // Only open if no other agent file is currently open
            if (!AgentFileManager.Instance.HasOpenAgentFile())
            {
                AgentFileManager.Instance.OpenAgentFile(agentUI);
            }
            else
            {
                GameLogger.LogWarning("Another Agent File is already open. Please close it first.");
            }
        }
        else
        {
            GameLogger.LogWarning("AgentUI or AgentFileManager is not properly assigned.");
        }
    }

    /// <summary>
    /// Closes the Agent File UI by notifying the AgentFileManager.
    /// </summary>
    public void CloseAgentFile()
    {
        if (AgentFileManager.Instance != null)
        {
            AgentFileManager.Instance.CloseAgentFile();
        }
    }
}
