using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ArtifactSO", menuName = "Scriptable Objects/ArtifactSO")]
public class ArtifactSO : ScriptableObject
{
    [Header("Identification")]
    public string unidentifiedName = "Mysterious Artifact";  // Placeholder name before research
    public string displayName;  // Real name after research
    public string description;  // Full description after research
    public Sprite profilePhoto; // Image for identified artifact in inventory
    public Sprite placeholderPhoto; // Placeholder image for unidentified artifact

    [Header("Research & Analysis")]
    public bool isUnderResearch = false;
    public float researchTimeRequired = 168f; // Total time in in-game hours (e.g., one week)
    public int remainingResearchTime = 5;
    public bool isIdentified = false;         // Tracks if artifact has been fully analyzed
    public int maxSanityLoss = 5; 
    public AgentSkill requiredSkillForAnalysis;            // Maximum sanity points the artifact can cause


    [Header("Effects")]
    public bool hasCurse = false;             // Indicates if artifact has a negative effect
    public string curseDescription;           // Description of the curse or negative effect
    public bool hasBonusEffect = false;       // Indicates if artifact has a positive effect
    public string bonusEffectDescription;     // Description of the bonus effect or benefit
    public int sanityEffectOnAgent;

    [Header("R&D Integration")]
    public bool leadsToNewTool = false;       // Indicates if artifact unlocks a new tool in R&D
    public string toolDescription;            // Description of the new tool or function unlocked

    public void IdentifyArtifact()
    {
        isIdentified = true; // Mark artifact as identified
        displayName = string.IsNullOrEmpty(displayName) ? "Identified Artifact" : displayName;
        Debug.Log($"Artifact identified: {displayName}");
    }
}
