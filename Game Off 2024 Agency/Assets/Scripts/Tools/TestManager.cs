using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject agentUI; // The prefab or parent object containing the AgentPanel
    private AgentPanel agentPanel; // Reference to the AgentPanel

    private void Start()
    {
        // Example: Assuming agentUI is already instantiated elsewhere
        if (agentUI == null)
        {
            Debug.LogError("AgentUI is not assigned in TestManager!");
            return;
        }

        // Find the AgentPanel in the children of agentUI
        agentPanel = agentUI.GetComponentInChildren<AgentPanel>();

        if (agentPanel == null)
        {
            Debug.LogError("AgentPanel component is missing in the children of AgentUI!");
            return;
        }

        // Now you can use agentPanel for further logic
        Debug.Log("Successfully referenced AgentPanel in TestManager.");
    }

    public void UpdateAgentPanel(AgentSO agentSO)
    {
        if (agentPanel != null && agentSO != null)
        {
            agentPanel.Initialize(agentSO); // Populate the panel with agent data
        }
        else
        {
            Debug.LogError("AgentPanel or AgentSO is null in TestManager!");
        }
    }
}
