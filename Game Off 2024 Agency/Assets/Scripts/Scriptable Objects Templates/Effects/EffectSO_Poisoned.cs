
using UnityEngine;

public class EffectSO_Poisoned : EffectSO
{
    public int severityMin = 1; // Minimum poison severity
    public int severityMax = 5; // Maximum poison severity

    public override bool ApplyEffect(Effect effect, Agent agent)
    {
        if (agent == null)
        {
            Debug.LogWarning("Agent is null, cannot apply poison effect.");
            return false;
        }

        // Each in-game day, roll for poison severity
        int dailySeverity = Random.Range(severityMin, severityMax);
        int currentConstitution = agent.GetStat("Constitution");

        agent.ReduceStat("Constitution", dailySeverity);
        Debug.Log($"Agent {agent.agentName} takes {dailySeverity} poison damage. Constitution: {agent.GetStat("Constitution")}");

        // Check if the agent's constitution reaches 0
        if (agent.GetStat("Constitution") <= 0)
        {
            agent.Die("Poison");
        }

        return true;
    }

    public void RemoveEffect(Agent agent, Effect effect)
    {
        agent.RemoveEffect(effect); // Pass the correct Effect instance
        Debug.Log($"Poison effect removed from Agent {agent.agentName}.");
    }
}
