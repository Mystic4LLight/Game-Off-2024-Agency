using UnityEngine;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    [Header("Time Settings")]
    public int hoursPerDay = 24;
    public int minutesPerHour = 60;
    public int secondsPerMinute = 60;

    [Header("Current Time")]
    public int currentDay = 1;
    public int currentHour = 0;
    public int currentMinute = 0;
    public int currentSecond = 0;

    [Header("UI References")]
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI timeText;

    [Header("Agent Recruitment")]
    public AgentGenerator agentGenerator; // Reference to the AgentGenerator

    public event Action OnTimeAdvanced; // Event to notify other scripts when time advances

    private void Start()
    {
        UpdateTimeUI();
    }

    /// <summary>
    /// Advances the time by the specified days, hours, minutes, and seconds.
    /// </summary>
    public void AdvanceTime(int days, int hours, int minutes, int seconds)
    {
        currentSecond += seconds;
        if (currentSecond >= secondsPerMinute)
        {
            currentSecond -= secondsPerMinute;
            currentMinute++;
        }

        currentMinute += minutes;
        if (currentMinute >= minutesPerHour)
        {
            currentMinute -= minutesPerHour;
            currentHour++;
        }

        currentHour += hours;
        if (currentHour >= hoursPerDay)
        {
            currentHour -= hoursPerDay;
            currentDay++;
            RefreshRecruitment(); // Call this when a new day begins
        }

        currentDay += days;

        // Notify listeners (e.g., Artifact analysis, books, training) when time advances
        OnTimeAdvanced?.Invoke();

        UpdateTimeUI();
    }

    /// <summary>
    /// Updates the UI elements to reflect the current time.
    /// </summary>
    private void UpdateTimeUI()
    {
        if (dayText != null)
        {
            dayText.text = $"Day: {currentDay}";
        }

        if (timeText != null)
        {
            timeText.text = $"Time: {currentHour:00}:{currentMinute:00}:{currentSecond:00}";
        }
    }

    /// <summary>
    /// Refreshes the recruitment slots in the Agent Generator when a new day begins.
    /// </summary>
    private void RefreshRecruitment()
    {
        if (agentGenerator != null)
        {
            Debug.Log("Refreshing recruitment slots for the new day.");
            agentGenerator.RefreshRecruitment();
        }
        else
        {
            Debug.LogWarning("AgentGenerator reference is missing in TimeManager.");
        }
    }

    /// <summary>
    /// Called by the UI button to advance time by 1 second.
    /// </summary>
    public void AdvanceBySecond()
    {
        AdvanceTime(0, 0, 0, 1);
    }

    /// <summary>
    /// Called by the UI button to advance time by 1 minute.
    /// </summary>
    public void AdvanceByMinute()
    {
        AdvanceTime(0, 0, 1, 0);
    }

    /// <summary>
    /// Called by the UI button to advance time by 1 hour.
    /// </summary>
    public void AdvanceByHour()
    {
        AdvanceTime(0, 1, 0, 0);
    }

    /// <summary>
    /// Called by the UI button to advance time by 1 day.
    /// </summary>
    public void AdvanceByDay()
    {
        AdvanceTime(1, 0, 0, 0);
    }
}
