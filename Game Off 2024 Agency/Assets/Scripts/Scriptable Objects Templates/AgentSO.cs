using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "AgentSO", menuName = "Scriptable Objects/AgentSO")]
public class AgentSO : ScriptableObject
{
    [Header("Basic Information")]
    public string agentName;
    public string occupation;
    public List<string> hobbies = new List<string>();    // List of hobbies the agent has
    public string archetype;
    public int agentAge;
    public string agentSex;
    public string backstory;
    public string description;
    public Sprite profilePhoto;


    [Header("Characteristics")]
    public Dictionary<string, int> currentStats = new Dictionary<string, int>();

    [Header("Base Stats")]
    public int strength;
    public int constitution;
    public int size;
    public int dexterity;
    public int appearance;
    public int education;
    public int intelligence;
    public int power;
    public int sanity;
    public int hp;
    public int mp;
    public int luck;

    [Header("Bar Stats")]
    public Dictionary<string, BarStatInstance> barStats = new Dictionary<string, BarStatInstance>();

    [Header("Abilities")]
    public Dictionary<string, int> skills;

    [Header("Effects")]
    public List<EffectSO> activeEffects = new List<EffectSO>();

    [Header("Stat Template")]
    public AgentStatTemplateSO statTemplate;

    [Header("Specializations")]
    public List<Specialization> specializations = new List<Specialization>();

    [System.Serializable]
    public class BarStatInstance
    {
        public float currentValue;
        public float maxValue;
    }

    private void OnEnable()
    {
        if (specializations == null)
        {
            specializations = new List<Specialization>();
        }
    }

    public void InitializeFrom(AgentSO other)
    {
        if (other == null)
        {
            GameLogger.LogWarning("Source AgentSO is null, cannot initialize.");
            return;
        }

        agentName = other.agentName;
        occupation = other.occupation;
        agentAge = other.agentAge;
        agentSex = other.agentSex;
        backstory = other.backstory;
        description = other.description;
        profilePhoto = other.profilePhoto;

        currentStats = new Dictionary<string, int>(other.currentStats);
        barStats = new Dictionary<string, BarStatInstance>(other.barStats);
        skills = new Dictionary<string, int>(other.skills);
        activeEffects = new List<EffectSO>(other.activeEffects);
        statTemplate = other.statTemplate;
        specializations = new List<Specialization>(other.specializations);
    }

    public void InitializeAgent()
    {
        if (statTemplate == null)
        {
            GameLogger.LogError($"AgentSO '{name}' does not have a stat template assigned. Please assign one before initialization.");
            return;
        }

        InitializeStats();
        InitializeSkills();
        InitializeSpecializations();
    }

    public void InitializeStats()
    {
        if (statTemplate == null)
        {
            GameLogger.LogError($"AgentSO '{name}' does not have a stat template assigned. Please assign one in the Inspector.");
            return;
        }

        currentStats.Clear();

        foreach (var stat in statTemplate.baseStats)
        {
            int value = (int)stat.defaultValue;
            switch (stat.name)
            {
                case "Strength":
                    strength = value;
                    currentStats["Strength"] = value;
                    break;
                case "Constitution":
                    constitution = value;
                    currentStats["Constitution"] = value;
                    break;
                case "Size":
                    size = value;
                    currentStats["Size"] = value;
                    break;
                case "Dexterity":
                    dexterity = value;
                    currentStats["Dexterity"] = value;
                    break;
                case "Appearance":
                    appearance = value;
                    currentStats["Appearance"] = value;
                    break;
                case "Education":
                    education = value;
                    currentStats["Education"] = value;
                    break;
                case "Intelligence":
                    intelligence = value;
                    currentStats["Intelligence"] = value;
                    break;
                case "Power":
                    power = value;
                    currentStats["Power"] = value;
                    break;
                case "Sanity":
                    sanity = value;
                    currentStats["Sanity"] = value;
                    break;
                case "HP":
                    hp = value;
                    currentStats["HP"] = value;
                    break;
                case "MP":
                    mp = value;
                    currentStats["MP"] = value;
                    break;
                case "Luck":
                    luck = value;
                    currentStats["Luck"] = value;
                    break;
                default:
                    GameLogger.LogWarning($"Stat '{stat.name}' is not recognized in AgentSO initialization.");
                    break;
            }
        }

        GameLogger.Log($"Initialized stats for AgentSO '{name}' using StatTemplate '{statTemplate.name}'");
    }

