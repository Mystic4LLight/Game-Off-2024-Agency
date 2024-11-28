using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public abstract class EffectSO : ScriptableObject
{
    public string effectName;
    public string description;
    // Add the icon property here
    public Sprite icon;

    // Apply the effect to the agent
    public abstract void ApplyEffect(AgentSO agentSO, Effect effect);

    // Check if the effect can be removed
    public abstract bool CanRemoveEffect(AgentSO agentSO);

    // Remove the effect from the agent
    public abstract void RemoveEffect(AgentSO agentSO, Effect effect);

    // Optional method to revert any lingering effect impact
    public virtual void RevertEffect(AgentSO agentSO)
    {
        GameLogger.Log($"{effectName} effect reverted for {agentSO.agentName}");
    }
    public virtual bool IsRemovable(AgentSO agentSO)
    {
        // You can add logic here that determines if an effect is removable
        // For now, it returns true, meaning all effects are removable by default.
        return true;
    }
}
