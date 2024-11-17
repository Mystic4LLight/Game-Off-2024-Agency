using UnityEngine;


// Class of Effect apply to the Agent or the Environment (rooms)
public class Effect
{
    [SerializeField] public EffectSO effectSO;

    [SerializeField] private float expirationTime;

    public string DisplayName => effectSO != null ? effectSO.displayName : "Default DisplayName";
    public string Description => effectSO != null ? effectSO.description : "Default Description";
    public Sprite ProfilePhoto => effectSO != null ? effectSO.profilePhoto : null;
    public float Duration => effectSO != null ? effectSO.duration : 0f;
    public float TimeLeftToExpiration => GameTime() - expirationTime;

    // IsExpired tells if the effect is expired
    public bool IsExpired => GameTime() >= expirationTime;

    // This is template function, it should be replaced with the real game time
    private float GameTime()
    {
        return 10;
    }

    public bool ApplyEffect(Effect effect, Agent agent)
    {
        expirationTime = GameTime() + (effectSO != null ? effectSO.duration : 0f);

        // Special effects appied by the effectSO
        return effectSO != null && effectSO.ApplyEffect(effect, agent);
    }

    // Constructor with incoming EffectSO parameter
    public Effect(EffectSO inEffectSO)
    {
        effectSO = inEffectSO;
    }

    public void UpdateEffect(Agent agent) => effectSO.UpdateEffect(agent);

}
