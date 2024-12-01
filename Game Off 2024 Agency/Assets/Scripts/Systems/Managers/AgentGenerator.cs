using System.Collections;
using System.Collections.Generic; // Add this to use List<>
using UnityEngine;

public class AgentGenerator : MonoBehaviour
{
    [Header("References")]
    public AgentStatTemplateSO statTemplate; // Assign this in the Inspector
    public Transform recruitmentGrid; // Recruitment grid for displaying agents
    public GameObject agentPrefab; // Prefab for agent UI cards
    public Transform agentFileContainer; // Container for agent files in AgentUI
    public int maxRecruitmentSlots = 3; // Number of agents available for recruitment

    [Header("Agent Slots")]
    public Transform agentSlot1;
    public Transform agentSlot2;
    public Transform agentSlot3;

    [Header("Generated Agents")]
    public List<AgentSO> recruitmentSlots = new List<AgentSO>();

    private void Awake()
    {
        GameLogger.Log("AgentGenerator initialized.");

        // Initialize critical references
        InitializeReferences();

        // Check and validate references
        if (ValidateReferences())
        {
            GameLogger.Log("AgentGenerator: All references are valid.");
        }
        else
        {
            GameLogger.LogError("AgentGenerator: Missing references. Please check the Inspector.");
        }
    }

    private void InitializeReferences()
    {
        if (agentFileContainer == null)
        {
            GameObject agentUI = GameObject.Find("AgentUI");
            if (agentUI != null)
            {
                agentFileContainer = agentUI.transform.Find("AgentFileContainer");
                if (agentFileContainer == null)
                {
                    GameLogger.LogError("AgentFileContainer not found in AgentUI.");
                }
            }
            else
            {
                GameLogger.LogError("AgentUI not found in the scene.");
            }
        }

        if (agentFileContainer != null)
        {
            GameLogger.Log("AgentFileContainer reference initialized successfully.");
        }
    }

    private void Start()
    {
        GameLogger.Log("AgentGenerator Start called.");

        if (!ValidateReferences())
        {
            GameLogger.LogError("AgentGenerator references are not properly set. Aborting initialization.");
            return;
        }

        GenerateAgents();
    }

    public void GenerateAgents()
    {
        GameLogger.Log("Generating agents."); 

        recruitmentSlots.Clear();  

        for (int i = 0; i < maxRecruitmentSlots; i++)
        {
            string archetype = AgentTemplateManager.GetRandomArchetype();
            string occupation = AgentTemplateManager.GetRandomOccupation(archetype);

            GameObject agentObject = GenerateAgent(archetype, occupation);

            if (agentObject == null)
            {
                GameLogger.LogError("Failed to generate agent object.");
                continue;
            }

            AgentUI agentUI = agentObject.GetComponent<AgentUI>();
            if (agentUI != null && agentUI.agentSO != null)
            {
                recruitmentSlots.Add(agentUI.agentSO);
            }
            else
            {
                GameLogger.LogError("Failed to add AgentSO to recruitmentSlots. Missing AgentUI or AgentSO.");
            }

            AssignAgentToSlot(agentObject, i);
        }
    }

