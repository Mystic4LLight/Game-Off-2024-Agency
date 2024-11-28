using UnityEngine;

public class Effect
{
    public EffectSO effectSO { get; private set; }
    public AgentSO agentSO { get; private set; }

    public int intensity;  // New field to resolve the error in EffectSO_Cursed

    public bool IsActive { get; private set; }

    public Effect(EffectSO effectSO, AgentSO agentSO)
    {

        this.effectSO = effectSO;
        this.agentSO = agentSO;
        this.IsActive = true;

        // Initialize intensity or any other property as needed
        intensity = 1; // Default value or set dynamically based on the effect
    }

    // New getter method to resolve the error in Agent.cs
    public EffectSO GetEffectSO()
    {
        return effectSO;
    }

    public string DisplayName => effectSO != null ? effectSO.effectName : "Unknown Effect";
    public string Description => effectSO != null ? effectSO.description : "No Description Available";
    public int TimeLeftToExpiration => 0; // Set an appropriate value if time-based effects are needed in the future.
    public Sprite Icon => effectSO != null ? effectSO.icon : null; // Assuming `effectSO` has an icon.


    public void ApplyEffect()
    {
        if (effectSO == null || agentSO == null)
        {
            GameLogger.LogWarning("EffectSO or AgentSO is null! Cannot apply effect.");
            return;
        }
        Sprite effectIcon = effectSO.icon;

        effectSO.ApplyEffect(agentSO, this);
    }

    public void CheckForRemoval()
    {
        if (effectSO == null || agentSO == null)
        {
            GameLogger.LogWarning("EffectSO or AgentSO is null! Cannot check for removal.");
            return;
        }

        if (effectSO.IsRemovable(agentSO))
        {
            GameLogger.Log($"Effect '{effectSO.effectName}' is removable.");
            RemoveEffect();
        }
    }

    public void RemoveEffect()
    {
        if (effectSO == null || agentSO == null)
        {
            GameLogger.LogWarning("EffectSO or AgentSO is null! Cannot remove effect.");
            return;
        }

        effectSO.RemoveEffect(agentSO, this);
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    /// <summary>
    /// Updates the effect for the assigned agent.
    /// </summary>
    public void UpdateEffect()
    {
        if (effectSO == null || agentSO == null)
        {
            GameLogger.LogWarning("EffectSO or AgentSO is null! Cannot update effect.");
            return;
        }

        // Add your custom update logic here if required
        GameLogger.Log($"Updating effect '{effectSO.effectName}' for agent '{agentSO.agentName}'.");
    }
}
