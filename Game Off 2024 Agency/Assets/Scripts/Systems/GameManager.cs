using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // Constants for time increments
    public float timeDay = 24f;    // 24 hours in a day
    public float timeHour = 1f;    // 1 hour
    public float timeMinute = 1f / 60;  // 1 minute = 1/60 of an hour
    public float timeSecond = 1f / 3600; // 1 second = 1/3600 of an hour

    // Start time and current game time
    public float dayStart = 6f;   // Game starts at 6 AM
    public float actualTime = 8f; // Initial time set to 8 AM

    public int dayCount = 0;  // Tracks the number of days passed

    // UI References
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI dayCountText;

    // Artifact and Agents
    public ArtifactSO activeArtifact;
    public List<AgentSO> assignedAgents; // Agents currently assigned to the research

    private System.Random random = new System.Random(); // For rolls

    private void Start()
    {
        StartOfDay();
    }

    private void StartOfDay()
    {
        actualTime = dayStart;
        dayCount = 0; // Start from day 0
        UpdateTimeDisplay();
    }

    private void Update()
    {
        UpdateTimeDisplay();
    }

    // Updates the time display in "HH:MM:SS" format and updates the day count
    private void UpdateTimeDisplay()
    {
        if (actualTime >= timeDay)
        {
            actualTime -= timeDay; // Reset time to start of next day
            dayCount++; // Increment the day counter
            AdvanceResearchDay();
        }

        int hours = Mathf.FloorToInt(actualTime) % 24;
        int minutes = Mathf.FloorToInt((actualTime * 60) % 60);
        int seconds = Mathf.FloorToInt((actualTime * 3600) % 60);

        currentTimeText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
        dayCountText.text = $"Day {dayCount}";
    }

    // Advances research time for the active artifact
    public void AdvanceResearchDay()
    {
        if (activeArtifact == null || !activeArtifact.isUnderResearch)
        {
            Debug.Log("No active artifact is being researched.");
            return;
        }

        Debug.Log($"Researching artifact: {activeArtifact.name}");

        // Get the highest skill level for the required skill
        int highestSkill = GetHighestSkillForAnalysis(activeArtifact.requiredSkillForAnalysis);
        Debug.Log($"Highest skill for {activeArtifact.requiredSkillForAnalysis}: {highestSkill}");

        // Perform a roll to determine progress
        int rollResult = random.Next(1, 101); // Simulating a percentage roll
        Debug.Log($"Daily research roll: {rollResult}");

        if (rollResult <= highestSkill)
        {
            // Reduce timer by 2 days on success
            activeArtifact.remainingResearchTime -= 2;
            Debug.Log($"Successful roll! Research time reduced by 2 days. Remaining time: {activeArtifact.remainingResearchTime}");
        }
        else
        {
            // Reduce timer by 1 day on failure
            activeArtifact.remainingResearchTime -= 1;
            Debug.Log($"Failed roll. Research time reduced by 1 day. Remaining time: {activeArtifact.remainingResearchTime}");
        }

        // Check if research is complete
        if (activeArtifact.remainingResearchTime <= 0)
        {
            activeArtifact.remainingResearchTime = 0; // Ensure it doesn't go negative
            activeArtifact.isUnderResearch = false;
            activeArtifact.IdentifyArtifact(); // Mark artifact as identified
            Debug.Log($"Artifact {activeArtifact.name} has been fully researched and identified!");
        }
    }

    // Find the highest skill level among assigned agents for the required skill
    private int GetHighestSkillForAnalysis(AgentSkill requiredSkill)
    {
        int highestSkill = 0;

        foreach (var agent in assignedAgents)
        {
            int skillLevel = agent.GetSkillLevel(requiredSkill);
            if (skillLevel > highestSkill)
            {
                highestSkill = skillLevel;
            }
        }

        return highestSkill;
    }

    // Methods to advance time by increments
    public void AdvanceTimeByDays(float days)
    {
        actualTime += days * timeDay;
        UpdateTimeDisplay();
    }

    public void AdvanceTimeByHours(float hours)
    {
        actualTime += hours * timeHour;
        UpdateTimeDisplay();
    }

    public void AdvanceTimeByMinutes(float minutes)
    {
        actualTime += minutes * timeMinute;
        UpdateTimeDisplay();
    }

    public void AdvanceTimeBySeconds(float seconds)
    {
        actualTime += seconds * timeSecond;
        UpdateTimeDisplay();
    }
}
