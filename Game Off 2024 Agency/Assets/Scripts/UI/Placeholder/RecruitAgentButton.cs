using UnityEngine;
using UnityEngine.UI;

public class RecruitAgentButton : MonoBehaviour
{
    public Button recruitButton;
    public AgentPanel agentPanel; // Reference to the associated AgentPanel
    public AgentManager agentManager; // Reference to AgentManager

    private void Start()
    {
        if (recruitButton != null)
        {
            recruitButton.onClick.AddListener(OnRecruitButtonClicked);
        }
        else
        {
            Debug.LogWarning("RecruitButton is not assigned!");
        }

        if (agentManager == null)
        {
            agentManager = AgentManager.Instance; // Auto-assign AgentManager if not set
        }
    }

    private void OnRecruitButtonClicked()
    {
        if (agentPanel != null && agentPanel.agentSO != null)
        {
            // Recruit the agent via AgentManager
            agentManager.RecruitAgent(agentPanel.agentSO);

            Debug.Log($"Recruited Agent: {agentPanel.agentSO.agentName}");
        }
        else
        {
            Debug.LogWarning("AgentPanel or AgentSO is not assigned.");
        }
    }
}
