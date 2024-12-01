using System;
using UnityEngine;

public static class AgentEventManager
{
    public static event Action<AgentSO, AgentPanel> OnAgentSOAssigned;

    public static void RaiseAgentSOAssigned(AgentSO agentSO, AgentPanel agentPanel)
    {
        OnAgentSOAssigned?.Invoke(agentSO, agentPanel);
    }
}