using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectSO", menuName = "Scriptable Objects/EffectSO")]
public class EffectSO : ScriptableObject
{
    public string displayName;
    public string description;
    public Sprite profilePhoto;
    public float durationDefault;  // Corris: commented because param with Editor - for Each effectConfig
    // any proprs you want to add

    public virtual bool ApplyEffect(Effect effect, Agent agent)
    {
        if (agent == null)
        {
            Debug.LogWarning("Agent is null, cannot apply effect.");
            return false;
        }

        if (effect == null)
        {
            Debug.LogWarning("Effect is null, cannot apply effect.");
            return false;
        }

        return agent.ApplyEffect(effect);

    }

    public virtual void UpdateEffect(Agent agent)
    {
        // overriden in child classes
    }
}
