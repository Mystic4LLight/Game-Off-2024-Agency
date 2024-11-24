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

    [Header("Generated Agents")]
    public List<AgentSO> recruitmentSlots = new List<AgentSO>();

    private void Awake()
    {
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

    private void Start()
    {
        // Ensure critical references before refreshing recruitment
        if (!ValidateReferences())
        {
            return;
        }

        RefreshRecruitment();
    }

    public void RefreshRecruitment()
    {
        // Validate references before proceeding
        if (!ValidateReferences())
        {
            return;
        }

        // Clear existing recruitment slots
        foreach (Transform child in recruitmentGrid)
        {
            Destroy(child.gameObject);
        }
        recruitmentSlots.Clear();

        // Generate agents and populate recruitment slots
        for (int i = 0; i < maxRecruitmentSlots; i++)
        {
            string archetype = GetRandomArchetype();
            GameObject agentCard = Instantiate(agentUIPrefab, recruitmentGrid);

            // Assign agent data to the card
            var agentPanel = agentCard.GetComponentInChildren<AgentPanel>();
            if (agentPanel != null)
            {
                AgentSO agent = GenerateAgent(archetype, agentPanel);
                if (agent != null)
                {
                    recruitmentSlots.Add(agent);
                }
            }
            else
            {
                Debug.LogError("AgentPanel component is missing on the agent card prefab!");
            }

            // Assign the AgentFileActivator to open AgentFile UI
            var activator = agentCard.GetComponent<AgentFileActivator>();
            if (activator != null)
            {
                activator.agentFileUI = agentFileContainer.gameObject; // Assign the AgentFile container
                activator.Initialize(agentPanel.AgentSO); // Pass the generated AgentSO to the activator
            }
            else
            {
                Debug.LogError("AgentFileActivator is missing on the agent card prefab!");
            }
        }
    }

    private AgentSO GenerateAgent(string archetype, AgentPanel agentPanel)
    {
        if (statTemplate == null)
        {
            Debug.LogError("StatTemplate is not assigned in the AgentGenerator. Please assign it in the Inspector.");
            return null;
        }

        // Create a new AgentSO instance
        AgentSO agent = ScriptableObject.CreateInstance<AgentSO>();
        agent.statTemplate = statTemplate;

        // Initialize stats and skills
        agent.InitializeStats();
        agent.InitializeSkills();

        // Assign basic properties
        agent.agentName = GenerateRandomName();
        agent.agentSex = Random.value > 0.5f ? "Male" : "Female";
        agent.agentAge = Random.Range(18, 65);

        // Assign archetype-specific attributes and skills
        AssignAttributesAndSkills(agent, archetype);

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

    private string GetRandomArchetype()
    {
        string[] archetypes = { "Physical", "Athletic", "Combat", "Academic", "Charismatic" };
        return archetypes[Random.Range(0, archetypes.Length)];
    }

    private void AssignAttributesAndSkills(AgentSO agent, string archetype)
    {
        switch (archetype)
        {
            case "Physical":
                agent.currentStats["Strength"] = Roll3d6() * 5;
                agent.currentStats["Dexterity"] = Roll3d6() * 5;
                agent.currentStats["Intelligence"] = Roll2d6Plus6() * 5;
                break;
            case "Athletic":
                agent.currentStats["Dexterity"] = Roll3d6() * 5;
                agent.currentStats["Constitution"] = Roll3d6() * 5;
                agent.currentStats["Education"] = Roll2d6Plus6() * 5;
                break;
            case "Combat":
                agent.currentStats["Dexterity"] = Roll3d6() * 5;
                agent.currentStats["Strength"] = Roll3d6() * 5;
                agent.currentStats["Appearance"] = Roll2d6Plus6() * 5;
                break;
            case "Academic":
                agent.currentStats["Intelligence"] = Roll3d6() * 5;
                agent.currentStats["Education"] = Roll3d6() * 5;
                agent.currentStats["Dexterity"] = Roll2d6Plus6() * 5;
                break;
            case "Charismatic":
                agent.currentStats["Appearance"] = Roll3d6() * 5;
                agent.currentStats["Dexterity"] = Roll3d6() * 5;
                agent.currentStats["Strength"] = Roll2d6Plus6() * 5;
                break;
        }
    }

    private int Roll3d6() => Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7);
    private int Roll2d6Plus6() => Random.Range(1, 7) + Random.Range(1, 7) + 6;

    private string GenerateRandomName()
    {
        string[] firstNames = { "John", "Alice", "Robert", "Diana", "Michael", "Susan" };
        string[] lastNames = { "Smith", "Brown", "Johnson", "Taylor", "White", "Lee" };
        return $"{firstNames[Random.Range(0, firstNames.Length)]} {lastNames[Random.Range(0, lastNames.Length)]}";
    }

    /// <summary>
    /// Validates all critical references before execution.
    /// </summary>
    /// <returns>True if all references are valid, otherwise false.</returns>
    private bool ValidateReferences()
    {
        if (statTemplate == null)
        {
            Debug.LogError("StatTemplate is not assigned in the AgentGenerator.");
            return false;
        }

        if (recruitmentGrid == null)
        {
            Debug.LogError("RecruitmentGrid is not assigned in the AgentGenerator.");
            return false;
        }

        if (agentUIPrefab == null)
        {
            Debug.LogError("AgentUIPrefab is not assigned in the AgentGenerator.");
            return false;
        }

        if (agentFileContainer == null)
        {
            Debug.LogError("AgentFileContainer is not assigned or found.");
            return false;
        }

        return true;
    }
}
