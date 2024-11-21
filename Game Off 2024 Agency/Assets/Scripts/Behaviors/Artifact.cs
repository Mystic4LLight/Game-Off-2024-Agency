using UnityEngine;

public class Artifact : MonoBehaviour
{
    public ArtifactSO artifactSO;
    private int remainingResearchTime;

    public void InitializeFromTemplate(ArtifactSO template)
    {
        artifactSO = template;
        remainingResearchTime = template.researchTime;
    }

    public int GetRemainingResearchTime()
    {
        return remainingResearchTime;
    }

    public void ReduceResearchTime(int time)
    {
        remainingResearchTime -= time;
        if (remainingResearchTime <= 0)
        {
            Identify();
        }
    }

    public void Identify()
    {
        Debug.Log($"Artifact {artifactSO.artifactName} has been identified.");
        // Update to identified state here
    }


    public void DisplayArtifactInfo()
    {
        Debug.Log($"Artifact Name: {artifactSO.artifactName}");
        Debug.Log($"Required Skill: {artifactSO.requiredSkillForAnalysis}");
        Debug.Log($"Research Time: {artifactSO.researchTimeRequired}");
    }
}
