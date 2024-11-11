using UnityEngine;

[CreateAssetMenu(fileName = "ArtifactSO", menuName = "Scriptable Objects/ArtifactSO")]
public class ArtifactSO : ScriptableObject
{
    public string displayName;
    public string description;
    public Sprite profilePhoto;
    // any proprs you want to add
}
