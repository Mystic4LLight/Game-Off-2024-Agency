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
            var statValue = _agent.GetStatValue(statName);
            var affectedStat = _agent.GetAffectedStatValue(statName);

            sliderTMP.text = affectedStat.ToString() + "/" + statValue.ToString();

            sliderTMP.color = affectedStat < statValue ? Color.yellow : Color.green;
            if (affectedStat == statValue)
            {
                sliderTMP.color = Color.black;
            }

        }
    }

    private Agent GetAgent()
    {
        var agentPanel = GetComponentInParent<AgentPanel>();
        return agentPanel != null ? agentPanel.agent : null;
    }

}
