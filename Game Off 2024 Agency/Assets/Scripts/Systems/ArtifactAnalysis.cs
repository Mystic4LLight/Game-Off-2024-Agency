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
        if (artifactToAnalyze == null || assignedAgent == null)
        {
            Debug.LogWarning("Artifact or Agent not assigned.");
            return;
        }

        int skillLevel = assignedAgent.GetSkillLevel(artifactToAnalyze.requiredSkillForAnalysis);
        remainingResearchTime -= skillLevel;

        Debug.Log($"Analyzed artifact: {artifactToAnalyze.artifactName}. Remaining time: {remainingResearchTime}");

        if (remainingResearchTime <= 0)
        {
            Debug.Log($"Artifact {artifactToAnalyze.artifactName} fully researched!");
        }
    }
}
