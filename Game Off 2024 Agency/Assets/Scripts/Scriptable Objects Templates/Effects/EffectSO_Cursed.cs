using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EffectSO_Cursed", menuName = "Scriptable Objects/Effects/Cursed")]
public class EffectSO_Cursed : EffectSO
{
    public new Sprite icon;
    public override void ApplyEffect(AgentSO agentSO, Effect effect)
    {
        // Define the specific logic for applying the cursed effect to the agent
        agentSO.UpdateStat("Sanity", -effect.intensity);
        GameLogger.Log($"Cursed effect '{effectName}' applied to agent {agentSO.agentName}, reducing sanity by {effect.intensity}");
    }

    public override bool CanRemoveEffect(AgentSO agentSO)
    {
        // Define logic for whether this cursed effect can be removed
        // Example: only remove if a specific ritual is performed
        return agentSO.HasRitualItem(); // Assuming this method exists in AgentSO
    }

    public override void RemoveEffect(AgentSO agentSO, Effect effect)
    {
        if (CanRemoveEffect(agentSO))
        {
            // Logic to revert the effect
            agentSO.UpdateStat("Sanity", 10); // Restore some sanity as an example
            GameLogger.Log($"Cursed effect '{effectName}' removed from agent {agentSO.agentName}");
        }
        else
        {
            GameLogger.LogWarning($"Cannot remove cursed effect '{effectName}' from agent {agentSO.agentName}");
        }
    }

}
