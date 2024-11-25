using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
// Parametrized class for effects
public class EffectConfig
{
    public EffectSO effectSO; // Effect template
    public float duration = 1; // Effect Duration if you want different than EffectConfig.durationDefault

    // List of stat modifiers (HP, San ... anything)
    public List<EffectStatModifier> statModifiers = new();

    // constructor with EffectSO
    public EffectConfig(EffectSO _effectSO)
    {
        this.effectSO = _effectSO;
    }

}
