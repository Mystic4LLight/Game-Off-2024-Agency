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
        Debug.Log($"Artifact {artifact.artifactName} assigned for analysis.");
    }

    public void AnalyzeArtifact()
    {
        if (artifactToAnalyze == null || assignedAgent == null || assignedAgent.agentSO == null)
        {
            Debug.LogWarning("Artifact or Agent not assigned.");
            return;
        }

        // Correctly access the skill level from the AgentSO skills dictionary
        if (assignedAgent.agentSO.skills.TryGetValue(artifactToAnalyze.requiredSkillForAnalysis, out int skillLevel))
        {
            remainingResearchTime -= skillLevel;
            Debug.Log($"Analyzed artifact: {artifactToAnalyze.artifactName}. Remaining time: {remainingResearchTime}");
        }
        else
        {
            Debug.LogWarning($"Skill {artifactToAnalyze.requiredSkillForAnalysis} not found for Agent {assignedAgent.agentSO.agentName}.");
        }

        if (remainingResearchTime <= 0)
        {
            Debug.Log($"Artifact {artifactToAnalyze.artifactName} fully researched!");
        }
    }
}
