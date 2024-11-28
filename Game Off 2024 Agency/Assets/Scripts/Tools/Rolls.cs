using UnityEngine;

public class Rolls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int RollD100()
    {
        return Random.Range(1, 100);
    }
    public static int RollD20()
    {
        return Random.Range(1, 20);
    }
}
