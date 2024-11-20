using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ArtifactResearchUI : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Dropdown agentDropdown; // Dropdown to select an agent
    public TextMeshProUGUI agentStatsText; // Display selected agent's stats
    public Button assignAgentButton; // Button to assign agent
    public TextMeshProUGUI artifactStatusText; // Display artifact research status

    [Header("References")]
    public GameManager gameManager; // Reference to GameManager
    public List<AgentSO> agents; // List of all available agents

    private AgentSO selectedAgent; // The currently selected agent

    
    private void Start()
    {
        PopulateAgentDropdown();
        agentDropdown.onValueChanged.AddListener(OnAgentSelected);
        assignAgentButton.onClick.AddListener(AssignAgentToResearch);
        UpdateArtifactStatus();
    }

    // Populate the dropdown with agent names
    private void PopulateAgentDropdown()
    {
        agentDropdown.ClearOptions();
        List<string> agentNames = new List<string>();

        foreach (var agent in agents)
        {
            agentNames.Add(agent.name);
        }

        agentDropdown.AddOptions(agentNames);
    }

    // When an agent is selected, display their stats
    private void OnAgentSelected(int index)
    {
        selectedAgent = agents[index];
        DisplayAgentStats();
    }

    // Display the selected agent's stats, focusing on relevant skills
    private void DisplayAgentStats()
    {
        if (selectedAgent == null) return;

        agentStatsText.text = $"Name: {selectedAgent.name}\n" +
                              $"Electronics: {selectedAgent.GetSkillLevel(AgentSkill.Electronics)}\n" +
                              $"Electric Repair: {selectedAgent.GetSkillLevel(AgentSkill.ElectricRepair)}\n" +
                              $"Mechanical Repair: {selectedAgent.GetSkillLevel(AgentSkill.MechanicalRepair)}\n"; //+
                              //$"Weird Science: {selectedAgent.GetSkillLevel(AgentSkill.WeirdScience)}";
    }

    // Assign the selected agent to the active artifact for research
    private void AssignAgentToResearch()
    {
        if (selectedAgent == null)
        {
            Debug.LogWarning("No agent selected!");
            return;
        }

        if (gameManager.activeArtifact == null)
        {
            Debug.LogWarning("No artifact is active for research!");
            return;
        }

        // Assign the agent and determine the best skill for analysis
        gameManager.activeArtifact.isUnderResearch = true;
        Debug.Log($"Assigned {selectedAgent.name} to research {gameManager.activeArtifact.name}.");

        // Update ArtifactSO with the highest relevant skill
        gameManager.activeArtifact.successThreshold = GetBestSkillForAgent(selectedAgent);
        Debug.Log($"Using skill with threshold: {gameManager.activeArtifact.successThreshold}");
        UpdateArtifactStatus();
    }

    // Determine the highest relevant skill for the selected agent
    private int GetBestSkillForAgent(AgentSO agent)
    {
        int electronics = agent.GetSkillLevel(AgentSkill.Electronics);
        int electricRepair = agent.GetSkillLevel(AgentSkill.ElectricRepair);
        int mechanicalRepair = agent.GetSkillLevel(AgentSkill.MechanicalRepair);
        //int weirdScience = agent.GetSkillLevel(AgentSkill.WeirdScience);

        return Mathf.Max(electronics, electricRepair, mechanicalRepair); //weirdScience
    }

    // Update the artifact's research status
    private void UpdateArtifactStatus()
    {
        if (gameManager.activeArtifact == null)
        {
            artifactStatusText.text = "No artifact is currently being researched.";
            return;
        }

        var artifact = gameManager.activeArtifact;
        artifactStatusText.text = $"Artifact: {artifact.unidentifiedName}\n" +
                                  $"Remaining Research Time: {artifact.remainingResearchTime}\n" +
                                  $"Under Research: {artifact.isUnderResearch}";
    }
}
