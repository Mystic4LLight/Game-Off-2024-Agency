using UnityEngine;

public class ActiveAgentsMenu : MonoBehaviour
{
    public AgentPanel[] agentPanels; // Array of agent panels

    private void Start()
    {
        foreach (var agentPanel in agentPanels)
        {
            if (agentPanel != null)
            {
                // Access the AgentSO using the public property
                AgentSO agent = agentPanel.agentSO;

                if (agent != null)
                {
                    GameLogger.Log($"Active Agent: {agent.agentName}");
                }
                else
                {
                    GameLogger.LogWarning("No AgentSO assigned to this panel.");
                }
            }
        }
    }
}
