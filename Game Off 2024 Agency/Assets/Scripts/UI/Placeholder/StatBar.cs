using TMPro;
using UnityEngine;

public class StatBar : MonoBehaviour
{

    // Info will be update by this name of stat used in Agent.currentStats
    public string statName = "Undefined";
    // Link to TextMeshPro component where we need to change info
    public TextMeshProUGUI sliderTMP;  // TextMeshProUGUI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var _agent = GetAgent();
        if ((_agent != null) && (sliderTMP != null))
        {
            // Directly use the stat value from the currentStats dictionary
            int statValue;
            if (_agent.currentStats.TryGetValue(statName, out statValue))
            {
                // Set the stat value text
                sliderTMP.text = $"{statValue}/{statValue}";
            }
            else
            {
                Debug.LogWarning($"Stat '{statName}' not found for Agent '{_agent.agentName}'.");
            }
        }
    }



    public AgentSO GetAgent()
    {
        var agentPanel = GetComponentInParent<AgentPanel>();
        return agentPanel != null ? agentPanel.agentSO : null;
    }

}
