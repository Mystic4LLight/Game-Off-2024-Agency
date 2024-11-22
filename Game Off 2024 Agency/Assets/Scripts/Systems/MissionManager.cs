using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private List<Mission> avaiableMainMissions = new List<Mission>();
    [SerializeField] private List<Mission> avaiableSideMissions = new List<Mission>();
    public static MissionManager Instance;

    public List<Mission> AvaiableMainMissions { get => avaiableMainMissions; set => avaiableMainMissions = value; }
    public List<Mission> AvaiableSideMissions { get => avaiableSideMissions; set => avaiableSideMissions = value; }

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
    public void createMainMission(Mission missionSO)
    {
        Mission newMission = new Mission();
        avaiableMainMissions.Add(newMission);
    }
    public void createSideMission(Mission missionSO)
    {
        Mission newMission = new Mission();
        avaiableSideMissions.Add(newMission);
    }
    public void addAvaiableMainMission(Mission mission){
        if (mission != null){
            AvaiableMainMissions.Add(mission);
        }
    }
    public void addAvaiableSideMission(Mission mission)
    {
        if (mission != null)
        {
            AvaiableMainMissions.Add(mission);
        }
    }
    public Mission getAvaiableMainMission(int id)
    {
        return AvaiableMainMissions[id];
    }
    public Mission getAvaiableSideMission(int id)
    {
        return AvaiableSideMissions[id];
    }
    public void removeAvaiableMainMission(int id)
    {
        AvaiableMainMissions.RemoveAt(id);
    }
    public void removeAvaiableSideMission(int id)
    {
        AvaiableSideMissions.RemoveAt(id);
    }
    public void startMainMission(Mission mission, List<Agent> deployedAgents){
        AvaiableMainMissions.Remove(mission);  
        
        foreach (Agent agent in deployedAgents){
            AgentManager.Instance.activeAgents.Remove(agent);
            mission.AddAgent(agent);
        }      

    }
    public void startMainMission(Mission mission, List<Agent> deployedAgents, List<Artifact> usedArtifacts)
    {
        AvaiableMainMissions.Remove(mission);

        foreach (Agent agent in deployedAgents)
        {
            AgentManager.Instance.activeAgents.Remove(agent);
            mission.AddAgent(agent);
        }

    }
    public void startSideMission(Mission mission, List<Agent> deployedAgents)
    {
        AvaiableSideMissions.Remove(mission);
        foreach (Agent agent in deployedAgents)
        {
            AgentManager.Instance.activeAgents.Remove(agent);
            mission.AddAgent(agent);
        }

    }

    
    public void endMission(Mission mission, List<Agent> deployedAgents)
    {
        foreach (Agent agent in deployedAgents)
        {
            AgentManager.Instance.activeAgents.Add(agent);
            Destroy(mission);
        }
    }
    



}
