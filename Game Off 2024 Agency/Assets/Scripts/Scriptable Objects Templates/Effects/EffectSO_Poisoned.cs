using UnityEngine;

[CreateAssetMenu(fileName = "EffectSO_Poisoned", menuName = "Scriptable Objects/Effects/Poisoned")]
public class EffectSO_Poisoned : EffectSO
{
    public new Sprite icon;
    public override void ApplyEffect(AgentSO agentSO, Effect effect)
    {
        GameLogger.Log($"{effectName} applied to {agentSO.agentName}");
        // Logic to apply "Poisoned" effect, e.g., reduce health over time
        agentSO.UpdateBarStat("Health", -5);
    }

    public override bool CanRemoveEffect(AgentSO agentSO)
    {
        // Check if the agent has an antidote
        return agentSO.HasAntidote();
    }

    public override void RemoveEffect(AgentSO agentSO, Effect effect)
    {
        if (CanRemoveEffect(agentSO))
        {
            GameLogger.Log($"{effectName} removed from {agentSO.agentName}");
            // Logic to stop poison damage
        }
        else
        {
            GameLogger.LogWarning($"Cannot remove {effectName} from {agentSO.agentName}");
        }
    }
}
