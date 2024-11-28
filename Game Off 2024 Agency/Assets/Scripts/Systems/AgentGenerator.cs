using System.Collections.Generic;
using UnityEngine;

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
        GameLogger.Log("AgentGenerator Awake called."); // Add this log to track initialization.

        // Resolve agentFileContainer dynamically if not assigned
        if (agentFileContainer == null)
        {
            GameObject agentUI = GameObject.Find("AgentUI"); // Replace with your actual AgentUI name
            if (agentUI != null)
            {
                agentFileContainer = agentUI.transform.Find("AgentFileContainer");
                if (agentFileContainer == null)
                {
                    GameLogger.LogError("AgentFileContainer not found in AgentUI. Ensure it is named correctly and exists.");
                }
            }
            else
            {
                GameLogger.LogError("AgentUI not found in the scene. Ensure it exists and is active.");
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
        GameLogger.Log("Generating agents."); // Tracking log

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
                GameLogger.LogError("AgentPanel component is missing on the agent card prefab!");
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
                GameLogger.LogError("AgentFileActivator is missing on the agent card prefab!");
            }
        }
    }

    public void RefreshRecruitment()
    {
        GameLogger.Log("Refreshing recruitment slots."); // Add this line for tracking.

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
                GameLogger.LogError("AgentPanel component is missing on the agent card prefab!");
            }

            var activator = agentCard.GetComponentInChildren<AgentFileActivator>();
            if (activator != null)
            {
                activator.agentUI = agentCard.GetComponent<AgentUI>();
                activator.Initialize(recruitmentSlots[i]);
            }
            else
            {
                GameLogger.LogError("AgentFileActivator is missing on the agent card prefab!");
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
                GameLogger.LogWarning("Invalid slot index for agent card.");
                break;
        }
    }

    private AgentSO GenerateAgent(string archetype, AgentPanel agentPanel)
    {
        if (statTemplate == null)
        {
            GameLogger.LogError("StatTemplate is not assigned in the AgentGenerator. Please assign it in the Inspector.");
            return null;
        }

        // Create a new, unique instance of AgentSO each time
        AgentSO agent = ScriptableObject.CreateInstance<AgentSO>();
        agent.statTemplate = statTemplate;

        // Determine sex randomly
        bool isMale = Random.value > 0.5f;
        agent.agentSex = isMale ? "Male" : "Female";

        // Assign name, age, and occupation
        agent.agentName = GenerateRandomName(isMale);
        agent.agentAge = Random.Range(25, 50);
        agent.occupation = archetype;

        // Properly initialize agent stats, skills, and specializations based on CoC/Pulp rules
        InitializeAgentStatsAndSkills(agent); // Custom method to initialize stats and skills
        InitializeAgentSpecializations(agent); // Custom method to initialize specializations

        // Assign a random portrait
        string portraitPath = isMale ? "AgentPortraits/Male" : "AgentPortraits/Female";
        Sprite[] availablePortraits = Resources.LoadAll<Sprite>(portraitPath);
        if (availablePortraits != null && availablePortraits.Length > 0)
        {
            // Exclude pulp-specialized portraits
            List<Sprite> filteredPortraits = new List<Sprite>(availablePortraits);
            if (filteredPortraits.Count > 2)
            {
                filteredPortraits.RemoveAt(filteredPortraits.Count - 1); // Assuming last 2 are pulp portraits
                filteredPortraits.RemoveAt(filteredPortraits.Count - 1);
            }

            agent.profilePhoto = filteredPortraits[Random.Range(0, filteredPortraits.Count)];
        }
        else
        {
            GameLogger.LogError("No portraits available in the specified path.");
        }

        GameLogger.Log($"Generating agent: {agent.agentName} with archetype: {archetype} and template: {statTemplate.name}");

        // Link the AgentSO to the AgentPanel (This should happen AFTER stats and skills are set)
        if (agentPanel != null)
        {
            agentPanel.Initialize(agent);
        }
        else
        {
            GameLogger.LogError("AgentPanel reference is missing. Unable to assign AgentSO.");
        }

        return agent;
    }

    private void InitializeAgentStatsAndSkills(AgentSO agent)
    {
        // Make sure to initialize currentStats and skills as new dictionaries
        agent.currentStats = new Dictionary<string, int>
        {
            { "Strength", RollDice(3, 6, 5) }, // STR is 3d6 x 5
            { "Constitution", RollDice(3, 6, 5) }, // CON is 3d6 x 5
            { "Size", RollDice(2, 6, 5) + 30 }, // SIZ is 2d6+6 x 5
            { "Dexterity", RollDice(3, 6, 5) }, // DEX is 3d6 x 5
            { "Appearance", RollDice(3, 6, 5) }, // APP is 3d6 x 5
            { "Education", RollDice(2, 6, 5) + 30 }, // EDU is 2d6+6 x 5
            { "Intelligence", RollDice(2, 6, 5) + 30 }, // INT is 2d6+6 x 5
            { "Power", RollDice(3, 6, 5) } // POW is 3d6 x 5
        };

        // Ensure all keys exist in the dictionary before accessing them
        foreach (var key in new List<string> { "Strength", "Constitution", "Size", "Dexterity", "Appearance", "Education", "Intelligence", "Power" })
        {
            if (!agent.currentStats.ContainsKey(key))
            {
                agent.currentStats[key] = 0;
            }
        }

        // Initialize skills with their default base values
        agent.skills = new Dictionary<string, int>
        {
            { "Accounting", 5 },
            { "Anthropology", 1 },
            { "Appraise", 5 },
            { "Archaeology", 1 },
            { "Charm", 15 },
            { "Climb", 20 },
            { "Computer Use", 5 },
            { "Credit Rating", 0 },
            { "Cthulhu Mythos", 0 },
            { "Disguise", 5 },
            { "Dodge", agent.currentStats["Dexterity"] / 2 }, // Dodge starts at DEX/2
            { "Drive Auto", 20 },
            { "Elec Repair", 10 },
            { "Electronics", 1 },
            { "Fast Talk", 5 },
            { "Fighting(Brawl)", 25 },
            { "First Aid", 30 },
            { "History", 5 },
            { "Intimidate", 15 },
            { "Jump", 20 },
            { "Law", 5 },
            { "Library Use", 20 },
            { "Listen", 25 },
            { "Locksmith", 1 },
            { "Mech Repair", 10 },
            { "Medicine", 1 },
            { "Natural World", 10 },
            { "Navigate", 10 },
            { "Occult", 5 },
            { "Op. Hv. Machine", 1 },
            { "Persuade", 10 },
            { "Pilot", 1 },
            { "Psychology", 10 },
            { "Psychoanalysis", 1 },
            { "Sleight of Hand", 10 },
            { "Spot Hidden", 25 },
            { "Stealth", 20 },
            { "Swim", 20 },
            { "Throw", 20 },
            { "Track", 10 }
        };

        // Add archetype-specific skills or bonuses
        switch (agent.occupation)
        {
            case "Academic":
                agent.skills["Library Use"] += 50;
                agent.skills["Occult"] += 40;
                agent.skills["History"] += 30;
                break;
            case "Combat":
                agent.skills["Fighting(Brawl)"] += 60;
                agent.skills["Firearms"] = 50; // Firearms might not be initialized earlier, so it's set directly
                agent.skills["Dodge"] += 20; // Dodge gets an extra boost
                break;
            case "Charismatic":
                agent.skills["Charm"] += 50;
                agent.skills["Fast Talk"] += 40;
                agent.skills["Persuade"] += 30;
                break;
            case "Athletic":
                agent.skills["Climb"] += 50;
                agent.skills["Jump"] += 40;
                agent.skills["Swim"] += 30;
                break;
            case "Physical":
                agent.skills["Strength"] += 20; // Assuming "Strength" as a skill modifier for physical archetype
                agent.skills["Mechanical Repair"] += 40;
                agent.skills["Track"] += 30;
                break;
            default:
                GameLogger.LogWarning("Unknown archetype, assigning default skills.");
                agent.skills["Accounting"] += 10;
                agent.skills["Library Use"] += 20;
                break;
        }
    }

    // Method to initialize agent specializations in AgentGenerator
    private void InitializeAgentSpecializations(AgentSO agent)
    {
        // Initialize specializations with proper constructor arguments
        agent.specializations = new List<Specialization>();

        // Adding 18 specializations with placeholder names for every type
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.ArtCraft, "Art/Craft", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.ArtCraft, "Art/Craft 2", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.ArtCraft, "Art/Craft 3", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Language, "Language (Other)", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Language, "Language 2", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Language, "Language (Own)", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Science, "Science", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Science, "Science 2", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Science, "Science 3", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Fighting, "Fighting 2", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Fighting, "Fighting 3", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Firearms, "Firearms 3", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Survival, "Survival", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, "Other 1", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, "Other 2", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, "Other 3", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, "Other 4", 0));
        agent.specializations.Add(new Specialization(Specialization.SpecializationType.Other, "Other 5", 0));
    }

    private int RollDice(int numberOfDice, int sides, int multiplier = 1)
    {
        int total = 0;
        for (int i = 0; i < numberOfDice; i++)
        {
            total += Random.Range(1, sides + 1);
        }
        return total * multiplier;
    }

    private bool ValidateReferences()
    {
        if (statTemplate == null)
        {
            GameLogger.LogError("StatTemplate is not assigned in the AgentGenerator.");
            return false;
        }

        if (agentUIPrefab == null)
        {
            GameLogger.LogError("AgentUIPrefab is not assigned in the AgentGenerator.");
            return false;
        }

        if (agentSlot1 == null || agentSlot2 == null || agentSlot3 == null)
        {
            GameLogger.LogError("Agent slots are not assigned in the AgentGenerator. Please assign them in the Inspector.");
            return false;
        }

        return true;
    }

    private string GetRandomArchetype()
    {
        string[] archetypes = { "Physical", "Athletic", "Combat", "Academic", "Charismatic", "Adventurer", "Daredevil", "Occultist", "Spy", "Inventor", "Strongman/Woman", "Mystic", "Journalist", "Doctor/Healer", "Explorer" };
        return archetypes[Random.Range(0, archetypes.Length)];
    }

    private string GenerateRandomName(bool isMale)
    {
        string[] maleFirstNames = { "John", "Robert", "Michael", "David", "James", "William" };
        string[] femaleFirstNames = { "Alice", "Diana", "Susan", "Mary", "Linda", "Karen" };
        string[] lastNames = { "Smith", "Brown", "Johnson", "Taylor", "White", "Lee" };
        string firstName = isMale ? maleFirstNames[Random.Range(0, maleFirstNames.Length)] : femaleFirstNames[Random.Range(0, femaleFirstNames.Length)];
        return $"{firstName} {lastNames[Random.Range(0, lastNames.Length)]}";
    }
}
