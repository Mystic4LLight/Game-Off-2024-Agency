using UnityEngine;

/// <summary>
/// Represents an effect applied to an agent.
/// </summary>
public class Effect
{
    public EffectSO sourceEffect; // Reference to the EffectSO ScriptableObject

    public string DisplayName => sourceEffect != null ? sourceEffect.name : "Unknown Effect";
    public string Description => sourceEffect != null ? sourceEffect.description : "No description available.";
    public int TimeLeftToExpiration { get; private set; } // Expiration time as an integer
    public Sprite ProfilePhoto => sourceEffect != null ? sourceEffect.icon : null;

    public Effect(EffectSO effectSO)
    {
        sourceEffect = effectSO;
        TimeLeftToExpiration = (int)effectSO.duration; // Explicit cast to int
    }

    public void UpdateEffect(Agent agent)
    {
        // Example logic for reducing expiration time
        if (TimeLeftToExpiration > 0)
        {
            TimeLeftToExpiration--;
        }
    }

    public bool IsExpired => TimeLeftToExpiration <= 0;

    public EffectSO GetEffectSO()
    {
        return sourceEffect;
    }
}
