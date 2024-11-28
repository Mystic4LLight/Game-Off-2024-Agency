using UnityEngine;

public class RecruitmentPanel : MonoBehaviour
{
    public Transform recruitmentGrid; // Parent for the recruitment slots
    public GameObject agentUIPrefab;   // Prefab for agent cards
    public AgentGenerator agentGenerator; // Reference to the AgentGenerator

    private void Start()
    {
        if (agentGenerator == null)
        {
            GameLogger.LogError("AgentGenerator is not assigned in RecruitmentPanel!");
            return;
        }

        RefreshPanel();
    }

    public void RefreshPanel()
    {
        if (recruitmentGrid == null || agentUIPrefab == null || agentGenerator == null)
        {
            GameLogger.LogError("RecruitmentPanel is missing required references!");
            return;
        }

        // Clear the recruitment grid
        foreach (Transform child in recruitmentGrid)
        {
            Destroy(child.gameObject);
        }

        // Populate the recruitment grid with agents
        foreach (var agent in agentGenerator.recruitmentSlots)
        {
            if (agent == null) continue;

            // Instantiate an agent card prefab
            GameObject agentCard = Instantiate(agentUIPrefab, recruitmentGrid);

            // Assign AgentPanel and initialize it
            var agentPanel = agentCard.GetComponentInChildren<AgentPanel>();
            if (agentPanel != null)
            {
                agentPanel.Initialize(agent); // Set up the agent card with data
            }
            else
            {
                GameLogger.LogError("AgentPanel component is missing on the agent card prefab!");
            }
        }
    }
}
