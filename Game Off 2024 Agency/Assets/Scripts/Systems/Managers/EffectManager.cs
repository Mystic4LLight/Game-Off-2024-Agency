using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    // Singleton instance
    public static EffectManager Instance { get; private set; }

    // List to hold EffectSO elements
    public List<EffectSO> effectSO_List = new List<EffectSO>();

    // Method to get an EffectSO by its name from the list
    public EffectSO GetEffectSOByName(string effectName)
    {
        return effectSO_List.FirstOrDefault(effect => effect.name == effectName);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
