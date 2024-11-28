using UnityEngine;

public class ArtifactAnalysis : MonoBehaviour
{
    public ArtifactSO artifactToAnalyze;
    public Agent assignedAgent;

    private int remainingResearchTime;

    private void Start()
    {
        if (artifactToAnalyze != null)
        {
            remainingResearchTime = artifactToAnalyze.researchTime;
        }
    }

    public void SetArtifact(ArtifactSO artifact)
    {
        artifactToAnalyze = artifact;
        GameLogger.Log($"Artifact {artifact.artifactName} assigned for analysis.");
    }

    public void AnalyzeArtifact(string skillName)
    {
        if (artifactToAnalyze == null || assignedAgent == null || assignedAgent.agentSO == null)
        {
            GameLogger.LogWarning("Artifact or Agent not assigned.");
            return;
        }
        string skillKey = artifactToAnalyze.requiredSkillForAnalysis.ToString();
        // Correctly access the skill level from the AgentSO skills dictionary
        if (assignedAgent.agentSO.skills.TryGetValue(skillKey, out int skillLevel))
        {
            remainingResearchTime -= skillLevel;
            GameLogger.Log($"Analyzed artifact: {artifactToAnalyze.artifactName}. Remaining time: {remainingResearchTime}");
        }
        else
        {
            GameLogger.LogWarning($"Skill {artifactToAnalyze.requiredSkillForAnalysis} not found for Agent {assignedAgent.agentSO.agentName}.");
        }

        if (remainingResearchTime <= 0)
        {
            GameLogger.Log($"Artifact {artifactToAnalyze.artifactName} fully researched!");
        }
    }

}
