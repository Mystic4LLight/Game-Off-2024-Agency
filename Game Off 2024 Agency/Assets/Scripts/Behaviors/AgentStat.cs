using UnityEngine;

[System.Serializable]
public class AgentStat
{
    public AgentStatTemplate template; // Ссылка на шаблон
    public float currentValue;         // Текущее значение

    public AgentStat(AgentStatTemplate template)
    {
        this.template = template;
        this.currentValue = template.defaultValue;
    }
}
