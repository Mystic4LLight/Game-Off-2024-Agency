using System.Collections.Generic;
using UnityEngine;

public class AgentMenu : MonoBehaviour
{
    [SerializeField] private List<UIAgentFile> agentPanels = new List<UIAgentFile>();
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
            //agentPanels[i].getAgentSO() = AgentManager.Instance.agentsSO[i];
            //if (agentPanels[i].getAgentSO() != null){
                //agentPanels[i].fillPanel();
            //}
        }
    }
}
