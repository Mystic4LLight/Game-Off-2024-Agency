using UnityEngine;
using System.Collections.Generic;
using System.Linq; // Make sure you have this using statement

public class Artifact : MonoBehaviour
{
    [SerializeField] public ArtifactSO artifactSO; // Reference to the ScriptableObject
    private int remainingResearchTime; // Remaining research time in days
    public bool isCursed;       // Tracks if the artifact is cursed
    public bool isIdentified; 
    public List<EffectSO> effects;  // Remove the problematic initialization here
    private int sanityLossThreshold; // Maximum sanity loss during research

    /// <summary>
    /// Initializes the artifact at the start of the game.
    /// </summary>
    private void Start()
    {
        InitializeArtifact();
    }

    /// <summary>
    /// Initializes artifact properties from the ScriptableObject.
    /// </summary>
    private void InitializeArtifact()
    {
        if (artifactSO != null)
        {
            remainingResearchTime = artifactSO.researchTime;
            isCursed = artifactSO.isCursed;
            sanityLossThreshold = artifactSO.sanityLossThreshold;

            // Initialize effects list here
            effects = artifactSO.cursedEffects.Cast<EffectSO>().ToList();
        }
        else
        {
            GameLogger.LogError("ArtifactSO is not assigned!");
        }
    }

    public ArtifactSO artifactData;

    public void InitializeFromTemplate(ArtifactSO template)
    {
        if (template == null)
        {
            GameLogger.LogWarning("Template is null, cannot initialize artifact.");
            return;
        }

        artifactData = template; // Assign template
    }

    /// <summary>
    /// Handles the research progress per turn.
    /// </summary>
    /// <param name="researcher">The Agent conducting the research.</param>
    public void ResearchArtifact(AgentSO researcher)
    {
        if (remainingResearchTime <= 0)
        {
            GameLogger.Log("Artifact research is already completed.");
            return;
        }

        // Simulate a research roll
        bool researchRoll = RollForResearchSuccess(researcher);
        if (researchRoll)
        {
            remainingResearchTime--;
            GameLogger.Log($"Research progress made! Remaining research time: {remainingResearchTime} days.");
        }
        else
        {
            GameLogger.Log("Research roll failed. No progress made.");
        }

        // Simulate a sanity roll
        bool sanityRoll = RollForSanityLoss(researcher);
        if (sanityRoll)
        {
            researcher.UpdateStatValue("Sanity", researcher.GetStatValue("Sanity") - 1);
            GameLogger.Log($"Researcher {researcher.agentName} lost 1 sanity point!");
        }

        // Check if the researcher has hit the sanity loss threshold
        if (artifactSO.sanityLossThreshold > 0 && researcher.GetStatValue("Sanity") <= sanityLossThreshold)
        {
            ApplyCursedEffects(researcher);
            GameLogger.Log($"Artifact cursed the researcher {researcher.agentName}!");
        }

        // Check if research is complete
        if (remainingResearchTime <= 0)
        {
            CompleteResearch();
        }
    }

    /// <summary>
    /// Simulates a roll for research success.
    /// </summary>
    /// <param name="researcher">The Agent conducting the research.</param>
    /// <returns>True if the roll succeeds, otherwise false.</returns>
    private bool RollForResearchSuccess(AgentSO researcher)
    {
        // Example: Using a 50% success rate for the research roll
        return Random.value > 0.5f;
    }

    /// <summary>
    /// Simulates a roll for sanity loss.
    /// </summary>
    /// <param name="researcher">The Agent conducting the research.</param>
    /// <returns>True if sanity loss occurs, otherwise false.</returns>
    private bool RollForSanityLoss(AgentSO researcher)
    {
        // Example: Using a 30% chance for sanity loss
        return Random.value > 0.7f;
    }

    /// <summary>
    /// Applies all cursed effects to the researcher.
    /// </summary>
    /// <param name="researcher">The Agent affected by the curse.</param>
    public void ApplyCursedEffects(AgentSO agent)
    {
        if (artifactSO.isCursed && artifactSO.cursedEffects.Count > 0)
        {
            foreach (EffectSO_Cursed cursedEffect in artifactSO.cursedEffects)
            {
                Effect newEffect = new Effect(cursedEffect, agent);
                cursedEffect.ApplyEffect(agent, newEffect);
                GameLogger.Log($"Applying cursed effect: {cursedEffect.effectName} to {agent.agentName}");
            }
        }
    }

    public void ReduceResearchTime(int days)
    {
        remainingResearchTime -= days;
        if (remainingResearchTime <= 0)
        {
            Identify();
        }
    }

    public void Identify()
    {
        isIdentified = true;
        GameLogger.Log("Artifact identified!");
    }

    /// <summary>
    /// Completes the artifact research and logs the result.
    /// </summary>
    private void CompleteResearch()
    {
        GameLogger.Log("Artifact research is complete!");
        // Additional logic, such as unlocking artifact abilities or updating its status, can be added here
    }

    /// <summary>
    /// Gets the remaining research time for the artifact.
    /// </summary>
    /// <returns>Remaining research time in days.</returns>
    public int GetRemainingResearchTime()
    {
        return remainingResearchTime;
    }
}
