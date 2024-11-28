using UnityEngine;

public class RecruitButtonHandler : MonoBehaviour
{
    public GameObject agentFileUI; // Reference to AgentFile UI
    public AgentManager agentManager; // Reference to AgentManager
    public RecruitmentPanel recruitmentPanel; // Reference to RecruitmentPanel
    public AgentSO agentSO;

    public AgentSO GetAgentSO()
    {
        return agentSO;
    }

    public void RecruitAgent()
    {
        var agentPanel = agentFileUI.GetComponent<AgentPanel>();
        if (agentPanel != null && agentPanel.agentSO != null)
        {
            var agentSO = agentPanel.agentSO;

            // Recruit agent via AgentManager
            agentManager.RecruitAgent(agentSO);

            // Refresh the recruitment grid
            recruitmentPanel.RefreshPanel();

            // Close the AgentFile UI
            agentFileUI.SetActive(false);

            GameLogger.Log($"Recruited Agent: {agentSO.agentName}");
        }
        else
        {
            GameLogger.LogWarning("No agent selected for recruitment!");
        }
    }
}
