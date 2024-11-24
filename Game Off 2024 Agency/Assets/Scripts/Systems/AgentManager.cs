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
    public RecruitmentPanel recruitmentPanel; // Reference to the RecruitmentPanel
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
    public void RecruitAgent(AgentSO agentSO)
    {        
        Agent newAgent = Instantiate(agentPrefab, agentSpawnPoint.transform.position, agentPrefab.transform.rotation);
        newAgent.agentSO = agentSO;
        activeAgents.Add(newAgent);
        // Remove from recruitment pool
        RemoveFromRecruitmentPool(agentSO);

        // Optional: Call a UI update function here if needed
    }

    public void RemoveFromRecruitmentPool(AgentSO agentSO)
    {
        agentsSO.Remove(agentSO); // Remove from available agents
        Debug.Log($"Removed {agentSO.agentName} from the recruitment pool.");
    }

    public void RejectAgent(AgentSO agentSO)
    {
        AgentManager.Instance.RemoveFromRecruitmentPool(agentSO);
        Debug.Log($"Rejected Agent: {agentSO.agentName}");
        recruitmentPanel.RefreshPanel();
    }

    
}
