using UnityEngine;

[CreateAssetMenu(fileName = "EffectSO_Injured", menuName = "Scriptable Objects/Effects/Injured")]
public class EffectSO_Injured : EffectSO
{
    public new Sprite icon;
    public int requiredTime = 3; // The number of days required to remove the injury effect
    public override void ApplyEffect(AgentSO agentSO, Effect effect)
    {
        Debug.Log($"{effectName} applied to {agentSO.agentName}");
        // Logic to apply "Injured" effect, e.g., reduce health stat
        agentSO.UpdateBarStat("Health", -20);
    }

    public override bool CanRemoveEffect(AgentSO agentSO)
    {
        // Check if the agent is in the infirmary
        return agentSO.IsInInfirmary()>= requiredTime;
    }

    public override void RemoveEffect(AgentSO agentSO, Effect effect)
    {
        if (CanRemoveEffect(agentSO))
        {
            Debug.Log($"{effectName} removed from {agentSO.agentName}");
            // Logic to remove "Injured" effect, e.g., restore health
            agentSO.UpdateBarStat("Health", 20);
        }
        else
        {
            Debug.LogWarning($"Cannot remove {effectName} from {agentSO.agentName}");
        }
    }
}
