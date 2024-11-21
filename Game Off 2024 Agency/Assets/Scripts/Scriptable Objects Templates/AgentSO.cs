using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AgentSO", menuName = "Scriptable Objects/AgentSO")]
public class AgentSO : ScriptableObject
{
    [Header("Basic Info")]
    public string agentName;
    public string description;
    public Sprite portrait;

    [Header("Skills")]
    public Dictionary<string, int> skills = new Dictionary<string, int>
    {
        { "Strength", 10 },
        { "Dexterity", 8 },
        { "Intelligence", 12 },
        { "Charisma", 5 }
    };

    [Header("Stats")]
    public AgentStatTemplateSO statTemplate; // Reference to stat template
    public Dictionary<string, int> currentStats; // Runtime stats

    [Header("Effects")]
    public List<EffectSO> activeEffects = new List<EffectSO>();

    private void OnEnable()
    {
        InitializeStats();
    }

    private void InitializeStats()
    {
        if (statTemplate != null)
        {
            currentStats = new Dictionary<string, int>();
            foreach (var stat in statTemplate.stats)
            {
                currentStats[stat.name] = (int)stat.defaultValue;
            }
        }
        else
        {
            Debug.LogWarning($"Agent {agentName} has no stat template assigned.");
        }
    }

    public void ApplyEffect(EffectSO effect)
    {
        if (effect != null)
        {
            Effect effectInstance = new Effect(effect); // Pass EffectSO to Effect
            Agent runtimeAgent = new Agent(this);       // Convert AgentSO to runtime Agent

            if (effect.ApplyEffect(effectInstance, runtimeAgent)) // Pass runtime Agent
            {
                activeEffects.Add(effect);
                Debug.Log($"Effect {effect.name} applied to {agentName}.");
            }
        }
        else
        {
            Debug.LogWarning("Tried to apply a null effect.");
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
}
