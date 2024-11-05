using UnityEngine;

[CreateAssetMenu(fileName = "AgentSO", menuName = "Scriptable Objects/AgentSO")]
public class AgentSO : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite profilePhoto;
    public int strength;
    public int speed;
    public int intelligence;

}
