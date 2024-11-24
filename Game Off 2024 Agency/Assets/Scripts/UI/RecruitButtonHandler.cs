using UnityEngine;

public class RecruitButtonHandler : MonoBehaviour
{
    public GameObject agentFileUI; // Reference to AgentFile UI
    public AgentManager agentManager; // Reference to AgentManager
    public RecruitmentPanel recruitmentPanel; // Reference to RecruitmentPanel

    public void RecruitAgent()
    {
        var agentPanel = agentFileUI.GetComponent<AgentPanel>();
        if (agentPanel != null && agentPanel.AgentSO != null)
        {
            var agent = agentPanel.AgentSO;

            // Recruit agent via AgentManager
            agentManager.RecruitAgent(agent);

            // Refresh the recruitment grid
            recruitmentPanel.RefreshPanel();

            // Close the AgentFile UI
            agentFileUI.SetActive(false);

            Debug.Log($"Recruited Agent: {agent.agentName}");
        }
        else
        {
            Debug.LogWarning("No agent selected for recruitment!");
        }
    }
}
