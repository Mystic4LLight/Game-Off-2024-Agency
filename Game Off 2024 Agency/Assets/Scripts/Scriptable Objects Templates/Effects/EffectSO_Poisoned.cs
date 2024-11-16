using UnityEngine;

[CreateAssetMenu(fileName = "EffectSO_Poisoned", menuName = "Scriptable Objects/EffectSO_Poisoned")]
public class EffectSO_Poisoned : EffectSO
{

    public float damageByPoison = 1f;

    public override bool ApplyEffect(Effect effect, Agent agent)
    {
        // Common part of the effect (log for example)
        return base.ApplyEffect(effect, agent);

        // Unique part of the effect
        // .. Poisoned logic if needed
    }

}
