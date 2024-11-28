using UnityEngine;

public class AgentMenu : MonoBehaviour
{
    public AgentPanel agentPanel;
    private AgentSO AgentSO;

    private void Start()
    {
        if (agentPanel != null)
        {
            // Access the agentSO via the getter
            AgentSO agent = agentPanel.agentSO;
            if (agent != null)
            {
                GameLogger.Log($"Agent selected: {agent.agentName}");
            }
            else
            {
                GameLogger.LogWarning("No agent assigned to the panel.");
            }
        }
        else
        {
            GameLogger.LogWarning("AgentPanel is not assigned in AgentMenu.");
        }
    }
}
