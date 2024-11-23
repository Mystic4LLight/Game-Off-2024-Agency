using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using System;
using System.Linq;

public class Agent : MonoBehaviour
{
    [Header("Agent Details")]
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
    public bool IsInjured => activeEffects.Any(effect => effect.EffectSO is EffectSO_Injured);
    public bool IsDying => activeEffects.Any(effect => effect.EffectSO is EffectSO_Dying);
    public bool IsPoisoned => activeEffects.Any(effect => effect.EffectSO is EffectSO_Poisoned);
    public bool IsInsane => activeEffects.Any(effect => effect.EffectSO is EffectSO_Insane);

    // Corris: List of current stats (standard)
    public List<AgentStat> currentStats = new();

    // List of active effects
    private List<Effect> activeEffects = new();


    private List<Effect> activeEffects = new(); // List of active effects on the agent

    // Start is called before the first frame update
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

            Effect _effect = null;

            // Getting Artifact Cup Of Healing in scene
            var _artifact = ArtifactManager.Instance.agencyArtifactCatalog.FirstOrDefault(a => a.artifactSO.displayName.Equals("Cup of healing", StringComparison.OrdinalIgnoreCase));
            if (_artifact != null)
            {
                // Applying Artifact effects to the Agent
                _artifact.ApplyEffects(this);

                // to show effect on the panel - choose one of them
                if (activeEffects.Count > 0)
                {
                    _effect = activeEffects[0];
                }
            }
            else
            {
                Debug.LogError("Artifact not found in the catalog");
            }

            /*    
             *    // Sample - to apply effect without Aerifact
             *    // Effect template (default values + name, desription, image)
                  EffectSO _effectSO = EffectManager.Instance.GetEffectSOByName("EffectSO_Poisoned");
                  // object- holder of parameters to change with this effect (for example by Artifact)
                  EffectConfig _effectConfig = new(_effectSO);
                  // we want to modify "HP" stat by +5, and mult 1.2
                  _effectConfig.statModifiers.Add(new EffectStatModifier("HP", +5, 1.2f));
                  // now creating Effect object with this parameters
                  var _effect = new Effect(_effectConfig);

                  // and Applying this effect to the Agent
                  ApplyEffect(_effect);
            */

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

