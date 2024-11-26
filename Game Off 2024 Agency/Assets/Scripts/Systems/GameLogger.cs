using UnityEngine;

public static class GameLogger
{
    // Toggle to enable or disable logs globally
    public static bool EnableLogging = false;

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void Log(string message)
    {
        if (EnableLogging)
        {
            Debug.Log(message);
        }
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void LogWarning(string message)
    {
        if (EnableLogging)
        {
            Debug.LogWarning(message);
        }
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void LogError(string message)
    {
        if (EnableLogging)
        {
            Debug.LogError(message);
        }
    }
}
