using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AgentPanel : MonoBehaviour
{
    [Header("Agent Data")]
    public AgentSO agentSO; // Ensure this is the correct case-sensitive definition
    public AgentSO GetAgentSO()
    {
        return agentSO;
    }

    [Header("Agent Details")]
    [SerializeField] public TextMeshProUGUI agentNameText;
    [SerializeField] public TextMeshProUGUI agentOccupationText;
    [SerializeField] public TextMeshProUGUI agentAgeText;
    [SerializeField] public TextMeshProUGUI agentSexText;
    [SerializeField] public TextMeshProUGUI agentBackstoryText;
    [SerializeField] public Image portraitImage;
    [SerializeField] public TextMeshProUGUI description; // Retained

    [Header("Stats")]
    [SerializeField] public Dictionary<string, TextMeshProUGUI> statTexts = new(); // Simplified for clarity

    [Header("Abilities")]
    [SerializeField] public Dictionary<string, TextMeshProUGUI> abilityTexts = new(); // Simplified for clarity

    // Placeholder dictionaries
    [Header("Placeholders")]
    public Dictionary<Specialization.SpecializationType, List<TextMeshProUGUI>> placeholderNameText = new();
    public Dictionary<Specialization.SpecializationType, List<TextMeshProUGUI>> placeholderValueText = new();
    public Dictionary<Specialization.SpecializationType, List<string>> defaultPlaceholderText = new();

    public bool isClicked = false;

    private void Start()
    {
        if (agentSO == null)
        {
            Debug.LogError("AgentSO is not assigned in AgentPanel");
        }
        // Initialize or clear the UI
        ClearPanel();
    }

    public void DisplayAgentData()
    {
        if (agentSO == null)
        {
            Debug.LogError("AgentSO is not assigned!");
            return;
        }

        // Example of accessing properties from agentSO
        Debug.Log($"Displaying data for Agent: {agentSO.agentName}");
    }

    public void SetAgentData(AgentSO newAgentSO)
    {
        if (newAgentSO == null)
        {
            Debug.LogError("New AgentSO is null!");
            return;
        }

        agentSO = newAgentSO;
        DisplayAgentData();
    }


    /// <summary>
    /// Initializes the panel with an agent.
    /// </summary>
    /// <param name="agentData">The agent to display.</param>
    public void Initialize(AgentSO agentData)
    {

        // Correct reference for Initialize() in AgentPanel
    if (agentData != null)
    {
        Debug.LogError("Agent data is null. Unable to initialize.");
        return;
    }
        agentSO = agentData;

        UpdateUI();
    }

    /// <summary>
    /// Updates the UI elements with the agent's data.
    /// </summary>
    private void UpdateUI()
    {
        if (agentSO == null)
        {
            Debug.LogWarning("No AgentSO assigned to AgentPanel.");
            return;
        }

        // Update text fields
        agentNameText.text = agentSO.agentName;
        agentOccupationText.text = agentSO.occupation;
        agentAgeText.text = $"Age: {agentSO.agentAge}";
        agentSexText.text = $"Sex: {agentSO.agentSex}";
        agentBackstoryText.text = agentSO.backstory;
        description.text = agentSO.description;

        // Update portrait
        portraitImage.sprite = agentSO.profilePhoto;

        // Populate specializations
        PopulateSpecializations();
    }

    private void PopulateSpecializations()
    {
        var usedPlaceholders = new Dictionary<Specialization.SpecializationType, int>
        {
            { Specialization.SpecializationType.ArtCraft, 0 },
            { Specialization.SpecializationType.Fighting, 0 },
            { Specialization.SpecializationType.Firearms, 0 },
            { Specialization.SpecializationType.Science, 0 },
            { Specialization.SpecializationType.Language, 0 },
            { Specialization.SpecializationType.Other, 0 },
            { Specialization.SpecializationType.Survival, 0 }
        };

        foreach (var specialization in agentSO.specializations)
        {
            if (!placeholderNameText.TryGetValue(specialization.type, out var namePlaceholders) ||
                !placeholderValueText.TryGetValue(specialization.type, out var valuePlaceholders))
            {
                continue;
            }

            int currentIndex = usedPlaceholders[specialization.type];

            if (currentIndex >= namePlaceholders.Count || currentIndex >= valuePlaceholders.Count)
            {
                Debug.LogWarning($"Not enough placeholders for specialization: {specialization.name} of type {specialization.type}");
                continue;
            }

            // Assign specialization
            namePlaceholders[currentIndex].text = specialization.name;
            valuePlaceholders[currentIndex].text = specialization.value.ToString();
            usedPlaceholders[specialization.type]++;
        }
    }

    public void ClearPanel()
    {
        // Reset UI elements (e.g., text, images) to default/empty values
        agentNameText.text = "No Agent";
        agentOccupationText.text = "";
        agentAgeText.text = "";
        agentSexText.text = "";
        agentBackstoryText.text = "";
        description.text = "";
        portraitImage.sprite = null;
    }
}
