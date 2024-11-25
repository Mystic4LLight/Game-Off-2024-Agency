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
        identified = true;
        UpdateSprite();
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

    // Apply all effects to an agent
    public void ApplyEffects(Agent agent)
    {
        foreach (EffectConfig effectConfig in artifactSO.potentialMissionEffects)
        {
            var _effect = new Effect(effectConfig);
            _effect.ApplyEffect(agent);
        }
    }
}
