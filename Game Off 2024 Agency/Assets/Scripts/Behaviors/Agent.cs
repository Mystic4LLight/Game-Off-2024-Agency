using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] private string description;
    [SerializeField] private Sprite profilePhoto;
    [SerializeField] private int strength;
    [SerializeField] private int speed;
    [SerializeField] private int intelligence;
    [SerializeField] public AgentSO agentSO;
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