    public void InitializeSkills()
    {
        if (skills == null)
        {
            skills = new Dictionary<string, int>();
        }

        string[] skillNames = new string[]
        {
            "Accounting", "Anthropology", "Appraise", "Archaeology", "History", "Law", "LibraryUse",
            "Charm", "FastTalk", "Intimidate", "Persuade",
            "Climb", "Dodge", "Jump", "SleightOfHand", "Stealth", "Swim", "Throw", "Track",
            "Fighting(Brawl)", "Firearms(Aiming)", "Firearms(Hipshot)", "FirstAid",
            "ElecRepair", "Electronics", "MechRepair", "Locksmith", "OpHvMachine",
            "Medicine", "NaturalWorld", "Occult", "Psychoanalysis", "Psychology", "Navigate",
            "SpotHidden", "Listen",
            "ComputerUse", "CthulhuMythos", "Pilot"
        };

        foreach (var skillName in skillNames)
        {
            if (!skills.ContainsKey(skillName))
            {
                skills[skillName] = 0;
            }
        }

        if (statTemplate != null)
        {
            foreach (var templateSkill in statTemplate.abilities)
            {
                if (!skills.ContainsKey(templateSkill.name))
                {
                    skills[templateSkill.name] = (int)templateSkill.defaultValue;
                }
            }
        }
        else
        {
            GameLogger.LogWarning($"StatTemplate is not assigned for AgentSO: {agentName}. Skills will not be populated.");
        }
    }

    public void InitializeSpecializations()
{
    if (specializations == null)
    {
        specializations = new List<Specialization>();
    }

    GameLogger.Log($"Initializing specializations for {agentName}.");

    // Clear existing specializations before reinitializing
    specializations.Clear();

    // Adding all 18 specializations with default placeholder names to ensure consistency
    specializations.Add(new Specialization(Specialization.SpecializationType.ArtCraft, "Art/Craft", 5));
    specializations.Add(new Specialization(Specialization.SpecializationType.ArtCraft, "----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.ArtCraft, "----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.Fighting, "----", 25));
    specializations.Add(new Specialization(Specialization.SpecializationType.Fighting, "----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.Firearms, "----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.Language, "Language(Other)\n----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.Language, "----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.Language, "Language(Own)\n----", 40));
    specializations.Add(new Specialization(Specialization.SpecializationType.Science, "Science\n----", 1));
    specializations.Add(new Specialization(Specialization.SpecializationType.Science, "----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.Science, "----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.Survival, "Survival\n----", 10));
    specializations.Add(new Specialization(Specialization.SpecializationType.Other, "----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.Other, "----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.Other, "----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.Other, "----", 0));
    specializations.Add(new Specialization(Specialization.SpecializationType.Other, "----", 0));

    specializations.Sort((a, b) => a.type.CompareTo(b.type));
    GameLogger.Log("Specializations sorted: " + string.Join(", ", specializations.Select(s => s.type.ToString())));

    GameLogger.Log($"Specializations initialized for {agentName}. Total specializations: {specializations.Count}");
}


    public void UpdateStat(string statName, int value)
    {
        if (currentStats.ContainsKey(statName))
        {
            currentStats[statName] = Mathf.Max(0, value);
            GameLogger.Log($"{agentName}'s {statName} updated to {value}.");
        }
        else
        {
            GameLogger.LogWarning($"Stat {statName} not found for {agentName}.");
        }
    }

    public void UpdateBarStat(string statName, float amount)
    {
        if (!barStats.ContainsKey(statName))
        {
            GameLogger.LogWarning($"Bar Stat {statName} not found for {agentName}.");
            return;
        }

        barStats[statName].currentValue = Mathf.Clamp(
            barStats[statName].currentValue + amount,
            0,
            barStats[statName].maxValue
        );
    }

    public bool HasAntidote()
    {
        return false;
    }

    public int IsInInfirmary()
    {
        return 0;
    }

    public bool HasUndergoneTherapy()
    {
        return false;
    }

    public bool HasRitualItem()
    {
        return false;
    }

    public void ResetStatsAndSkills()
    {
        InitializeStats();
        InitializeSkills();
        GameLogger.Log($"{agentName}'s stats and skills have been reset.");
    }

    public void AddSpecialization(Specialization.SpecializationType type, string name, int value = 0)
    {
        if (specializations.Exists(s => s.type == type && s.name == name))
        {
            GameLogger.LogWarning($"Specialization {name} of type {type} already exists for {agentName}.");
            return;
        }

        specializations.Add(new Specialization(type, name, value));
        GameLogger.Log($"Added specialization: {name} ({type}) with value {value} to {agentName}.");
    }

    public void UpdateSpecialization(string name, int value)
    {
        var specialization = specializations.Find(s => s.name == name);
        if (specialization != null)
        {
            specialization.value = value;
            GameLogger.Log($"Updated specialization: {name} to value {value}.");
        }
        else
        {
            GameLogger.LogWarning($"Specialization {name} not found for {agentName}.");
        }
    }

    public bool HasSpecialization(string name)
    {
        return specializations.Exists(s => s.name == name);
    }

    public int GetStatValue(string statName)
    {
        if (currentStats.ContainsKey(statName))
            return currentStats[statName];
        GameLogger.LogWarning($"Stat {statName} not found for {agentName}");
        return 0;
    }

    public float GetBarStatCurrentValue(string statName)
    {
        return barStats.ContainsKey(statName) ? barStats[statName].currentValue : 0;
    }

    public float GetBarStatMaxValue(string statName)
    {
        return barStats.ContainsKey(statName) ? barStats[statName].maxValue : 0;
    }

    public string GetHobbies()
    {
        return string.Join(", ", hobbies);
    }
}