        Debug.Log($"Initializing Agent: {agentSO.agentName}");
        InitializeAgentStats();
    }

    /// <summary>
    /// Initializes the agent's stats based on the AgentSO and its stat template.
    /// </summary>
    public void InitializeAgentStats()
    {
        if (agentSO.statTemplate == null)
        {
            Debug.LogError($"AgentSO '{agentSO.agentName}' does not have a stat template assigned.");
            return;
        }

        // Copy the template and create current values
        currentStats = agentSO.statTemplate.stats
            .Select(template => new AgentStat(template))
            .ToList();
    }

    public void SetStatValue(string name, float newValue)
    {
        var stat = currentStats.FirstOrDefault(s => s.template.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (stat != null)
        {
            //  stat.currentValue = Mathf.Clamp(stat.currentValue + delta, 0, stat.template.defaultValue);
            stat.currentValue = newValue;
        agentSO.ResetStatsAndSkills();
    }

    /// <summary>
    /// Gets the current value of a stat from the AgentSO.
    /// </summary>
    /// <param name="statName">The name of the stat.</param>
    /// <returns>The current value of the stat, or 0 if not found.</returns>
    public int GetStatValue(string statName)
    {
        if (agentSO.currentStats.ContainsKey(statName))
        {
            return agentSO.currentStats[statName];
        }

        Debug.LogWarning($"Stat '{statName}' not found for Agent '{agentSO.agentName}'.");
        return 0;
    }

    /// <summary>
    /// Updates the value of a stat in the AgentSO.
    /// </summary>
    /// <param name="statName">The name of the stat to update.</param>
    /// <param name="newValue">The new value for the stat.</param>
    public void UpdateStatValue(string statName, int newValue)
    {
        if (agentSO.currentStats.ContainsKey(statName))
        {
            agentSO.UpdateStat(statName, newValue);
            Debug.Log($"Updated {statName} for Agent {agentSO.agentName} to {newValue}.");
        }
    }

    // return clear Stat value, without effects
    public float GetStatValue(string name)
    {
        var stat = currentStats.FirstOrDefault(s => s.template.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (stat != null)
        else
        {
            Debug.LogWarning($"Stat '{statName}' not found for Agent '{agentSO.agentName}'.");
        }
    }

    /// <summary>
    /// Gets the skill level for a given skill.
    /// </summary>
    /// <param name="skillName">The name of the skill.</param>
    /// <returns>The skill level, or 0 if the skill does not exist.</returns>
    public int GetSkillLevel(string skillName)
    {
        if (agentSO.skills.ContainsKey(skillName))
        {
            return agentSO.skills[skillName];
        }

        Debug.LogWarning($"Skill '{skillName}' not found for Agent '{agentSO.agentName}'.");
        return 0;
    }

    // return affected stat value
    public float GetAffectedStatValue(string name)
    {
        var clearValue = GetStatValue(name);
        float effectedValue = clearValue;
        // If there is effect affecting this stas - applying it to the return value
        foreach (var effect in activeEffects)
        {
            foreach (var stat in effect.effectConfig.statModifiers)
            {
                if (stat.statName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    effectedValue += stat.delta;
                    effectedValue *= stat.multiplier;
                }
            }
        }
        return effectedValue;
    }


    /// <summary>
    /// Applies an effect to the agent.
    /// </summary>
    /// <param name="effect">The effect to apply.</param>
    public bool ApplyEffect(Effect effect)
    {
        if (effect == null)
        {
            Debug.LogWarning("Effect is null, cannot apply.");
            return false;
        }

        EffectSO effectSO = effect.GetEffectSO(); // Ensure Effect class has GetEffectSO()

        if (effectSO != null && effectSO.ApplyEffect(effect, this))
        {
            activeEffects.Add(effect);
            Debug.Log($"Effect '{effectSO.name}' applied to Agent '{agentSO.agentName}'.");
            return true;
        }

        return false;
    }

    /// <summary>
    /// Removes an effect from the agent.
    /// </summary>
    /// <param name="effect">The effect to remove.</param>
    public void RemoveEffect(Effect effect)
    {
        if (activeEffects.Contains(effect))
        {
            activeEffects.Remove(effect);
            Debug.Log($"Effect '{effect.GetEffectSO().name}' removed from Agent '{agentSO.agentName}'.");
        }
        else
        {
            Debug.LogWarning($"Effect '{effect.GetEffectSO().name}' not found on Agent '{agentSO.agentName}'.");
        }
    }

    /// <summary>
    /// Updates the active effects on the agent.
    /// </summary>
    public void UpdateEffects()
    {
        // Update all active effects
        foreach (var effect in activeEffects)
        {
            effect.UpdateEffect(this);
        }

        // Remove all expired effects
        foreach (var effect in activeEffects)
        {
            effect.UpdateEffect(this);
        }

        activeEffects.RemoveAll(effect => effect.IsExpired);
        Debug.Log($"Updated effects for Agent '{agentSO.agentName}'.");
    }

    /// <summary>
    /// Handles taking damage for the agent.
    /// </summary>
    /// <param name="damage">The amount of damage to take.</param>
    public void TakeDamage(int damage)
    {
        int currentConstitution = GetStatValue("Constitution");
        UpdateStatValue("Constitution", currentConstitution - damage);

        if (currentConstitution - damage <= 0)
        {
            Debug.Log($"Agent '{agentSO.agentName}' has died due to damage.");
        }
        else
        {
            Debug.Log($"Agent '{agentSO.agentName}' took {damage} damage. Remaining Constitution: {currentConstitution - damage}");
        }
    }

    /// <summary>
    /// Checks if the agent has a specific effect.
    /// </summary>
    /// <typeparam name="T">The type of effect to check for.</typeparam>
    /// <returns>True if the effect is active, false otherwise.</returns>
    public bool HasEffect<T>() where T : EffectSO
    {
        return activeEffects.Any(effect => effect.GetEffectSO() is T);
    }

    /// <summary>
    /// Resets all stats and skills of the agent.
    /// </summary>
    public void ResetAgentStatsAndSkills()
    {
        agentSO.ResetStatsAndSkills();
        Debug.Log($"Agent {agentSO.agentName}'s stats and skills have been reset.");
    }
}
