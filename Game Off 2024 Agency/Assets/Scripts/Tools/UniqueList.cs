using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A wrapper class for a list that ensures unique items. 
/// Prevents the addition of duplicate items and logs a warning if a duplicate is detected.
/// Useful for maintaining collections where only unique elements are allowed.
/// </summary>

[System.Serializable]
public class UniqueList<T>
{
    [SerializeField] private List<T> items = new List<T>();

    public bool Add(T item)
    {
        if (items.Contains(item))
        {
            Debug.LogWarning($"Duplicate item detected: {item}");
            return false;
        }
        items.Add(item);
        return true;
    }

    public void Clear()
    {
        items.Clear();
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public List<T> GetItems()
    {
        return items;
    }
}
