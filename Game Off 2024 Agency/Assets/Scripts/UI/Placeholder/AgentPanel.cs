using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AgentPanel : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI agentNameText;
    public TextMeshProUGUI agentDescriptionText;
    public TextMeshProUGUI statsText;
    public TextMeshProUGUI effectsText;
    public Image agentPortraitImage;

    [Header("Abilities Layout Groups")]
    public Transform[] abilityColumns; // Array of 4 VerticalLayoutGroups for abilities
    public GameObject abilityPrefab;   // Prefab for a single ability row (name + percentage)

    private AgentSO agentSO;
    public AgentSO AgentSO => agentSO;

    // Property to track selection state
    public bool isClicked { get; private set; } = false;

    public void Initialize(AgentSO agent)
    {
        agentSO = agent;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (agentSO == null)
        {
            Debug.LogWarning("No AgentSO assigned to AgentPanel.");
            return;
        }

        // Update Basic Info
        agentNameText.text = $"Name: {agentSO.agentName}";
        agentDescriptionText.text = $"Description: {agentSO.description}";
        if (agentSO.portrait != null)
        {
            agentPortraitImage.sprite = agentSO.portrait;
        }
        else
        {
            agentPortraitImage.sprite = null;
        }

        // Update Stats
        statsText.text = "Stats:\n";
        foreach (var stat in agentSO.currentStats)
        {
            statsText.text += $"{stat.Key}: {stat.Value}\n";
        }

        // Update Skills (Abilities)
        PopulateAbilities();

        // Update Effects
        effectsText.text = "Effects:\n";
        if (agentSO.activeEffects.Count > 0)
        {
            foreach (var effect in agentSO.activeEffects)
            {
                effectsText.text += $"- {effect.displayName}\n";
            }
        }
        else
        {
            effectsText.text += "None\n";
        }
    }

    private void PopulateAbilities()
    {
        if (abilityColumns == null || abilityColumns.Length != 4)
        {
            Debug.LogError("Ability columns are not properly set up. Ensure there are exactly 4 VerticalLayoutGroups assigned.");
            return;
        }

        // Clear previous abilities
        foreach (var column in abilityColumns)
        {
            foreach (Transform child in column)
            {
                Destroy(child.gameObject);
            }
        }

        // Divide skills into columns
        int columnIndex = 0;
        int skillsPerColumn = Mathf.CeilToInt((float)agentSO.skills.Count / 4);
        int currentSkillIndex = 0;

        foreach (var skill in agentSO.skills)
        {
            if (currentSkillIndex >= skillsPerColumn)
            {
                currentSkillIndex = 0;
                columnIndex++;
            }

            if (columnIndex < abilityColumns.Length)
            {
                CreateAbilityRow(abilityColumns[columnIndex], skill.Key, skill.Value);
                currentSkillIndex++;
            }
        }
    }

    private void CreateAbilityRow(Transform parent, string skillName, int skillValue)
    {
        // Instantiate ability prefab
        GameObject abilityRow = Instantiate(abilityPrefab, parent);

        // Assign skill name and percentage
        var texts = abilityRow.GetComponentsInChildren<TextMeshProUGUI>();
        if (texts.Length >= 2)
        {
            texts[0].text = skillName;           // Skill name
            texts[1].text = $"{skillValue}%";    // Skill percentage
        }
        else
        {
            Debug.LogWarning("Ability prefab does not contain at least 2 TextMeshProUGUI components.");
        }
    }

    // Method to toggle the clicked state
    public void ToggleClicked()
    {
        isClicked = !isClicked;
        Debug.Log($"{agentNameText.text} isClicked set to {isClicked}");
    }
}
