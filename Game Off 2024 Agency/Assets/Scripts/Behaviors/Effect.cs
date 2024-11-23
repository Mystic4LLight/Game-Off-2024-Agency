using UnityEngine;


// Class of Effect apply to the Agent or the Environment (rooms)
[System.Serializable]
public class Effect
{
    [SerializeField] public EffectConfig effectConfig;
    [SerializeField] public EffectSO EffectSO => effectConfig.effectSO;

    [SerializeField] private float expirationTime;

    public string DisplayName => EffectSO != null ? EffectSO.displayName : "Default DisplayName";
    public string Description => EffectSO != null ? EffectSO.description : "Default Description";
    public Sprite ProfilePhoto => EffectSO != null ? EffectSO.profilePhoto : null;
    public float Duration => EffectSO != null ? effectConfig.duration : 0f;
    public float TimeLeftToExpiration => GameTime() - expirationTime;

    // IsExpired tells if the effect is expired
    public bool IsExpired => GameTime() >= expirationTime;

    // This is template function, it should be replaced with the real game time
    private float GameTime()
    {
        return 10;
    }

    public bool ApplyEffect(Agent agent)
    {
        expirationTime = GameTime() + Duration;

        // Special effects appied by the EffectSO
        return EffectSO != null && EffectSO.ApplyEffect(this, agent);
    }

    // Constructor with incoming EffectSO parameter
    public Effect(EffectConfig inEffectConfig)
    {
        effectConfig = inEffectConfig;
    }

    public void UpdateEffect(Agent agent) => EffectSO.UpdateEffect(agent);

}
