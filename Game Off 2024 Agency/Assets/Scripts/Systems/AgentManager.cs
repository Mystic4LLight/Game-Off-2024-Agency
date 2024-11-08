using UnityEngine;
using System.Collections.Generic;

public class AgentManager : MonoBehaviour
{
    public List<Agent> agents = new List<Agent>();
    [SerializeField] Agent agentPrefab;
    [SerializeField] public List<AgentSO> agentsSO = new List<AgentSO>();
    [SerializeField] public Transform agentSpawnPoint;
    public List<Agent> activeAgents = new List<Agent>();    
    public static AgentManager Instance;
    void Start()
    {
        if (Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecruitAgent(AgentSO agentSO){        
        Agent newAgent = Instantiate(agentPrefab, agentSpawnPoint.transform.position, agentPrefab.transform.rotation);
        newAgent.agentSO = agentSO;
        activeAgents.Add(newAgent);             
    }
    
}
