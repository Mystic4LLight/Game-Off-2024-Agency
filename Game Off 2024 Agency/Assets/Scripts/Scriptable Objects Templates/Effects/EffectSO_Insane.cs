using UnityEngine;

[CreateAssetMenu(fileName = "EffectSO_Insane", menuName = "Scriptable Objects/EffectSO_Insane")]
public class EffectSO_Insane : EffectSO
{
    public override bool ApplyEffect(Effect effect, Agent agent)
    {
        // Common part of the effect (log for example)
        return base.ApplyEffect(effect, agent);

        // Unique part of the effect
        // .. Insane logic if needed
    }
}
