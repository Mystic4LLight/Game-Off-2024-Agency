using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public List<Mission> avaiableMissions = new List<Mission>();
    public static MissionManager Instance;     
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
    public void addAvaiableMission(Mission mission){
        if (mission != null){
            avaiableMissions.Add(mission);
        }
    }
    public void startMission(Mission mission, List<Agent> deployedAgents){
        avaiableMissions.Remove(mission);
        mission._agents = deployedAgents;
        foreach (Agent agent in mission._agents){
            AgentManager.Instance.activeAgents.Remove(agent);
        }
        //in-mission logic here
        foreach (Agent agent in mission._agents){
            AgentManager.Instance.activeAgents.Add(agent);
            mission._agents.Remove(agent);
        }
        

    }
}
