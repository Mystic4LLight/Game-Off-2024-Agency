using UnityEngine;

// Hold data to modify stats
[System.Serializable]
public class EffectStatModifier
{
    public string statName; //  AgentStatTemplate.name
    public float delta = 0;   // Amount to modify the stat (0 for no change)
    public float multiplier = 1;    // Multiplier to apply to the stat (1 for no change)

    public EffectStatModifier(string statName, float delta, float multiplier)
    {
        this.statName = statName;
        this.delta = delta;
        this.multiplier = multiplier;
    }
}
