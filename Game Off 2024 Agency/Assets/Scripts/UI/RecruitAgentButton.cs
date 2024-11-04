using UnityEngine;

public class RecruitAgentButton : MonoBehaviour
{
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
        if (agentPrefab != null){
            Instantiate(agentPrefab, agentSpawnPoint.transform.position, agentPrefab.transform.rotation);
        }
    }
}
