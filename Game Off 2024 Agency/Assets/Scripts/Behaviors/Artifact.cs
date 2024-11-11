using UnityEditor.Experimental;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] private string displayName;
    [SerializeField] private string description;
    [SerializeField] private Sprite profilePhoto;
    [SerializeField] public ArtifactSO artifactSO;

    private bool isInitialized = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!isInitialized)
            InitializeFromTemplate(artifactSO);
    }

    // Method to initialize the artifact from ArtifactSO
    public void InitializeFromTemplate(ArtifactSO template)
    {
        artifactSO = template;
        name = template.name;
        displayName = template.displayName;
        description = template.description;
        profilePhoto = template.profilePhoto;
 
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = profilePhoto;
        isInitialized = true;
    }
}
