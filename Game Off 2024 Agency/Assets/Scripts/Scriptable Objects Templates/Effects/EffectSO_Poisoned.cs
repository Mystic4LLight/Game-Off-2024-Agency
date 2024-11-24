using UnityEngine;

public class EffectSO_Poisoned : EffectSO
{
    public int severityMin = 1; // Minimum poison severity
    public int severityMax = 5; // Maximum poison severity

    /// <summary>
    /// Applies the poison effect to an agent.
    /// </summary>
    /// <param name="effect">The effect instance being applied.</param>
    /// <param name="agent">The agent receiving the effect.</param>
    /// <returns>True if the effect is successfully applied, false otherwise.</returns>
    public override bool ApplyEffect(Effect effect, Agent agent)
    {
        if (agent == null || agent.agentSO == null)
        {
            Debug.LogWarning("Agent or AgentSO is null, cannot apply poison effect.");
            return false;
        }

        // Each in-game day, roll for poison severity
        int dailySeverity = Random.Range(severityMin, severityMax);
        int currentConstitution = agent.GetStatValue("Constitution");

        if (currentConstitution <= 0)
        {
            Debug.LogWarning($"Agent {agent.agentSO.agentName} already has 0 Constitution and cannot take further damage.");
            return false;
        }

        // Reduce Constitution based on daily severity
        agent.UpdateStatValue("Constitution", currentConstitution - dailySeverity);
        Debug.Log($"Agent {agent.agentSO.agentName} takes {dailySeverity} poison damage. Remaining Constitution: {agent.GetStatValue("Constitution")}");

        // Check if the agent's Constitution reaches 0
        if (agent.GetStatValue("Constitution") <= 0)
        {
            agent.TakeDamage(currentConstitution); // Trigger death handling in TakeDamage
            Debug.Log($"Agent {agent.agentSO.agentName} has succumbed to poison.");
        }

        return true;
    }

    /// <summary>
    /// Removes the poison effect from an agent.
    /// </summary>
    /// <param name="agent">The agent from which the effect is being removed.</param>
    /// <param name="effect">The effect instance being removed.</param>
    public void RemoveEffect(Agent agent, Effect effect)
    {
        if (agent == null)
        {
            Debug.LogWarning("Agent is null, cannot remove poison effect.");
            return;
        }

        agent.RemoveEffect(effect); // Ensure the effect instance is properly removed
        Debug.Log($"Poison effect removed from Agent {agent.agentSO.agentName}.");
    }
}
