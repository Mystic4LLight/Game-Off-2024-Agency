using UnityEngine;

public class AgentMenu : MonoBehaviour
{
    public AgentPanel agentPanel; // Reference to the AgentPanel

    private void Start()
    {
        if (agentPanel != null)
        {
            // Access the agentSO via the getter
            AgentSO agent = agentPanel.AgentSO;
            if (agent != null)
            {
                Debug.Log($"Agent selected: {agent.agentName}");
            }
            else
            {
                Debug.LogWarning("No agent assigned to the panel.");
            }
        }
        else
        {
            Debug.LogWarning("AgentPanel is not assigned in AgentMenu.");
        }
    }
}
