using System.Collections.Generic;
using UnityEngine;

public class AgentMenu : MonoBehaviour
{
    [SerializeField] private List<AgentPanel> agentPanels = new List<AgentPanel>();
    void OnEnable(){
        FillAgents();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FillAgents(){
        for (int i = 0; i < agentPanels.Count; i++){
            agentPanels[i].agentSO = AgentManager.Instance.agentsSO[i];
            if (agentPanels[i].agentSO != null){
                agentPanels[i].fillPanel();
            }
        }
    }
}
