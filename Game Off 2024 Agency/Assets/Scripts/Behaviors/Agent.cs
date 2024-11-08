using UnityEngine;

public class Agent : MonoBehaviour
{
    public new string name;
    public string description;
    public Sprite profilePhoto;
    public int strength;
    public int speed;
    public int intelligence;
    public AgentSO agentSO;
    void Start()
    {
        name = agentSO.name;
        description = agentSO.description;
        profilePhoto = agentSO.profilePhoto;
        strength = agentSO.strength;
        speed = agentSO.speed;
        intelligence = agentSO.intelligence;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
