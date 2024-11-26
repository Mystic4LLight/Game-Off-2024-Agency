using UnityEngine;
using System.Collections.Generic;

public class AgentGenerator : MonoBehaviour
{
    [Header("References")]
    public AgentStatTemplateSO statTemplate; // Assign this in the Inspector
    public Transform recruitmentGrid; // Assign the recruitment grid where agents are displayed
    public GameObject agentUIPrefab; // Assign the prefab for the agent UI
    public Transform agentFileContainer; // Reference the AgentFile container inside AgentUI
    public int maxRecruitmentSlots = 3;

    // New references for the individual agent slots
    public Transform agentSlot1;
    public Transform agentSlot2;
    public Transform agentSlot3;

    [Header("Generated Agents")]
    public List<AgentSO> recruitmentSlots = new List<AgentSO>();

    private void Awake()
    {
        Debug.Log("AgentGenerator Awake called."); // Add this log to track initialization.

        // Resolve agentFileContainer dynamically if not assigned
        if (agentFileContainer == null)
        {
            GameObject agentUI = GameObject.Find("AgentUI"); // Replace with your actual AgentUI name
            if (agentUI != null)
            {
                agentFileContainer = agentUI.transform.Find("AgentFileContainer");
                if (agentFileContainer == null)
                {
                    Debug.LogError("AgentFileContainer not found in AgentUI. Ensure it is named correctly and exists.");
                }
            }
            else
            {
                Debug.LogError("AgentUI not found in the scene. Ensure it exists and is active.");
            }
        }
    }

    void Start()
    {
        // Generate agents for recruitment slots
        GenerateAgents();

        // Refresh recruitment after all agents have been generated
        RefreshRecruitment();
    }

    private void GenerateAgents()
    {
        Debug.Log("Generating agents."); // Tracking log

        // Clear existing recruitment slots to prepare for new generation
        recruitmentSlots.Clear();

        // Number of agents to be generated
        int numberOfAgentsToGenerate = maxRecruitmentSlots;

        // Generate agents
        for (int i = 0; i < numberOfAgentsToGenerate; i++)
        {
            string archetype = GetRandomArchetype();
            GameObject agentCard = Instantiate(agentUIPrefab);

            // Attempt to assign agent data to the card
            var agentPanel = agentCard.GetComponentInChildren<AgentPanel>();
            if (agentPanel != null)
            {
                // Generate and initialize agent with agentPanel
                AgentSO agent = GenerateAgent(archetype, agentPanel); 
                if (agent != null)
                {
                    // Add agent to recruitment slots and assign it to the corresponding UI slot
                    recruitmentSlots.Add(agent);
                    AssignAgentToSlot(agentCard, i);
                }
            }
            else
            {
                Debug.LogError("AgentPanel component is missing on the agent card prefab!");
            }

            // Assign the AgentFileActivator to open the AgentFile UI
            var activator = agentCard.GetComponentInChildren<AgentFileActivator>();
            if (activator != null)
            {
                activator.agentUI = agentCard.GetComponent<AgentUI>(); // Assign the AgentUI reference directly
                activator.Initialize(agentPanel.agentSO); // Pass the generated AgentSO to the activator
            }
            else
            {
                Debug.LogError("AgentFileActivator is missing on the agent card prefab!");
            }
        }
    }


    public void RefreshRecruitment()
    {
        Debug.Log("Refreshing recruitment slots."); // Add this line for tracking.

        // Validate references before proceeding
        if (!ValidateReferences())
        {
            return;
        }

        // Clear existing agent slots in the UI
        ClearAgentSlots();

        // Assign agents to recruitment slots
        for (int i = 0; i < recruitmentSlots.Count; i++)
        {
            GameObject agentCard = Instantiate(agentUIPrefab);
            AssignAgentToSlot(agentCard, i);

            var agentPanel = agentCard.GetComponentInChildren<AgentPanel>();
            if (agentPanel != null)
            {
                agentPanel.Initialize(recruitmentSlots[i]);
            }
            else
            {
                Debug.LogError("AgentPanel component is missing on the agent card prefab!");
            }

            var activator = agentCard.GetComponentInChildren<AgentFileActivator>();
            if (activator != null)
            {
                activator.agentUI = agentCard.GetComponent<AgentUI>();
                activator.Initialize(recruitmentSlots[i]);
            }
            else
            {
                Debug.LogError("AgentFileActivator is missing on the agent card prefab!");
            }
        }
    }

    private void ClearAgentSlots()
    {
        // Clear each agent slot to make room for new agents
        foreach (Transform slot in new[] { agentSlot1, agentSlot2, agentSlot3 })
        {
            if (slot.childCount > 0)
            {
                foreach (Transform child in slot)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }

    private void AssignAgentToSlot(GameObject agentCard, int slotIndex)
    {
        switch (slotIndex)
        {
            case 0:
                agentCard.transform.SetParent(agentSlot1, false);
                break;
            case 1:
                agentCard.transform.SetParent(agentSlot2, false);
                break;
            case 2:
                agentCard.transform.SetParent(agentSlot3, false);
                break;
            default:
                Debug.LogWarning("Invalid slot index for agent card.");
                break;
        }
    }

    private AgentSO GenerateAgent(string archetype, AgentPanel agentPanel)
    {
        if (statTemplate == null)
        {
            Debug.LogError("StatTemplate is not assigned in the AgentGenerator. Please assign it in the Inspector.");
            return null;
        }

        // Create a new, unique instance of AgentSO each time
        AgentSO agent = ScriptableObject.CreateInstance<AgentSO>();
        agent.statTemplate = statTemplate; // Assign the statTemplate immediately after creation3
        agent.agentName = GenerateRandomName();

        agent.InitializeAgent();
        Debug.Log($"Generating agent: {agent.agentName} with template: {statTemplate.name}");

        // Link the AgentSO to the AgentPanel
        if (agentPanel != null)
        {
            agentPanel.Initialize(agent);
        }
        else
        {
            Debug.LogError("AgentPanel reference is missing. Unable to assign AgentSO.");
        }

        return agent;
    }


    private bool ValidateReferences()
    {
        if (statTemplate == null)
        {
            Debug.LogError("StatTemplate is not assigned in the AgentGenerator.");
            return false;
        }

        if (agentUIPrefab == null)
        {
            Debug.LogError("AgentUIPrefab is not assigned in the AgentGenerator.");
            return false;
        }

        if (agentSlot1 == null || agentSlot2 == null || agentSlot3 == null)
        {
            Debug.LogError("Agent slots are not assigned in the AgentGenerator. Please assign them in the Inspector.");
            return false;
        }

        return true;
    }

    private string GetRandomArchetype()
    {
        string[] archetypes = { "Physical", "Athletic", "Combat", "Academic", "Charismatic" };
        return archetypes[Random.Range(0, archetypes.Length)];
    }

    private string GenerateRandomName()
    {
        string[] firstNames = { "John", "Alice", "Robert", "Diana", "Michael", "Susan" };
        string[] lastNames = { "Smith", "Brown", "Johnson", "Taylor", "White", "Lee" };
        return $"{firstNames[Random.Range(0, firstNames.Length)]} {lastNames[Random.Range(0, lastNames.Length)]}";
    }
}
