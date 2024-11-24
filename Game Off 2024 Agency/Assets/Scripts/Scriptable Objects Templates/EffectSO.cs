using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EffectSO", menuName = "Scriptable Objects/EffectSO")]
public class EffectSO : ScriptableObject
{
    public string displayName;
    public string description;
    public Sprite icon;
    public float duration;

    public virtual bool ApplyEffect(Effect effect, Agent agent)
    {
        if (effect != null && agent != null)
        {
            // Example logic for applying an effect
            Debug.Log($"Effect {displayName} applied to agent {agent.agentSO.agentName}.");
            return true;
        }

        Debug.LogWarning("Effect or Agent is null.");
        return false;
    }

    public void RemoveEffect(Dictionary<string, int> stats)
    {
        // Implement logic to remove the effect
    }

    public virtual void UpdateEffect(Agent agent)
    {
        // Overridden in child classes for time-based effects
    }
}
