using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentSO", menuName = "Scriptable Objects/AgentSO")]
public class AgentSO : ScriptableObject
{
    [Header("Basic Information")]
    public string agentName;
    public string occupation;
    public int agentAge;
    public string agentSex;
    public string backstory;
    public string description;
    public Sprite profilePhoto;

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

    public EffectSO effectSO;  // Correct definition of effectSO
    public bool isCursed;      // Correct definition if needed elsewhere
    public AgentSO agentSO;    // Correct definition of agentSO

    public bool HasAntidote()
    {
        // Logic to check for antidote
        return false;
    }

    public int IsInInfirmary()
    {
        // Logic to get time spent in infirmary
        return 0;
    }

    public bool HasUndergoneTherapy()
    {
        return false; // Replace with actual logic.
    }

    public bool HasRitualItem()
    {
        return false; // Replace with actual logic.
    }
    
    public void Effect(EffectSO effectSO)
    {
        this.effectSO = effectSO;
        // Initialize other fields if necessary.
    }


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
        occupation = other.occupation; // Corrected property name
        agentAge = other.agentAge;
        agentSex = other.agentSex;
        backstory = other.backstory; // Corrected property name
        description = other.description; // Added the description property
        profilePhoto = other.profilePhoto; // Corrected property name

        currentStats = new Dictionary<string, int>(other.currentStats);
        barStats = new Dictionary<string, BarStatInstance>(other.barStats);
        skills = new Dictionary<string, int>(other.skills);
        activeEffects = new List<EffectSO>(other.activeEffects);
        statTemplate = other.statTemplate;
        specializations = new List<Specialization>(other.specializations);
    }

    public int GetStatValue(string statName)
    {
        if (currentStats.ContainsKey(statName))
            return currentStats[statName];
        Debug.LogWarning($"Stat {statName} not found for {agentName}");
        return 0;
    }

    public void UpdateStatValue(string statName, int value)
    {
        if (currentStats.ContainsKey(statName))
        {
            currentStats[statName] = Mathf.Clamp(currentStats[statName] + value, 0, 100); // Example range
        }
        else
        {
            Debug.LogWarning($"Stat {statName} not found for {agentName}");
        }
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
    

    public void InitializeStats()
    {
        if (statTemplate == null)
        {
            Debug.LogError($"AgentSO '{name}' does not have a stat template assigned. Please assign one in the Inspector.");
            return;
        }

        // Clear and populate `currentStats`
        currentStats.Clear();
        foreach (var stat in statTemplate.baseStats)
        {
            currentStats[stat.name] = (int)stat.defaultValue;
        }

        // Clear and populate `barStats`
        barStats.Clear();
        foreach (var barStat in statTemplate.barStats)
        {
            barStats[barStat.name] = new BarStatInstance
            {
                currentValue = barStat.defaultValue,
                maxValue = barStat.maxValue
            };
        }
        if (statTemplate == null)
        {
            Debug.LogError($"StatTemplate is not assigned for AgentSO: {agentName}.");
            return;
        }

        foreach (var stat in statTemplate.baseStats)
        {
            if (!currentStats.ContainsKey(stat.name))
            {
                currentStats.Add(stat.name, (int)stat.defaultValue);
            }
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


    

    
    public void InitializeSkills()
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

        Effect effectInstance = new Effect(effect, this); // Pass EffectSO to Effect
        AgentSO runtimeAgent = new AgentSO();

        effect.ApplyEffect(this, effectInstance); // No need to check for boolean return here
        activeEffects.Add(effect);
        Debug.Log($"Effect {effect.effectName} applied to {agentName}.");

    }


    public void RemoveEffect(EffectSO effectSO, Effect effect)
    {
        if (effectSO == null)
        {
            Debug.LogWarning("EffectSO is null, cannot remove effect.");
            return;
        }

        if (!activeEffects.Contains(effectSO))
        {
            Debug.LogWarning($"Effect {effectSO.name} is not active on this agent.");
            return;
        }

        // Revert the changes made by the effect
        effectSO.RevertEffect(this);

        // Remove the effect from activeEffects list
        activeEffects.Remove(effectSO);

        Debug.Log($"Effect {effectSO.name} removed from agent {agentName}.");
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

