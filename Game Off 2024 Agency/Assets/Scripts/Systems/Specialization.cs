using UnityEngine;

[System.Serializable]
public class Specialization
{
    public enum SpecializationType
    {
        ArtCraft,
        Fighting,
        Firearms,
        Science,
        Language,
        Other,
        Survival // New specialization type
    }

    public SpecializationType type;
    public string name;
    public int value;

    // Constructor
    public Specialization(SpecializationType type, string name, int value)
    {
        this.type = type;
        this.name = name;
        this.value = value;
        GameLogger.Log($"Specialization created: Name = {name}, Type = {type}, Value = {value}");
    }
}
