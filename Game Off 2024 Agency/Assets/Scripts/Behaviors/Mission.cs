using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


// Draft Template for a mission class (needed for Artifacts script as a draft)
[System.Serializable]
public class Mission : MonoBehaviour
{
    [SerializeField] private List<Agent> _agents;
    [SerializeField] private List<Artifact> _artifacts = new List<Artifact>();
    [SerializeField] private string missionName;
    [SerializeField] private string description;
    [SerializeField] private int passCheck;
    [SerializeField] private string statCheck;
    [SerializeField] public Sprite missionImage;
    [SerializeField] private MissionSO missionSO;
    

    public global::System.String MissionName { get => missionName; set => missionName = value; }
    public global::System.String Description { get => description; set => description = value; }
    public global::System.Int32 PassCheck { get => passCheck; set => passCheck = value; }
    public Sprite MissionImage { get => missionImage; set => missionImage = value; }
    public MissionSO MissionSO { get => missionSO; set => missionSO = value; }

    public void OnEnable()
    {
        
    }
    public void missionFillData()
    {
        missionName = missionSO.missionName;
        description = missionSO.description;
        passCheck = missionSO.passCheck;
        missionImage = missionSO.missionImage;
    }
    public bool AddArtifact(Artifact artifact)
    {
        if (!_artifacts.Contains(artifact))
        {
            _artifacts.Add(artifact);
            GameLogger.Log($"Artifact {artifact.name} was added to the mission.");
            return true;
        }
        else
            return false;
    }

    public bool RemoveArtifact(Artifact artifact)
    {
        if (_artifacts.Contains(artifact))
        {
            return _artifacts.Remove(artifact);
        }
        else
            return false;
    }
    public bool AddAgent(Agent agent)
    {
        if (!_agents.Contains(agent))
        {
            _agents.Add(agent);
            return true;
        }
        else
            return false;
    }
    public bool RemoveAgent (Agent agent)
    {
        if (_agents.Contains(agent))
        {
            return _agents.Remove(agent);
        }
        else
            return false;
    }
    public bool CheckStat(Agent agent, string stat, float checkValue)
    {
        float rollValue = RollD100();         
        if (rollValue <= agent.GetStatValue(stat))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckHardStat(Agent agent, string stat)
    {
        float rollValue = RollD100();
        if (rollValue <= (agent.GetStatValue(stat)/5))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckExtremeStat(Agent agent, string stat, float checkValue)
    {
        float rollValue = RollD100();
        if (rollValue <= (agent.GetStatValue(stat)/20))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float RollD100()
    {
        return Random.Range(1, 101);
    }


}
