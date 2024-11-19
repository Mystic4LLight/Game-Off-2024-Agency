using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Constants for time increments
    public float timeDay = 24f;    // 24 hours in a day
    public float timeHour = 1f;    // 1 hour
    public float timeMinute = 1f / 60;  // 1 minute = 1/60 of an hour
    public float timeSecond = 1f / 3600; // 1 second = 1/3600 of an hour

    // Start time and current game time
    public float dayStart = 6f;   // Game starts at 6 AM
    public float actualTime = 8f; // Initial time set to 8 AM
    
    public int dayCount = 0;  // Tracks the number of days passed

    // UI References
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI dayCountText;

    private void Start()
    {
        StartOfDay();
    }

    private void StartOfDay()
    {
        actualTime = dayStart;
        dayCount = 0; // Start from day 0
        UpdateTimeDisplay();
    }

    private void Update()
    {
        UpdateTimeDisplay();
    }

    // Updates the time display in "HH:MM:SS" format and updates the day count
    private void UpdateTimeDisplay()
    {
        // Check if the day has advanced
        if (actualTime >= timeDay)
        {
            actualTime -= timeDay; // Reset time to start of next day
            dayCount++; // Increment the day counter
        }

        int hours = Mathf.FloorToInt(actualTime) % 24;
        int minutes = Mathf.FloorToInt((actualTime * 60) % 60);
        int seconds = Mathf.FloorToInt((actualTime * 3600) % 60);

        // Update UI text elements
        currentTimeText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
        dayCountText.text = $"Day {dayCount}";
    }

    // Methods to advance time by increments
    public void AdvanceTimeByDays(float days)
    {
        actualTime += days * timeDay;
        UpdateTimeDisplay();
    }

    public void AdvanceTimeByHours(float hours)
    {
        actualTime += hours * timeHour;
        UpdateTimeDisplay();
    }

    public void AdvanceTimeByMinutes(float minutes)
    {
        actualTime += minutes * timeMinute;
        UpdateTimeDisplay();
    }

    public void AdvanceTimeBySeconds(float seconds)
    {
        actualTime += seconds * timeSecond;
        UpdateTimeDisplay();
    }
}
