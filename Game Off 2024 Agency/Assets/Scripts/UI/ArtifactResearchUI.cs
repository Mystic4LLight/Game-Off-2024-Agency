using UnityEngine;
using TMPro;

public class ArtifactResearchUI : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI artifactInfoText;
    public TextMeshProUGUI researchProgressText;

    [Header("Artifact and Agents")]
    public ArtifactAnalysis artifactAnalysis;

    public void AssignArtifact(ArtifactSO artifact)
    {
        if (artifactAnalysis != null)
        {
            artifactAnalysis.SetArtifact(artifact);
            UpdateUI();
        }
    }
    

    public void UpdateUI()
    {
        if (artifactAnalysis != null && artifactAnalysis.artifactToAnalyze != null)
        {
            ArtifactSO artifact = artifactAnalysis.artifactToAnalyze;
            artifactInfoText.text = $"Analyzing: {artifact.artifactName}\n";
            researchProgressText.text = $"Time Remaining: {artifact.researchTime} days";
        }
        else
        {
            artifactInfoText.text = "No artifact selected.";
            researchProgressText.text = "";
        }
    }
}
