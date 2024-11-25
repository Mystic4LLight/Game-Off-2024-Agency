using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Artifact", menuName = "Game/Artifact")]
public class ArtifactSO : ScriptableObject
{
    [Header("Identification")]
    public string unidentifiedName = "Mysterious Artifact";  // Placeholder name before research
    public string displayName;  // Real name after research
    public string description;  // Full description after research
    public Sprite profilePhoto; // Image for identified artifact in inventory
    public Sprite placeholderPhoto; // Placeholder image for unidentified artifact

    [Header("Research & Analysis")]
    public float researchTimeRequired = 168f; // Total time in in-game hours (e.g., one week)
    public bool isIdentified = false;         // Tracks if artifact has been fully analyzed
    public int maxSanityLoss = 5; 
    public string artifactName;
    public int researchTime; // Assuming this is an integer.
    public AgentSkill requiredSkillForAnalysis;            // Maximum sanity points the artifact can cause


    [Header("Effects")]
    public bool isCursed;            // Indicates if artifact has a negative effect
    public List<EffectSO_Cursed> cursedEffects = new List<EffectSO_Cursed>(); // List of cursed effects
    public bool hasBonusEffect;      // Indicates if artifact has a positive effect
    public string bonusEffectDescription;     // Description of the bonus effect or benefit
    public int sanityEffectOnAgent;
    public int sanityLossThreshold;

    [Header("R&D Integration")]
    public bool leadsToNewTool;       // Indicates if artifact unlocks a new tool in R&D
    public string toolDescription;            // Description of the new tool or function unlocked

    [Header("Potential Mission Effects")]
    // ������ ������������ ������������� �������� � ���� ������
    public List<EffectConfig> potentialMissionEffects = new();

    [System.Serializable]
    public class AgentSkill
    {
        public string skillName; // Name of the skill
        public int skillLevel;   // Skill level
    }

}