    public GameObject GenerateAgent(string archetype, string occupation, Transform parent = null)
    {
        if (agentPrefab == null)
        {
            GameLogger.LogError("Agent prefab is not assigned in AgentGenerator.");
            return null;
        }

        GameObject agentObject = Instantiate(agentPrefab, parent != null ? parent : recruitmentGrid, false);
        agentObject.SetActive(false);  // Initially deactivate to ensure all components are properly assigned before enabling

        AgentSO agent = ScriptableObject.CreateInstance<AgentSO>();
        agent.statTemplate = statTemplate;
        agent.archetype = archetype;
        agent.agentSex = Random.Range(0, 2) == 0 ? "Male" : "Female";
        agent.agentName = AgentTemplateManager.GenerateRandomName(agent.agentSex == "Male");
        agent.agentAge = Random.Range(20, 60);
        agent.occupation = occupation;

        // Assign the portrait to the agent
        AssignAgentPortrait(agent);

        AgentStatsManager.InitializeAgentStatsAndSkills(agent);
        AgentTemplateManager.InitializeAgentSpecializations(agent);

        // Assign agentSO to AgentPanel and AgentUI
        AgentPanel agentPanel = agentObject.GetComponentInChildren<AgentPanel>();
        if (agentPanel != null)
        {
            agentPanel.UpdatePanel(agent);
            GameLogger.Log($"AgentSO assigned to AgentPanel for {agent.agentName}");
        }
        else
        {
            GameLogger.LogError("AgentPanel is missing on the instantiated prefab.");
            Destroy(agentObject);
            return null;
        }

        AgentUI agentUI = agentObject.GetComponent<AgentUI>();
        if (agentUI != null)
        {
            agentUI.agentSO = agent;
            GameLogger.Log($"AgentSO assigned to AgentUI for {agent.agentName}");
        }
        else
        {
            GameLogger.LogError("AgentUI is missing on the instantiated prefab.");
            Destroy(agentObject);
            return null;
        }

        // Now assign the parentAgentObject to SelectAgentButton
        SelectAgentButton selectButton = agentObject.GetComponentInChildren<SelectAgentButton>();
        if (selectButton != null)
        {
            selectButton.SetParentAgentObject(agentObject);
            GameLogger.Log($"Assigned parentAgentObject to SelectAgentButton for agent: {agent.agentName}");
        }
        else
        {
            GameLogger.LogWarning("SelectAgentButton not found on the generated agent prefab.");
        }

        // After everything is assigned, activate the object
        agentObject.SetActive(true);

        return agentObject;
    }

    private void AssignAgentPortrait(AgentSO agent)
    {
        string portraitPath = agent.agentSex == "Male" ? "AgentPortraits/Male" : "AgentPortraits/Female";
        Sprite[] availablePortraits = Resources.LoadAll<Sprite>(portraitPath);

        if (availablePortraits != null && availablePortraits.Length > 0)
        {
            agent.profilePhoto = availablePortraits[Random.Range(0, availablePortraits.Length)];
            GameLogger.Log($"Assigned portrait to agent: {agent.agentName}");
        }
        else
        {
            GameLogger.LogWarning($"No available portraits found for path: {portraitPath}");
        }
    }

    private void ClearAgentSlots()
    {
        // Iterate through the predefined agent slots
        foreach (Transform slot in new[] { agentSlot1, agentSlot2, agentSlot3 })
        {
            if (slot.childCount > 0)
            {
                // Destroy all child GameObjects in the slot
                foreach (Transform child in slot)
                {
                    Destroy(child.gameObject);
                }
            }
        }

        GameLogger.Log("Agent slots cleared.");
    }


    private void AssignAgentToSlot(GameObject agentCard, int slotIndex)
    {
        Transform targetSlot = slotIndex switch
        {
            0 => agentSlot1,
            1 => agentSlot2,
            2 => agentSlot3,
            _ => null
        };

        if (targetSlot != null)
        {
            agentCard.transform.SetParent(targetSlot, false);
            GameLogger.Log($"Agent card assigned to slot {slotIndex}.");
        }
        else
        {
            GameLogger.LogWarning($"Invalid slot index ({slotIndex}) for assigning agent card.");
        }
    }

    private bool ValidateReferences()
    {
        bool isValid = true;

        if (statTemplate == null)
        {
            GameLogger.LogError("StatTemplate is not assigned in the AgentGenerator.");
            isValid = false;
        }

        if (agentPrefab == null)
        {
            GameLogger.LogError("AgentPrefab is not assigned in the AgentGenerator.");
            isValid = false;
        }

        if (agentSlot1 == null || agentSlot2 == null || agentSlot3 == null)
        {
            GameLogger.LogError("Agent slots are not assigned in the AgentGenerator. Please assign them in the Inspector.");
            isValid = false;
        }

        if (recruitmentGrid == null)
        {
            GameLogger.LogError("RecruitmentGrid is not assigned in the AgentGenerator.");
            isValid = false;
        }

        return isValid;
    }
    
}
