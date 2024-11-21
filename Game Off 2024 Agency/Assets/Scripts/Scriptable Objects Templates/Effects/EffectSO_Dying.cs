using UnityEngine;

[CreateAssetMenu(fileName = "EffectSO_Dying", menuName = "Scriptable Objects/EffectSO_Dying")]
public class EffectSO_Dying : EffectSO
{
    public override bool ApplyEffect(Effect effect, Agent agent)
    {
        // Common part of the effect (log for example)
        return base.ApplyEffect(effect, agent);

        // Unique part of the effect
        // .. Dying logic if needed
    }

}

