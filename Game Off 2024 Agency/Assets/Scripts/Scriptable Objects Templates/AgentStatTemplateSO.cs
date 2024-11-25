using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AgentStatTemplateSO", menuName = "Scriptable Objects/AgentStatTemplateSO")]
public class AgentStatTemplateSO : ScriptableObject
{
    [Header("Characteristics (Base Stats)")]
    public List<StatEntry> baseStats = new List<StatEntry>
    {
        new StatEntry { name = "Strength", defaultValue = 50 },
        new StatEntry { name = "Constitution", defaultValue = 50 },
        new StatEntry { name = "Size", defaultValue = 65 },
        new StatEntry { name = "Dexterity", defaultValue = 50 },
        new StatEntry { name = "Appearance", defaultValue = 50 },
        new StatEntry { name = "Education", defaultValue = 65 },
        new StatEntry { name = "Intelligence", defaultValue = 65 },
        new StatEntry { name = "Power", defaultValue = 50 },
    };

    [Header("Bar Stats (Health Bar-Like Stats)")]
    public List<BarStat> barStats = new List<BarStat>
    {
        new BarStat { name = "HP", defaultValue = 11, maxValue = 11 },
        new BarStat { name = "MP", defaultValue = 10, maxValue = 10 },
        new BarStat { name = "San", defaultValue = 50, maxValue = 50 },
        new BarStat { name = "Luck", defaultValue = 50, maxValue = 50 }
    };

    [Header("Abilities (Skills)")]
    public List<StatEntry> abilities = new List<StatEntry>
    {
        new StatEntry { name = "Accounting", defaultValue = 10 },
        new StatEntry { name = "Anthropology", defaultValue = 5 },
        new StatEntry { name = "Appraise", defaultValue = 5 },
        new StatEntry { name = "Archaeology", defaultValue = 5 },
        new StatEntry { name = "Charm", defaultValue = 15 },
        new StatEntry { name = "Climb", defaultValue = 20 },
        new StatEntry { name = "ComputerUse", defaultValue = 30 },
        new StatEntry { name = "CreditRating", defaultValue = 20 },
        new StatEntry { name = "CthulhuMythos", defaultValue = 0 },
        new StatEntry { name = "Disguise", defaultValue = 5 },
        new StatEntry { name = "Dodge", defaultValue = 25 },
        new StatEntry { name = "DriveAuto", defaultValue = 20 },
        new StatEntry { name = "ElecRepair", defaultValue = 10 },
        new StatEntry { name = "Electronics", defaultValue = 20 },
        new StatEntry { name = "FastTalk", defaultValue = 5 },
        new StatEntry { name = "Fighting(Brawl)", defaultValue = 25 },
        new StatEntry { name = "FirstAid", defaultValue = 10 },
        new StatEntry { name = "History", defaultValue = 20 },
        new StatEntry { name = "Intimidate", defaultValue = 15 },
        new StatEntry { name = "Jump", defaultValue = 20 },
        new StatEntry { name = "Law", defaultValue = 5 },
        new StatEntry { name = "LibraryUse", defaultValue = 25 },
        new StatEntry { name = "Listen", defaultValue = 25 },
        new StatEntry { name = "Locksmith", defaultValue = 1 },
        new StatEntry { name = "MechRepair", defaultValue = 10 },
        new StatEntry { name = "Medicine", defaultValue = 10 },
        new StatEntry { name = "NaturalWorld", defaultValue = 10 },
        new StatEntry { name = "Navigate", defaultValue = 10 },
        new StatEntry { name = "Occult", defaultValue = 5 },
        new StatEntry { name = "OpHvMachine", defaultValue = 1 },
        new StatEntry { name = "Persuade", defaultValue = 10 },
        new StatEntry { name = "Pilot", defaultValue = 1 },
        new StatEntry { name = "Psychology", defaultValue = 10 },
        new StatEntry { name = "Psychanalysis", defaultValue = 1 },
        new StatEntry { name = "SleightOfHand", defaultValue = 10 },
        new StatEntry { name = "SpotHidden", defaultValue = 25 },
        new StatEntry { name = "Stealth", defaultValue = 20 },
        new StatEntry { name = "Swim", defaultValue = 20 },
        new StatEntry { name = "Throw", defaultValue = 20 },
        new StatEntry { name = "Track", defaultValue = 10 }
    };

    [Header("Specializations")]
    public List<SpecializationPlaceholder> specializations = new List<SpecializationPlaceholder>
    {
        new SpecializationPlaceholder { type = Specialization.SpecializationType.ArtCraft, name = "Art/Craft", defaultValue = 5 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.ArtCraft, name = "Art/Craft2", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.ArtCraft, name = "Art/Craft3", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Language, name = "Language(Other)", defaultValue = 1 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Language, name = "Language2", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Language, name = "Language(Own)", defaultValue = 50 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Science, name = "Science", defaultValue = 20 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Science, name = "Science2", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Science, name = "Science3", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Fighting, name = "Fighting2", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Fighting, name = "Fighting3", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Firearms, name = "Firearms3", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Survival, name = "Survival", defaultValue =0},
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Other, name = "Other1", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Other, name = "Other2", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Other, name = "Other3", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Other, name = "Other4", defaultValue = 0 },
        new SpecializationPlaceholder { type = Specialization.SpecializationType.Other, name = "Other5", defaultValue = 0 }
    };

    [System.Serializable]
    public class StatEntry
    {
        public string name;
        public float defaultValue;
    }
    
    [System.Serializable]
    public class StatTemplate
    {
        public string name; // Name of the stat (e.g., Strength, Dexterity)
        public int defaultValue; // Default value of the stat
    }

    [System.Serializable]
    public class BarStat
    {
        public string name;
        public float defaultValue;
        public float maxValue;
    }

    [System.Serializable]
    public class BarStatTemplate
    {
        public string name; // Name of the bar stat (e.g., HP, MP, SAN)
        public float defaultValue; // Starting value of the bar stat
        public float maxValue; // Maximum value of the bar stat
    }

    [System.Serializable]
    public class SpecializationPlaceholder
    {
        public Specialization.SpecializationType type;
        public string name;
        public float defaultValue;
    }

    private void OnEnable()
    {
        // Ensure lists are initialized
        baseStats ??= new List<StatEntry>();
        abilities ??= new List<StatEntry>();
        specializations ??= new List<SpecializationPlaceholder>();
    }
    public void InitializeStats(Dictionary<string, float> currentStats)
    {
        if (baseStats == null || baseStats.Count == 0)
        {
            Debug.LogWarning("Base stats are not defined in the template.");
            return;
        }

        foreach (var stat in baseStats)
        {
            // Adds stat if missing; otherwise ignores
            if (!currentStats.ContainsKey(stat.name))
            {
                currentStats.Add(stat.name, stat.defaultValue);
            }
        }
    }

    public void InitializeBarStats(Dictionary<string, BarStat> agentBarStats)
    {
        if (barStats == null || barStats.Count == 0)
        {
            Debug.LogWarning("Bar stats are not defined in the template.");
            return;
        }

        foreach (var barStat in barStats)
        {
            // Adds bar stat if missing
            if (!agentBarStats.ContainsKey(barStat.name))
            {
                agentBarStats.Add(barStat.name, barStat);
            }
        }
    }

}
