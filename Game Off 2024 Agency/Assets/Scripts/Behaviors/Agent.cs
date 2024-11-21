using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Agent : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] public AgentSO agentSO;
    [SerializeField] private string description;
    [SerializeField] private Sprite profilePhoto;
    [Header("Stats")]
    [SerializeField] private int strength;
    [SerializeField] private int constitution;
    [SerializeField] private int size;
    [SerializeField] private int dexterity;
    [SerializeField] private int appearance;
    [SerializeField] private int education;
    [SerializeField] private int intelligence;
    [SerializeField] private int power;
    [Header("Abilities")]
    [SerializeField] private int accounting;
    [SerializeField] private int anthropology;
    [SerializeField] private int appraise;
    [SerializeField] private int archaeology;
    [SerializeField] private int artCraft1;
    [SerializeField] private int artCraft2;
    [SerializeField] private int artCraft3;
    [SerializeField] private int charm;
    [SerializeField] private int climb;
    [SerializeField] private int computerUse;
    [SerializeField] private int creditRating;
    [SerializeField] private int cthulhuMythos;
    [SerializeField] private int disguise;
    [SerializeField] private int dodge;
    [SerializeField] private int driveAuto;
    [SerializeField] private int elecRepair;
    [SerializeField] private int electronics;
    [SerializeField] private int fastTalk;
    [SerializeField] private int fightingBrawl;
    [SerializeField] private int fighting2;
    [SerializeField] private int fighting3;
    [SerializeField] private int firearmsAiming;
    [SerializeField] private int firearmsHipshot;
    [SerializeField] private int firearms3;
    [SerializeField] private int firstAid;
    [SerializeField] private int history;
    [SerializeField] private int intimidate;
    [SerializeField] private int jump;
    [SerializeField] private int languageOther1;
    [SerializeField] private int languageOther2;
    [SerializeField] private int languageOwn;
    [SerializeField] private int law;
    [SerializeField] private int libraryUse;
    [SerializeField] private int listen;
    [SerializeField] private int locksmith;
    [SerializeField] private int mechRepair;
    [SerializeField] private int medicine;
    [SerializeField] private int naturalWorld;
    [SerializeField] private int navigate;
    [SerializeField] private int occult;
    [SerializeField] private int opHvMachine;
    [SerializeField] private int persuade;
    [SerializeField] private int pilot;
    [SerializeField] private int psychology;
    [SerializeField] private int psychanalysis;
    [SerializeField] private int science1;
    [SerializeField] private int science2;
    [SerializeField] private int science3;
    [SerializeField] private int sleightOfHand;
    [SerializeField] private int spotHidden;
    [SerializeField] private int stealth;
    [SerializeField] private int survival1;
    [SerializeField] private int swim;
    [SerializeField] private int throw1;
    [SerializeField] private int track;
    [SerializeField] private int other1;
    [SerializeField] private int other2;
    [SerializeField] private int other3;
    [SerializeField] private int other4;
    [SerializeField] private int other5;

    // (Corris) properties for effects checks
    public bool IsInjured => activeEffects.Any(effect => effect.effectSO is EffectSO_Injured);
    public bool IsDying => activeEffects.Any(effect => effect.effectSO is EffectSO_Dying);
    public bool IsPoisoned => activeEffects.Any(effect => effect.effectSO is EffectSO_Poisoned);
    public bool IsInsane => activeEffects.Any(effect => effect.effectSO is EffectSO_Insane);

    // Corris: List of current stats (standard)
    public List<AgentStat> currentStats = new List<AgentStat>();

    // List of active effects
    private List<Effect> activeEffects = new List<Effect>();

    void Start()
    {
        name = agentSO.name;
        description = agentSO.description;
        profilePhoto = agentSO.profilePhoto;
        //Stats
        strength = agentSO.strength;
        constitution = agentSO.constitution;
        size = agentSO.size;
        dexterity = agentSO.dexterity;
        appearance = agentSO.appearance;
        education = agentSO.education;
        intelligence = agentSO.intelligence;
        power = agentSO.power;
        // Abilities
        accounting = agentSO.accounting;
        anthropology = agentSO.anthropology;
        appraise = agentSO.appraise;
        archaeology = agentSO.archaeology;
        artCraft1 = agentSO.artCraft1;
        artCraft2 = agentSO.artCraft2;
        artCraft3 = agentSO.artCraft3;
        charm = agentSO.charm;
        climb = agentSO.climb;
        computerUse = agentSO.computerUse;
        creditRating = agentSO.creditRating;
        cthulhuMythos = agentSO.cthulhuMythos;
        disguise = agentSO.disguise;
        dodge = agentSO.dodge;
        driveAuto = agentSO.driveAuto;
        elecRepair = agentSO.elecRepair;
        electronics = agentSO.electronics;
        fastTalk = agentSO.fastTalk;
        fightingBrawl = agentSO.fightingBrawl;
        fighting2 = agentSO.fighting2;
        fighting3 = agentSO.fighting3;
        firearmsAiming = agentSO.firearmsAiming;
        firearmsHipshot = agentSO.firearmsHipshot;
        firearms3 = agentSO.firearms3;
        firstAid = agentSO.firstAid;
        history = agentSO.history;
        intimidate = agentSO.intimidate;
        jump = agentSO.jump;
        languageOther1 = agentSO.languageOther1;
        languageOther2 = agentSO.languageOther2;
        languageOwn = agentSO.languageOwn;
        law = agentSO.law;
        libraryUse = agentSO.libraryUse;
        listen = agentSO.listen;
        locksmith = agentSO.locksmith;
        mechRepair = agentSO.mechRepair;
        medicine = agentSO.medicine;
        naturalWorld = agentSO.naturalWorld;
        navigate = agentSO.navigate;
        occult = agentSO.occult;
        opHvMachine = agentSO.opHvMachine;
        persuade = agentSO.persuade;
        pilot = agentSO.pilot;
        psychology = agentSO.psychology;
        psychanalysis = agentSO.psychanalysis;
        science1 = agentSO.science1;
        science2 = agentSO.science2;
        science3 = agentSO.science3;
        sleightOfHand = agentSO.sleightOfHand;
        spotHidden = agentSO.spotHidden;
        stealth = agentSO.stealth;
        survival1 = agentSO.survival1;
        swim = agentSO.swim;
        throw1 = agentSO.throw1;
        track = agentSO.track;
        other1 = agentSO.other1;
        other2 = agentSO.other2;
        other3 = agentSO.other3;
        other4 = agentSO.other4;
        other5 = agentSO.other5;

        // Initializing standard (Corris) AgentStats
        InitializeAgentStats();

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "CorrisScene-Sandbox")
        {
            // (Corris) TEST: Apply some effects to the agent
            Debug.Log("TEST Apply some effects to the agent");
            var _effect = new Effect(EffectManager.Instance.GetEffectSOByName("EffectSO_Poisoned"));
            ApplyEffect(_effect);
            // And show effect in the panel (like if player looking on Hint on agent profile minieffects icon (I guess we will have this one).
            GameObject.Find("Effect_Panel").GetComponent<EffectPanel>().Effect = _effect;
        }


    }

    // Update is called once per frame
    void Update()
    {
        // Corris: Call when needed (not sure do we have turn based system or real time)
        // UpdateEffects();
    }
    
    public void InitializeAgentStats()
    {
        if (agentSO == null)
        {
            Debug.LogError("AgentSO is not assigned!");
            return;
        }
        if (agentSO.statTemplate == null)
        {
            Debug.LogError("StatTemplate is not assigned!");
            return;
        }

        // Копируем шаблон и создаём текущие значения
        currentStats = agentSO.statTemplate.stats
            .Select(template => new AgentStat(template))
            .ToList();
    }

    public void SetStatValue(string name, float newValue)
    {
        var stat = currentStats.FirstOrDefault(s => s.template.name == name);
        if (stat != null)
        {
          //  stat.currentValue = Mathf.Clamp(stat.currentValue + delta, 0, stat.template.defaultValue);
            stat.currentValue = newValue;
        }
    }

    public float GetStatValue(string name)
    {
        var stat = currentStats.FirstOrDefault(s => s.template.name == name);
        if (stat != null)
        {
            return stat.currentValue;
        }
        return 0;
    }

    public bool ApplyEffect(Effect effect)
    {
        if (effect == null)
        {
            Debug.LogWarning("Effect is null, cannot apply effect.");
            return false;
        }

        // Implement the logic to apply the effect to the agent
        // Example: Add a component, modify properties, etc.
        Debug.Log($"Agent: Applying effect {effect.DisplayName} to {(name != null ? name : "NULL")}");

        // Put effect to active effects list
        activeEffects.Add(effect);

        return true;
    }

    // Corris: Call when needed (on time turns)
    public void UpdateEffects()
    {
        // Update all active effects
         foreach (var effect in activeEffects)
         {
             effect.UpdateEffect(this);
         }
        
        // Remove all expired effects
        activeEffects.RemoveAll(effect => effect.IsExpired);
    }

    public void TakeDamage(float damage)
    {
        // hitting agent
        Debug.Log($"Agent: {name} takes {damage} damage");

    }
    public void increaseStatValue(string stat, float value)
    {
        SetStatValue(stat, GetStatValue(stat) + value);
    }
}

