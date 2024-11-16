using UnityEditor.Experimental;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] public ArtifactSO artifactSO;
    [SerializeField] public bool identified = false;

    private bool isInitialized = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // TEST ONLY.  We don't need this for a game.
        if (!isInitialized)
        {
            InitializeFromTemplate(artifactSO);
            Identify();
        }
    }

    // Method to initialize the artifact from ArtifactSO
    public void InitializeFromTemplate(ArtifactSO template)
    {
        artifactSO = template;
        name = template.name;

        identified = false;

        ActualizeSprite();

        isInitialized = true;
    }

    private void ActualizeSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ProfilePhoto;
    }

    // Method to identify the artifact
    public void Identify()
    {
        identified = true;
        ActualizeSprite();
    }

    // Method to get the current ArtifactSO based on identification status
    private ArtifactSO GetCurrentArtifactSO()
    {
        return identified ? artifactSO : ArtifactManager.Instance.unidentifiedArtifactSO;
    }

    public string DisplayName => GetCurrentArtifactSO().displayName;
    public string Description => GetCurrentArtifactSO().description;
    public Sprite ProfilePhoto => GetCurrentArtifactSO().profilePhoto;
}
