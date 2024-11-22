using System.Collections.Generic;
using System.Linq; // Required for ToList()
using UnityEngine;

public class Agent : MonoBehaviour
{
    public string agentName; // Stores the agent's name
    public AgentSO agentSO; // Reference to the AgentSO ScriptableObject

    private Dictionary<string, int> skills = new Dictionary<string, int>
    {
        { "Strength", 10 },
        { "Constitution", 10 },
        { "Electronics", 5 }
    };

    private List<Effect> activeEffects = new List<Effect>();

    public void Initialize(AgentSO agentSO)
    {
        this.agentSO = agentSO;
        agentName = agentSO.agentName;
        skills = new Dictionary<string, int>(agentSO.skills);
    }
    public Agent(AgentSO agentData)
    {
        agentSO = agentData;
        // Initialize runtime properties as needed
    }
    public int GetStat(string statName)
    {
        if (skills.ContainsKey(statName))
        {
            return skills[statName];
        }
        else
        {
            Debug.LogWarning($"Stat {statName} not found for Agent {agentName}.");
            return 0; // Default value if stat doesn't exist
        }
    }

    public int GetSkillLevel(string skillName)
    {
        if (skills.ContainsKey(skillName))
        {
            return skills[skillName];
        }
        else
        {
            Debug.LogWarning($"Skill {skillName} not found for Agent {agentName}.");
            return 0;
        }
    }

    public void ReduceStat(string statName, int amount)
    {
        if (skills.ContainsKey(statName))
        {
            skills[statName] -= amount;
            if (skills[statName] < 0) skills[statName] = 0;
        }
        else
        {
            Debug.LogWarning($"Stat {statName} not found for Agent {agentName}.");
        }
    }

    public void UpdateEffects()
    {
        foreach (var effect in activeEffects.ToList())
        {
            effect.UpdateEffect(this);
        }
    }

    public bool ApplyEffect(Effect effect)
    {
        if (effect == null)
        {
            Debug.LogWarning("Cannot apply a null effect.");
            return false;
        }

        activeEffects.Add(effect);
        Debug.Log($"Effect {effect.DisplayName} applied to {agentName}.");
        return true;
    }

    public void RemoveEffect(Effect effect)
    {
        if (activeEffects.Contains(effect))
        {
            activeEffects.Remove(effect);
            Debug.Log($"Effect {effect.DisplayName} removed from {agentName}.");
        }
        else
        {
            Debug.LogWarning($"Effect {effect.DisplayName} not found on {agentName}.");
        }
    }

    public void Die(string cause)
    {
        Debug.Log($"{agentName} has died due to {cause}.");
        // Handle death logic here
    }
    public void increaseStatValue(string stat, float value)
    {
        SetStatValue(stat, GetStatValue(stat) + value);
    }
}
