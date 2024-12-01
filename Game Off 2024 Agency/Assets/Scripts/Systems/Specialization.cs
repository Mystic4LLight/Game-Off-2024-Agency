using UnityEngine;

[System.Serializable]
public class Specialization
{
    public enum SpecializationType
    {
        ArtCraft,
        Fighting,
        Firearms,
        Language,
        Science,
        Survival,
        Other
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
    }
}
