using UnityEngine;

[CreateAssetMenu(fileName = "New Artifact", menuName = "Game/Artifact")]
public class ArtifactSO : ScriptableObject
{
    public string artifactName;
    public string description;
    public string requiredSkillForAnalysis = "Electronics";
    public int researchTime = 10;
    public string unidentifiedName; // Placeholder name
    public string displayName; // Display name when identified
    public bool hasCurse; // Indicates if the artifact is cursed

    // Placeholder fields
    public int researchTimeRequired = 10;
    public Sprite profilePhoto;
}
