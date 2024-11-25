using UnityEngine;

[CreateAssetMenu(fileName = "EffectSO_Insane", menuName = "Scriptable Objects/Effects/Insane")]
public class EffectSO_Insane : EffectSO
{
    public new Sprite icon;
    public override void ApplyEffect(AgentSO agentSO, Effect effect)
    {
        Debug.Log($"{effectName} applied to {agentSO.agentName}");
        // Logic to apply "Insane" effect, e.g., reduce sanity stat
        agentSO.UpdateStat("Sanity", -10);
    }

    public override bool CanRemoveEffect(AgentSO agentSO)
    {
        // Check if the agent has undergone therapy
        return agentSO.HasUndergoneTherapy();
    }

    public override void RemoveEffect(AgentSO agentSO, Effect effect)
    {
        if (CanRemoveEffect(agentSO))
        {
            Debug.Log($"{effectName} removed from {agentSO.agentName}");
            // Logic to remove "Insane" effect, e.g., restore sanity
            agentSO.UpdateStat("Sanity", 10);
        }
        else
        {
            Debug.LogWarning($"Cannot remove {effectName} from {agentSO.agentName}");
        }
    }
}
