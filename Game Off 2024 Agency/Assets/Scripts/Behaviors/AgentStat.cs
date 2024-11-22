using UnityEngine;

[System.Serializable]
public class AgentStat
{
    public AgentStatTemplate template; // ������ �� ������
    public float currentValue;         // ������� ��������

    public AgentStat(AgentStatTemplate template)
    {
        this.template = template;
        this.currentValue = template.defaultValue;
    }
}
