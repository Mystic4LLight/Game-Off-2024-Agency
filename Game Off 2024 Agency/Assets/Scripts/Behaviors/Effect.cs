using UnityEngine;


// Class of Effect apply to the Agent or the Environment (rooms)
public class Effect
{
    [SerializeField] public EffectSO effectSO;

    [SerializeField] private float expirationTime;

    public string DisplayName => effectSO.displayName;
    public string Description => effectSO.description;
    public Sprite ProfilePhoto => effectSO.profilePhoto;
    public float Duration => effectSO.duration;

    // IsExpired tells if the effect is expired
    public bool IsExpired => GameTime() >= expirationTime;

    // This is template function, it should be replaced with the real game time
    private float GameTime()
    {
        return 10;
    }

    public bool ApplyEffect(Effect effect, Agent agent)
    {
        expirationTime = GameTime() + effectSO.duration;

        // Special effects appied by the effectSO
        return effectSO.ApplyEffect(effect, agent);
    }

}
