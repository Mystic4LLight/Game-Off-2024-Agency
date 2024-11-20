using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AgentStatTemplateSO", menuName = "Scriptable Objects/AgentStatTemplateSO")]
public class AgentStatTemplateSO : ScriptableObject
{
    public List<AgentStatTemplate> stats = new List<AgentStatTemplate>();

    private void OnEnable()
    {
        // Добавляем параметры, если их нет
        if (stats.Count == 0)
        {
            stats.Add(new AgentStatTemplate { name = "HP", description = "Hit Points", defaultValue = 100 });
            stats.Add(new AgentStatTemplate { name = "MP", description = "Mana Points", defaultValue = 50 });
            stats.Add(new AgentStatTemplate { name = "San", description = "Sanity", defaultValue = 100 });
            stats.Add(new AgentStatTemplate { name = "Luck", description = "Luck", defaultValue = 10 });
        }
    }
}
