using UnityEngine;

[CreateAssetMenu(fileName = "EffectSO_Injured", menuName = "Scriptable Objects/EffectSO_Injured")]
public class EffectSO_Injured : EffectSO
{
    public override bool ApplyEffect(Effect effect, Agent agent)
    {
        // Common part of the effect (log for example)
        return base.ApplyEffect(effect, agent);

        // Unique part of the effect
        // .. Injure logic if needed
    }
}
