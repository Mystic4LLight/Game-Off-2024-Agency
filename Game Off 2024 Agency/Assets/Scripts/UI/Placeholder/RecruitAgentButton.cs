using UnityEngine;
using UnityEngine.UI;

public class RecruitAgentButton : MonoBehaviour
{
    public Button recruitButton;
    public AgentPanel agentPanel; // Reference to the associated AgentPanel

    private void Start()
    {
        recruitButton.onClick.AddListener(OnRecruitButtonClicked);
    }

    private void OnRecruitButtonClicked()
    {
        if (agentPanel != null)
        {
            agentPanel.ToggleClicked();
            Debug.Log($"AgentPanel isClicked state: {agentPanel.isClicked}");
        }
        else
        {
            Debug.LogWarning("AgentPanel is not assigned to RecruitAgentButton.");
        }
    }
}
