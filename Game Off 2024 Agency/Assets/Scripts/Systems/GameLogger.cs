using UnityEngine;

public static class GameLogger
{
    public static void Log(string message)
    {
        // Ensure this does not call itself
        Debug.Log(message); // This must use Unity's Debug.Log directly
    }

    public static void LogWarning(string message)
    {
        Debug.LogWarning(message);
    }

    public static void LogError(string message)
    {
        Debug.LogError(message);
    }
}
