using UnityEngine;

public class RecruitAgentButton : MonoBehaviour
{
    [SerializeField] private AgentPanel agentPanel1;
    [SerializeField] private GameObject agentPrefab;
    [SerializeField] private Transform agentSpawnPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void recruitAgent(){
        if (agentPrefab != null && agentPanel1.isClicked == true){
            GameObject newAgent = Instantiate(agentPrefab, agentSpawnPoint.transform.position, agentPrefab.transform.rotation);
            newAgent.GetComponent<Agent>().agentSO = agentPanel1.agentSO;
        }
    }
}
