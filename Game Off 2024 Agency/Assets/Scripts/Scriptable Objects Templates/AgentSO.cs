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
    public int accounting;
    public int anthropology;
    public int appraise;
    public int archaeology;
    public int artCraft1;
    public int artCraft2;
    public int artCraft3;
    public int charm;
    public int climb;
    public int computerUse;
    public int creditRating;
    public int cthulhuMythos;
    public int disguise;
    public int dodge;
    public int driveAuto;
    public int elecRepair;
    public int electronics;
    public int fastTalk;
    public int fightingBrawl;
    public int fighting2;
    public int fighting3;
    public int firearmsAiming;
    public int firearmsHipshot;
    public int firearms3;
    public int firstAid;
    public int history;
    public int intimidate;
    public int jump;
    public int languageOther1;
    public int languageOther2;
    public int languageOwn;
    public int law;
    public int libraryUse;
    public int listen;
    public int locksmith;
    public int mechRepair;
    public int medicine;
    public int naturalWorld;
    public int navigate;
    public int occult;
    public int opHvMachine;
    public int persuade;
    public int pilot;
    public int psychology;
    public int psychanalysis;
    public int science1;
    public int science2;
    public int science3;
    public int sleightOfHand;
    public int spotHidden;
    public int stealth;
    public int survival1;
    public int swim;
    public int throw1;
    public int track;
    public int other1;
    public int other2;
    public int other3;
    public int other4;
    public int other5;

    // (Corris:) 
    [Header("Stats")]
    public AgentStatTemplateSO statTemplate; // Link to shadblon with list of Stat parameters
    // All stats - edit in Unity Editor
    public List<AgentStat> stats = new();

    // 'Constructor' to add default properties to list
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

        // remove stats that are not in template  (maybe they from old ersion of template)
        stats.RemoveAll(s => !statTemplate.stats.Contains(s.template));
    }

    private void InitializeStats()
    {
        stats = statTemplate.stats
            .Select(template => new AgentStat(template))
            .ToList();
    }

#if UNITY_EDITOR
    private void FindStatTemplate(string _AgentStatTemplateName)
    {
        // Looking for existing in Unity Editor  template AgentStatTemplateSO
      //  string[] guids = AssetDatabase.FindAssets("t:AgentStatTemplateSO");
        string[] guids = AssetDatabase.FindAssets("t:"+ _AgentStatTemplateName);
        if (guids.Length > 0)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            statTemplate = AssetDatabase.LoadAssetAtPath<AgentStatTemplateSO>(path);
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

