using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] public ArtifactSO artifactSO;
    [SerializeField] private float currentResearchTime = 0f; // Tracks current research progress
    [SerializeField] public bool identified = false;

    private bool isInitialized = false;

    void Start()
    {
        if (!isInitialized)
        {
            InitializeFromTemplate(artifactSO);
        }
    }

    public void InitializeFromTemplate(ArtifactSO template)
    {
        artifactSO = template;
        name = template.name;
        identified = false;
        ActualizeSprite();
        isInitialized = true;
        currentResearchTime = artifactSO.researchTimeRequired;
    }

    private void ActualizeSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = artifactSO.profilePhoto;
    }

    public void Identify()
    {
        identified = true;
        UpdateSprite();
    }

    public float GetRemainingResearchTime()
    {
        return currentResearchTime;
    }

    public void ReduceResearchTime(float timeReduction)
    {
        currentResearchTime -= timeReduction;
        if (currentResearchTime <= 0)
        {
            Identify();
        }
        
        if (artifactSO.hasCurse)
        {
            // Apply curse effect to the agent (e.g., reduce sanity)
            ApplySanityEffect(artifactSO.sanityEffectOnAgent);
        }
    }

    void ApplySanityEffect(int effect)
    {
        // Assume you have a method to modify the agent's sanity
        //agent.sanity -= effect;
        // You can also trigger UI updates if necessary
}
    private void UpdateSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = artifactSO.profilePhoto;
    }
}
