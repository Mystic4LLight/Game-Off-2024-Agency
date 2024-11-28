using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Agent : MonoBehaviour
{
    [Header("Agent Details")]
    [SerializeField] public AgentSO agentSO;

    private List<Effect> activeEffects = new(); // List of active effects on the agent
    

    // Start is called before the first frame update
    void Start()
    {
        if (agentSO == null)
        {
            GameLogger.LogError("AgentSO is not assigned!");
            return;
        }

        GameLogger.Log($"Initializing Agent: {agentSO.agentName}");
        InitializeAgentStats();
    }

    /// <summary>
    /// Initializes the agent's stats based on the AgentSO and its stat template.
    /// </summary>
    public void InitializeAgentStats()
    {
        if (agentSO.statTemplate == null)
        {
            GameLogger.LogError($"AgentSO '{agentSO.agentName}' does not have a stat template assigned.");
            return;
        }

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

        GameLogger.LogWarning($"Stat '{statName}' not found for Agent '{agentSO.agentName}'.");
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
            GameLogger.Log($"Updated {statName} for Agent {agentSO.agentName} to {newValue}.");
        }
        else
        {
            GameLogger.LogWarning($"Stat '{statName}' not found for Agent '{agentSO.agentName}'.");
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

        GameLogger.LogWarning($"Skill '{skillName}' not found for Agent '{agentSO.agentName}'.");
        return 0;
    }

    /// <summary>
    /// Applies an effect to the agent.
    /// </summary>
    /// <param name="effect">The effect to apply.</param>
    public bool ApplyEffect(Effect effect)
    {
        if (effect == null)
        {
            GameLogger.LogWarning("Effect is null, cannot apply.");
            return false;
        }

        EffectSO effectSO = effect.effectSO;

        if (effectSO != null)
        {
            // Apply the effect, assuming it's a void method
            effectSO.ApplyEffect(agentSO, effect);

            // If you need to add the effect, do it after ensuring ApplyEffect() executes
            activeEffects.Add(effect);
            GameLogger.Log($"Effect '{effectSO.name}' applied to Agent '{agentSO.agentName}'.");
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
        EffectSO effectSO = effect.effectSO;

        if (activeEffects.Contains(effect))
        {
            activeEffects.Remove(effect);
            GameLogger.Log($"Effect '{effectSO.name}' removed from Agent '{agentSO.agentName}'.");
        }
        else
        {
            GameLogger.LogWarning($"Effect '{effectSO.name}' not found on Agent '{agentSO.agentName}'.");
        }
    }

    /// <summary>
    /// Updates the active effects on the agent.
    /// </summary>
    public void UpdateEffects()
    {
        foreach (var effect in activeEffects)
        {
            effect.UpdateEffect();
        }

        //activeEffects.RemoveAll(effect => effect.IsExpired);
        GameLogger.Log($"Updated effects for Agent '{agentSO.agentName}'.");
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
            GameLogger.Log($"Agent '{agentSO.agentName}' has died due to damage.");
        }
        else
        {
            GameLogger.Log($"Agent '{agentSO.agentName}' took {damage} damage. Remaining Constitution: {currentConstitution - damage}");
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
        GameLogger.Log($"Agent {agentSO.agentName}'s stats and skills have been reset.");
    }

    public int GetAffectedStatValue(string statName)
    {
        // Example logic for fetching stats
        return 0; // Replace with actual stat-fetching logic
    }
}