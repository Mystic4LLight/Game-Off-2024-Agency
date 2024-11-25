using UnityEngine;

[CreateAssetMenu(fileName = "EffectSO_Dying", menuName = "Scriptable Objects/Effects/Dying")]
public class EffectSO_Dying : EffectSO
{
    public new Sprite icon;
    public int requiredTime = 5; // The number of days required to remove the dying effect
    public override void ApplyEffect(AgentSO agentSO, Effect effect)
    {
        Debug.Log($"{effectName} applied to {agentSO.agentName}");
        // Logic to apply the "Dying" effect, e.g., reduce health drastically
        agentSO.UpdateBarStat("Health", -50);
    }

    public override bool CanRemoveEffect(AgentSO agentSO)
    {
        // The "Dying" effect can only be removed if the agent is in the infirmary
        return agentSO.IsInInfirmary() >= requiredTime;
    }

    public override void RemoveEffect(AgentSO agentSO, Effect effect)
    {
        if (CanRemoveEffect(agentSO))
        {
            Debug.Log($"{effectName} removed from {agentSO.agentName}");
            // Logic to remove the "Dying" effect, e.g., restore health
            agentSO.UpdateBarStat("Health", 50);
        }
        else
        {
            Debug.LogWarning($"Cannot remove {effectName} from {agentSO.agentName}");
        }
    }
}
