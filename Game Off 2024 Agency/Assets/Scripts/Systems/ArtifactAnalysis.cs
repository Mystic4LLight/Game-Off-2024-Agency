using UnityEngine;
using System.Collections;
using System;
using Random=UnityEngine.Random;

public class ArtifactAnalysis : MonoBehaviour
{
    [SerializeField] private ArtifactSO unidentifiedArtifact;
    [SerializeField] private ArtifactSO identifiedArtifact;
    [SerializeField] private float baseAnalysisTime = 168f; // 1 week in in-game hours
    [SerializeField] private int successRollThreshold = 4; // Threshold for roll success
    [SerializeField] private int maxSanityLoss = 5; // Maximum sanity points that can be lost during analysis

    private float remainingTime;
    private int currentSanityLoss = 0; // Tracks total sanity lost by agent on this artifact
    private bool isAnalyzing = false;
    

    private void Start()
    {
        remainingTime = baseAnalysisTime; // Set initial timer
    }

    public void StartAnalysis()
    {
        if (isAnalyzing) return;

        isAnalyzing = true;
        currentSanityLoss = 0; // Reset sanity loss count at start of analysis
        StartCoroutine(AnalysisCoroutine());
    }

    private IEnumerator AnalysisCoroutine()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1); // Real time 1 second = 1 hour in-game
            PerformDailyRolls();
            remainingTime--;
        }

        CompleteAnalysis();
    }

    private void PerformDailyRolls()
    {
        // Roll 1: Research success check
        int researchRoll = Random.Range(1, 7); // Example: 1-6 roll
        if (researchRoll >= successRollThreshold)
        {
            remainingTime -= 1; // Decrease timer by 1 day if successful
            Debug.Log("Successful research roll! Time reduced.");
        }
        else
        {
            Debug.Log("Research roll failed.");
        }

        // Roll 2: Sanity loss check
        if (currentSanityLoss < maxSanityLoss) // Only roll if sanity loss limit hasn't been reached
        {
            int sanityRoll = Random.Range(1, 7); // Example: 1-6 roll
            if (sanityRoll < successRollThreshold) // A failed roll causes sanity loss
            {
                currentSanityLoss++;
                Debug.Log("Sanity roll failed. Agent lost 1 sanity point.");
                // You may want to apply this sanity loss to an agent here, e.g., agent.ModifySanity(-1);
            }
            else
            {
                Debug.Log("Sanity roll successful. No sanity lost.");
            }
        }
    }

    public void PerformAnalysisRoll(AgentSO agent)
    {
        if (!isAnalyzing) return;

        // Get the skill level for the required skill
        int agentSkillLevel = agent.GetSkillLevel(unidentifiedArtifact.requiredSkillForAnalysis);

        int roll = Random.Range(1, 7);
        if (roll >= 4) // Success threshold can be modified
        {
            remainingTime -= agentSkillLevel;
            Debug.Log("Successful roll! Time reduced.");
        }
        else
        {
            Debug.Log("Roll failed.");
        }
    }

    private void CompleteAnalysis()
    {
        isAnalyzing = false;
        unidentifiedArtifact = identifiedArtifact; // Replace with identified artifact
        Debug.Log("Artifact analysis complete!");

        // Update the UI with the identified artifact if needed
        // ArtifactUI.Instance.DisplayArtifact(identifiedArtifact);
    }
}
