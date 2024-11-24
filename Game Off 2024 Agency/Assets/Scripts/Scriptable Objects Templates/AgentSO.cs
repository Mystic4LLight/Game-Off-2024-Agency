using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentSO", menuName = "Scriptable Objects/AgentSO")]
public class AgentSO : ScriptableObject
{
    [Header("Basic Information")]
    public string agentName;
    public string agentOccupation;
    public int agentAge;
    public string agentSex;
    [TextArea]
    public string agentBackstory;
    public Sprite portrait;

    [Header("Characteristics")]
    public Dictionary<string, int> currentStats = new Dictionary<string, int>();

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
        public float currentValue; // Current value of the stat
        public float maxValue;     // Maximum value of the stat
    }

// Initialization method for cloning or copying data from another AgentSO
    public void InitializeFrom(AgentSO other)
    {
        if (other == null)
        {
            Debug.LogWarning("Source AgentSO is null, cannot initialize.");
            return;
        }

        agentName = other.agentName;
        agentOccupation = other.agentOccupation;
        agentAge = other.agentAge;
        agentSex = other.agentSex;
        agentBackstory = other.agentBackstory;
        portrait = other.portrait;

        currentStats = new Dictionary<string, int>(other.currentStats);
        barStats = new Dictionary<string, BarStatInstance>(other.barStats);
        skills = new Dictionary<string, int>(other.skills);
        activeEffects = new List<EffectSO>(other.activeEffects);
        statTemplate = other.statTemplate;
        specializations = new List<Specialization>(other.specializations);
    }



    private void OnEnable()
    {
        Debug.Log($"AgentSO '{name}' is being initialized.");
        InitializeStats();
        InitializeSkills();

        // Clear existing specializations to avoid duplicates
        specializations.Clear();

        // Add specializations with consistent names and values
        specializations.Add(new Specialization(Specialization.SpecializationType.ArtCraft, "Art/Craft", 3));
        specializations.Add(new Specialization(Specialization.SpecializationType.Fighting, "Fighting(Brawl)", 2));
        specializations.Add(new Specialization(Specialization.SpecializationType.Firearms, "Firearms(Hipshot)", 1));
        specializations.Add(new Specialization(Specialization.SpecializationType.Science, "Biology", 3));
        specializations.Add(new Specialization(Specialization.SpecializationType.Language, "Latin", 3));
        specializations.Add(new Specialization(Specialization.SpecializationType.Other, "Other1", 5));
        specializations.Add(new Specialization(Specialization.SpecializationType.Survival, "Survival", 1));

        Debug.Log("Specializations initialized:");
        foreach (var specialization in specializations)
        {
            Debug.Log($"Name: {specialization.name}, Type: {specialization.type}, Value: {specialization.value}");
        }
    }
    

    private void InitializeStats()
    {
        if (statTemplate == null)
        {
            Debug.LogError($"AgentSO '{name}' does not have a stat template assigned. Please assign one in the Inspector.");
            return;
        }

        currentStats.Clear();
        foreach (var stat in statTemplate.baseStats)
        {
            currentStats[stat.name] = (int)stat.defaultValue;
        }

        barStats.Clear();
        foreach (var barStat in statTemplate.barStats)
        {
            barStats[barStat.name] = new BarStatInstance
            {
                currentValue = barStat.defaultValue,
                maxValue = barStat.maxValue
            };
        }

        foreach (var specialization in specializations)
        {
            Debug.Log($"Specialization Initialized: Name = {specialization.name}, Type = {specialization.type}, Value = {specialization.value}");
        }
    }


    public void UpdateBarStat(string statName, float amount)
    {
        if (!barStats.ContainsKey(statName))
        {
            Debug.LogWarning($"Bar Stat {statName} not found for {agentName}.");
            return;
        }

        barStats[statName].currentValue = Mathf.Clamp(
            barStats[statName].currentValue + amount,
            0,
            barStats[statName].maxValue
        );
    }
    public float GetBarStatCurrentValue(string statName)
    {
        return barStats.ContainsKey(statName) ? barStats[statName].currentValue : 0;
    }

    public float GetBarStatMaxValue(string statName)
    {
        return barStats.ContainsKey(statName) ? barStats[statName].maxValue : 0;
    }


    

    
    private void InitializeSkills()
    {
        // Ensure the skills dictionary is initialized
        if (skills == null)
        {
            skills = new Dictionary<string, int>();
        }

        // Skill list with unique keys
        string[] skillNames = new string[]
        {
            // Accounting and Knowledge-Based Skills
            "Accounting", "Anthropology", "Appraise", "Archaeology", "History", "Law", "LibraryUse",

            // Communication and Social Skills
            "Charm", "FastTalk", "Intimidate", "Persuade",

            // Physical and Athletic Skills
            "Climb", "Dodge", "Jump", "SleightOfHand", "Stealth", "Swim", "Throw", "Track",

            // Combat Skills
            "Fighting(Brawl)", "Firearms (Aiming)", "Firearms(Hipshot)", "FirstAid",

            // Technical and Repair Skills
            "ElecRepair", "Electronics", "MechRepair", "Locksmith", "OpHvMachine",

            // Medical and Science Skills
            "Medicine", "NaturalWorld", "Occult", "Psychanalysis", "Psychology", "Navigate",

            // Perception-Based Skills
            "SpotHidden", "Listen",

            // Miscellaneous and Specialized Skills
            "ComputerUse", "CthulhuMythos", "Pilot"
        };


        // Add core skills to the dictionary
        foreach (var skillName in skillNames)
        {
            if (!skills.ContainsKey(skillName))
            {
                skills[skillName] = 0;
            }
        }

        // Specialization placeholders
        string[] specializationPlaceholders = new string[]
        {
            // Art/Craft Specializations
            "Art/Craft", "Art/Craft2", "Art/Craft3",
            
            // Fighting Specializations
            "Fighting2", "Fighting3",
            
            // Firearms Specialization
            "Firearms3",
            
            // Science Specializations
            "Science", "Science2", "Science3",
            
            // Language Specializations
            "Language(Other)", "Language2", "Language(Own)",
            
            // Other Specializations
            "Other1", "Other2", "Other3", "Other4", "Other5", "Survival"
        };

        // Ensure the specializations list is initialized
        if (specializations == null)
        {
            specializations = new List<Specialization>();
        }

        // Add placeholders for specialization skills
        foreach (var placeholder in specializationPlaceholders)
        {
            if (!skills.ContainsKey(placeholder))
            {
                skills[placeholder] = 0;
            }

            // Ensure specialization placeholders exist
            if (!specializations.Exists(s => s.name == placeholder))
            {
                specializations.Add(new Specialization(Specialization.SpecializationType.Language, placeholder, 0));
            }
        }

        // Populate skills from the stat template
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
            Debug.LogWarning($"StatTemplate is not assigned for AgentSO: {agentName}. Skills will not be populated.");
        }

        if (!specializations.Exists(s => s.name == "Biology"))
        {
            specializations.Add(new Specialization(Specialization.SpecializationType.Science, "Biology", 60));
        }
        if (!specializations.Exists(s => s.name == "Latin"))
        {
            specializations.Add(new Specialization(Specialization.SpecializationType.Language, "Latin", 70));
        }
    }


    private static readonly string[] coreSkills = new string[]
    {
        "Accounting", "Anthropology", "Appraise", "Archaeology", 
            "Charm", "Climb", "ComputerUse", "CreditRating", "CthulhuMythos",
            "Disguise", "Dodge", "DriveAuto", "ElecRepair", "Electronics", "FastTalk",
            "Fighting(Brawl)", "Firearms (Aiming)", "Firearms(Hipshot)",
            "FirstAid", "History", "Intimidate", "Jump",
            "Law", "LibraryUse", "Listen", "Locksmith", "MechRepair", "Medicine",
            "NaturalWorld", "Navigate", "Occult", "OpHvMachine", "Persuade", "Pilot",
            "Psychology", "Psychanalysis",
            "SleightOfHand", "SpotHidden", "Stealth", "Survival", "Swim", "Throw", "Track"
    };
    


    public void ApplyEffect(EffectSO effect)
    {
        if (effect == null)
        {
            Debug.LogWarning("Tried to apply a null effect.");
            return;
        }

        Effect effectInstance = new Effect(effect); // Pass EffectSO to Effect
        Agent runtimeAgent = new Agent();
        runtimeAgent.agentSO = this;       // Convert AgentSO to runtime Agent

        if (effect.ApplyEffect(effectInstance, runtimeAgent)) // Pass runtime Agent
        {
            activeEffects.Add(effect);
            Debug.Log($"Effect {effect.name} applied to {agentName}.");
        }
    }


    public void RemoveEffect(EffectSO effect)
    {
        if (activeEffects.Contains(effect))
        {
            activeEffects.Remove(effect);
            effect.RemoveEffect(currentStats);
            Debug.Log($"Effect {effect.name} removed from {agentName}.");
        }
        else
        {
            Debug.LogWarning($"Effect {effect.name} not found on {agentName}.");
        }
    }

    public int GetStat(string statName)
    {
        if (currentStats.ContainsKey(statName))
        {
            return currentStats[statName];
        }
        else
        {
            Debug.LogWarning($"Stat {statName} not found for {agentName}.");
            return 0;
        }
    }

    public void UpdateStat(string statName, int value)
    {
        if (currentStats.ContainsKey(statName))
        {
            currentStats[statName] = Mathf.Max(0, value); // Prevent negative stats
            Debug.Log($"{agentName}'s {statName} updated to {value}.");
        }
        else
        {
            Debug.LogWarning($"Stat {statName} not found for {agentName}.");
        }
    }

    public void ResetStatsAndSkills()
    {
        InitializeStats();
        InitializeSkills();
        Debug.Log($"{agentName}'s stats and skills have been reset.");
    }

    public void AddSpecialization(Specialization.SpecializationType type, string name, int value = 0)
    {
        if (specializations.Exists(s => s.type == type && s.name == name))
        {
            Debug.LogWarning($"Specialization {name} of type {type} already exists for {agentName}.");
            return;
        }

        specializations.Add(new Specialization(type, name, value));
        Debug.Log($"Added specialization: {name} ({type}) with value {value} to {agentName}.");
    }


    public void UpdateSpecialization(string name, int value)
    {
        var specialization = specializations.Find(s => s.name == name);
        if (specialization != null)
        {
            specialization.value = value;
            Debug.Log($"Updated specialization: {name} to value {value}.");
        }
        else
        {
            Debug.LogWarning($"Specialization {name} not found for {agentName}.");
        }
    }

    public void SetSpecialization(Specialization.SpecializationType type, string name, int value = 0)
    {
        if (!specializations.Exists(s => s.type == type && s.name == name))
        {
            specializations.Add(new Specialization(type, name, value));
            Debug.Log($"Specialization {name} of type {type} added with value {value}.");
        }
        else
        {
            Debug.LogWarning($"Specialization {name} of type {type} already exists.");
        }
    }

    public bool HasSpecialization(string name)
    {
        return specializations.Exists(s => s.name == name);
    }

    
    
}

