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
            Debug.LogError("AgentGenerator is not assigned in RecruitmentPanel!");
            return;
        }

        AssignAgentsToSlots();
    }
    public void AssignAgentsToSlots()
    {
        if (agentGenerator.recruitmentSlots == null || agentGenerator.recruitmentSlots.Count == 0)
        {
            Debug.LogWarning("No agents available in recruitment slots.");
            return;
        }

        // Check if necessary references are assigned
        if (recruitmentGrid == null || agentUIPrefab == null || agentGenerator == null)
        {
            Debug.LogError("RecruitmentPanel is missing required references!");
            return;
        }

        // Clear the recruitment grid
        foreach (Transform child in recruitmentGrid)
        {
            Destroy(child.gameObject); // Correct usage
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
                Debug.LogError("AgentPanel component is missing on the agent card prefab!");
            }

            // Assign the AgentFileActivator for opening the AgentFile
            var activator = agentCard.GetComponent<AgentFileActivator>();
            if (activator != null)
            {   
                if (agentGenerator.agentFileContainer == null)
                {
                    Debug.LogError("AgentFileContainer is not assigned in AgentGenerator. Please assign it in the Inspector.");
                    return; // Prevent null reference exceptions
                }
                
                GameObject newAgentCard = Instantiate(agentUIPrefab, recruitmentGrid); // Assign the AgentFile container
                activator.Initialize(agent);
            }
            else
            {
                Debug.LogError("AgentFileActivator is missing on the agent card prefab!");
            }
        }
    }


    public void RefreshPanel()
    {
        if (recruitmentGrid == null || agentUIPrefab == null || agentGenerator == null)
        {
            Debug.LogError("RecruitmentPanel is missing required references!");
            return;
        }

        // Clear current recruitment slots
        foreach (Transform child in recruitmentGrid)
        {
            Destroy(child.gameObject);
        }

        // Populate the recruitment panel with agents
        foreach (var agent in agentGenerator.recruitmentSlots)
        {
            if (agent == null) continue;

            // Instantiate an agent card
            GameObject agentCard = Instantiate(agentUIPrefab, recruitmentGrid);

            // Initialize the AgentPanel
            var agentPanel = agentCard.GetComponentInChildren<AgentPanel>();
            if (agentPanel != null)
            {
                agentPanel.Initialize(agent);
            }
            else
            {
                Debug.LogError("AgentPanel component missing on the agent card prefab!");
            }
        }
    }
}
