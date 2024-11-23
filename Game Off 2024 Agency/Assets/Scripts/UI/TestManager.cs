using UnityEngine;

public class TestManager : MonoBehaviour
{
    public AgentPanel agentPanel;
    public AgentSO agentSO;

    private void Start()
    {
        if (agentPanel == null)
        {
            Debug.LogError("AgentPanel is not assigned.");
            return;
        }

        if (agentSO == null)
        {
            Debug.LogError("AgentSO is not assigned.");
            return;
        }

        agentPanel.Initialize(agentSO);
    }
}
